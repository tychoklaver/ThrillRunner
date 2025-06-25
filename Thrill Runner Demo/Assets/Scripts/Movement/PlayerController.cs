using UnityEngine;

namespace ThrillRunner.Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour walkMovement;
        [SerializeField] private MonoBehaviour dashMovement;

        private IMovement walk;
        private IMovement dash;
        private IMovement currentMovement;

        private Vector2 input;
        private bool isSprinting;
        private MovementState currentState = MovementState.Walk;


        private Animator animator;
        private float lastHorizontalInput;

        void Awake() {
            animator = GetComponent<Animator>();
            walk = walkMovement as IMovement;
            dash = dashMovement as IMovement;
            currentMovement = walk;
        }

        void Update() {
            HandleInput();
            HandleStateSwitch();

            ApplyRotation();
            ApplyMovement();
            UpdateAnimatorStates();
            if (Input.GetKeyDown(KeyCode.Space) && currentState == MovementState.Walk)
                currentMovement.Jump();
        }

        void HandleInput() {
            input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            isSprinting = Input.GetKey(KeyCode.LeftShift);
        }

        void HandleStateSwitch() {
            if (Input.GetKeyDown(KeyCode.Q) && currentState != MovementState.Dash) {
                currentMovement = dash;
                currentState = MovementState.Dash;
            }
        }

        void ApplyRotation() {
            float horizontal = input.x;
            currentMovement.Rotate(horizontal, 120f);
        }

        void ApplyMovement() {
            Vector3 movement = currentMovement.Move(input, isSprinting);

            if (currentState == MovementState.Dash && movement == Vector3.zero) {
                currentMovement = walk;
                currentState = MovementState.Walk;
            }
        }

        void UpdateAnimatorStates() {
            animator.SetFloat("MoveSpeed", input.magnitude);
            animator.SetBool("IsSprinting", isSprinting && input.y > 0.1f);
            animator.SetBool("WalksBackwards", input.y < -0.1f);

            if (input.x > 0.1f && lastHorizontalInput <= 0.1f)
                animator.SetTrigger("TurnRight");
            else if (input.x < -0.1f && lastHorizontalInput >= -0.1f)
                animator.SetTrigger("TurnLeft");

            animator.SetBool("IsRotating", Mathf.Abs(input.x) > 0f);
        }
    }

    public enum MovementState {
        Walk,
        Dash
    }
}
