using UnityEngine;
using UnityEngine.InputSystem;

namespace CraftingGame
{
    public class PlayerController : MonoBehaviour, IEquipOwner
    {
        [SerializeField] private CharacterController2D characterController2D;
        [SerializeField] private Animator animator;
        [SerializeField] private float runSpeed;
        [SerializeField] private InventoryBase inventory;
        [SerializeField] private AnimationEventTrigger animationEventTrigger;

        [Header("Equipment")] [SerializeField] private Transform equipmentPosition;

        private IEquipment currentEquipment;

        #region Controls

        private SimpleControls simpleControls;
        private SimpleControls.GameplayActions gameplayActions;
        private float horizontalMovement;
        private bool jump;
        private bool dash;

        #endregion

        #region Animator Hashes

        private static readonly int IsGroundedHashed = Animator.StringToHash("IsGrounded");
        private static readonly int SpeedHashed = Animator.StringToHash("Speed");
        private static readonly int VSpeedHashed = Animator.StringToHash("vSpeed");
        private static readonly int AttackHashed = Animator.StringToHash("Attack");

        #endregion

        public Transform EquipHolderTransform => equipmentPosition;
        public AnimationEventTrigger AnimationEventTrigger => animationEventTrigger;

        private void Awake()
        {
            simpleControls = new SimpleControls();
            gameplayActions = simpleControls.gameplay;
            gameplayActions.Jump.performed += _ => jump = true;
            gameplayActions.dash.performed += _ => dash = true;
            gameplayActions.Attack.performed += AttackOnPerformed;

            inventory.OnItemEquipped += OnItemEquipped;
        }

        private void OnEnable()
        {
            simpleControls.Enable();
        }

        private void OnDisable()
        {
            simpleControls.Disable();
        }

        private void Update()
        {
            horizontalMovement += gameplayActions.move.ReadValue<Vector2>().x * runSpeed * Time.deltaTime;
            animator.SetBool(IsGroundedHashed, characterController2D.IsGrounded);
            animator.SetFloat(SpeedHashed, Mathf.Abs(characterController2D.Velocity.x));
            animator.SetFloat(VSpeedHashed, characterController2D.Velocity.y);
        }

        private void FixedUpdate()
        {
            characterController2D.Move(horizontalMovement, jump, dash);
            horizontalMovement = 0;
            jump = dash = false;
        }

        private void AttackOnPerformed(InputAction.CallbackContext obj)
        {
            animator.SetTrigger(AttackHashed);
        }

        private void OnItemEquipped(InventoryBase.EquippedEventArgs obj)
        {
            if (!obj.ItemBlueprint)
            {
                return;
            }

            if (currentEquipment != null) Destroy(currentEquipment.gameObject);

            var prefab = obj.ItemBlueprint.prefab;
            var item = Instantiate(prefab);
            var equipment = (IEquipment) item;
            equipment.Equip(this);
            currentEquipment = equipment;
            animator.Rebind();
        }
    }
}