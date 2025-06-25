using UnityEngine;

namespace ThrillRunner.Movement
{
    /// <summary>
    /// Provides basic grounded movement and jumping using CharacterController.
    /// Implements walking, sprinting, and jumping based on input and camera direction.
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class WalkMovement : MonoBehaviour, IMovement
    {
        // ---Movement Settings---
        [SerializeField] private float walkSpeed = 2f; // Base walking speed.
        [SerializeField] private float sprintMultiplier = 10f; // Sprint speed multiplier.
        [SerializeField] private float jumpHeight = 1.5f; // Maximum jump height.
        [SerializeField] private float rotationSpeed = 120f;

        // ---Internal References---
        private CharacterController controller; 
        private Transform cam;

        // ---Gravity Related Settings---
        private const float GRAVITY = -9.81f; // Constant gravity value (m/s²)
        private const float GROUND_STICK_FORCE = -2f; // Small force to keep player grounded.
        private float verticalVelocity; // Tracks vertical velocity for jump/gravity.
        private bool isGrounded;

        void Awake()
        {
            controller = GetComponent<CharacterController>();
            cam = Camera.main.transform;
        }

        /// <summary>
        /// Applies walking, sprinting, and jumping logic based on input and character state.
        /// </summary>
        /// <param name="input">2D movement input from player.</param>
        /// <param name="isSprinting">Whether the player is holding sprint.</param>
        /// <returns>Normalized direction of movement, used for animation and rotation.</returns>
        public Vector3 Move(Vector2 input, bool isSprinting)
        {
            Vector3 forward = new Vector3(cam.forward.x, 0f, cam.forward.z).normalized;
            Vector3 moveDirection = forward * input.y;
            
            float speed = isSprinting ? walkSpeed * sprintMultiplier : walkSpeed;
            Vector3 horizontalMove = moveDirection.normalized * speed;

            isGrounded = controller.isGrounded;

            ApplyGravity();

            Vector3 moveVector = (horizontalMove + Vector3.up * verticalVelocity) * Time.deltaTime;
            controller.Move(moveVector);

            return moveDirection.normalized;
        }

        public void Jump() {
            Debug.Log("JumP!");
            if (isGrounded) {
                verticalVelocity = Mathf.Sqrt(-2f * jumpHeight * GRAVITY);
            }
        }

        void ApplyGravity() {
            if (controller.isGrounded && verticalVelocity < 0)
                verticalVelocity = GROUND_STICK_FORCE;
            else 
                verticalVelocity += GRAVITY * Time.deltaTime;
        }

        public void Rotate(float horizontalInput, float rotationSpeed) {
            float rotationAmount = horizontalInput * rotationSpeed * Time.deltaTime;
            transform.Rotate(0f, rotationAmount, 0f, Space.World);
        }
    }
}
