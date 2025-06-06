using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float walkSpeed = 2f;
    public float rotationSpeed = 0.5f;
    public float sprintMultiplier = 10f;

    [Header("References")]
    public Transform cameraTransform;

    private CharacterController controller;
    private Animator animator;

    private float lastTurnInput;

    private Vector2 input;
    private Vector3 movementDirection;

    void Start() {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

        if (cameraTransform == null)
            cameraTransform = Camera.main.transform;
    }

    void Update() {
        HandleInput();
        HandleMovement();
        HandleRotation();
        UpdateAnimations();
    }

    void HandleInput() {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }

    void HandleMovement() {
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;
        camForward.y = 0f;
        camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();

        movementDirection = transform.forward * input.y;
        movementDirection.Normalize();

        bool isSprinting = Input.GetKey(KeyCode.LeftShift);
        float moveSpeed = isSprinting ? walkSpeed * sprintMultiplier : walkSpeed;

        controller.Move(movementDirection * moveSpeed * Time.deltaTime);
    }

    void HandleRotation() {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.Rotate(0, horizontalInput * rotationSpeed, 0, Space.World);

        if (horizontalInput > 0.1f && lastTurnInput <= 0.1f)
            animator.SetTrigger("TurnRight");
        else if (horizontalInput < -0.1f && lastTurnInput >= -0.1f)
            animator.SetTrigger("TurnLeft");

        lastTurnInput = horizontalInput;

        animator.SetBool("IsRotating", Mathf.Abs(horizontalInput) > 0);
    }

    void UpdateAnimations() {
        float speedPercent = Mathf.Clamp01(movementDirection.magnitude);
        animator.SetFloat("MoveSpeed", speedPercent);

        bool isSprinting = Input.GetKey(KeyCode.LeftShift) && input.y > 0.1f;
        animator.SetBool("IsSprinting", isSprinting);

        bool isWalkingBackwards = input.y < -0.1f;
        animator.SetBool("WalksBackwards", isWalkingBackwards);
    }
}
