using UnityEngine;

namespace ThrillRunner.Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class DashMovement : MonoBehaviour, IMovement
    {
        // ---Inspector Settings---
        [SerializeField] private float dashDistance = 10f; // Total distance of a dash.
        [SerializeField] private float dashCooldown = 2f; // Time before player can dash again.
        [SerializeField] private float dashDuration = 0.2f; // How long the dash movement lasts.

        // ---Private References---
        private CharacterController controller; // Reference to CharacterController, needed on GameObject.
        private Transform cameraTransform; // Reference to camera's transform.

        // ---Dash State---
        private bool isDashing; // Checks if player is in a dash state.
        private float dashTimer; // Timer to track remaining dash.
        private float cooldownTimer; // Tracks when the player can dash again.
        private Vector3 dashDirection; // Direction in which dash is performed.

        void Awake() {
            // Cache references at startup for performance.
            controller = GetComponent<CharacterController>();
            cameraTransform = Camera.main.transform;
        }

        /// <summary>
        /// Called externally every frame.
        /// Handles dash input and returns the movement vector.
        /// </summary>
        /// <param name="input">Horizontal and vertical movement input from the player.</param>
        /// <param name="isSprinting">Whether the player is holding sprint.</param>
        public Vector3 Move(Vector2 input, bool isSprinting) {
            // Count down the cooldown timer each frame.
            cooldownTimer -= Time.deltaTime;

            // If dash is available and the dash key is pressed, initiate dash.
            if (!isDashing && Input.GetKeyDown(KeyCode.Space) && cooldownTimer <= 0f) 
                StartDash();

            // If currently dashing, continue moving.
            if (isDashing) 
                return ContinueDash();

            // Otherwise, no movement from this system.
            return Vector3.zero;
        }

        /// <summary>
        /// Begins a dash in the forward direction of the camera.
        /// Resets timers and sets dash state.
        /// </summary>
        void StartDash() {
            // Flatten camera forward vector and normalize it.
            dashDirection = new Vector3(cameraTransform.forward.x, 0f, cameraTransform.forward.z).normalized;
            isDashing = true;
            dashTimer = dashDuration;
            cooldownTimer = dashCooldown;
        }

        /// <summary>
        /// Applies dash movement over time and ends dash when finished.
        /// </summary>
        /// <returns>The movement vector applied during dash.</returns>
        Vector3 ContinueDash() {
            // Count down dash duration.
            dashTimer -= Time.deltaTime;

            // Calculate dash velocity and move using CharacterController.
            controller.Move(dashDirection * (dashDistance / dashDuration) * Time.deltaTime);

            // Stop dash once time runs out.
            if (dashTimer <= 0f)
                isDashing = false;

            return dashDirection;
        }
    }
}
