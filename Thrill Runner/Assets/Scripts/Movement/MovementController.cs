using UnityEngine;

namespace ThrillRunner.Movement
{
    /// <summary>
    /// Central movement controller that delegates actual movement behavior to an IMovement implementation.
    /// Handles input reading, character rotation, animation syncing, and runtime movement logic switching.
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class MovementController : MonoBehaviour
    {
        // ---Inspector Settings---
        [Header("Settings")]
        [SerializeField] private MonoBehaviour defaultMovementLogic; // Must implement IMovement
        [SerializeField] private float rotationSpeed = 120f; // Controls how fast the character turns.
        [SerializeField] private Transform cameraTransform; // Used to align movement direction with camera.

        // ---Internal References & State--- 
        private CharacterController characterController; // Cached CharacterController for movement.
        private Animator animator; // Animator for controlling movement animations.
        private IMovement currentMovement; // Active movement logic implementation.

        private Vector2 input; // Raw input values.
        private Vector3 lastMoveDirection; // Last movement vector, used for animations.
        private float lastHorizontalInput; // Used for turn animation detection.

        private void Awake() {
            characterController = GetComponent<CharacterController>();
            animator = GetComponentInChildren<Animator>();
            currentMovement = defaultMovementLogic as IMovement;

            // Automatically assign main camera if none set.
            if (cameraTransform == null)
                cameraTransform = Camera.main.transform;
        }

        private void Update() {
            HandleInput(); // Polls and stores input.
            ApplyMovement(); // Calls current movement behavior 
            ApplyRotation(); // Applies rotation based on input.
            UpdateAnimatorStates(); // Syncs movement data with animator
        }

        /// <summary>
        /// Reads horizontal and vertical player input each frame.
        /// </summary>
        private void HandleInput() {
            input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

        /// <summary>
        /// Calls the active IMovement implementation to apply movement logic.
        /// Stores the resulting direction for animation syncing.
        /// </summary>
        private void ApplyMovement() {
            bool isSprinting = Input.GetKey(KeyCode.LeftShift);
            lastMoveDirection = currentMovement?.Move(input, isSprinting) ?? Vector3.zero;
        }

        /// <summary>
        /// Applies rotation based on horizontal input and triggers turning animations.
        /// <summary>
        private void ApplyRotation() {
            float horizontal = input.x;

            float rotationAmount = horizontal * rotationSpeed * Time.deltaTime;
            // Apply physical rotation.
            transform.Rotate(0f, rotationAmount, 0f, Space.World);

            // Trigger turn animations when direction changes.
            if (horizontal > 0.1f && lastHorizontalInput <= 0.1f)
                animator.SetTrigger("TurnRight");
            else if (horizontal < -0.1f && lastHorizontalInput >= -0.1f)
                animator.SetTrigger("TurnLeft");

            // IsRotating = true while actively turning.
            animator.SetBool("IsRotating", Mathf.Abs(horizontal) > 0f);
            lastHorizontalInput = horizontal;
        }

        /// <summary>
        /// Updates animator parameters based on movement direction and input state.
        /// </summary>
        private void UpdateAnimatorStates() {
            animator.SetFloat("MoveSpeed", Mathf.Clamp01(lastMoveDirection.magnitude));
            animator.SetBool("IsSprinting", Input.GetKey(KeyCode.LeftShift) && input.y > 0.1f);
            animator.SetBool("WalksBackwards", input.y < -0.1f);
        }

        /// <summary> 
        /// Switches the currently active movement logic at runtime.
        /// Must exist on the same GameObject.
        /// </summary>
        /// <typeparam name="T">A MonoBeh</typeparam>
        public void SwitchMovement<T>() where T : MonoBehaviour, IMovement {
            IMovement newMovement = GetComponent<T>();
            if (newMovement != null)
                currentMovement = newMovement;
        }
    }
}
