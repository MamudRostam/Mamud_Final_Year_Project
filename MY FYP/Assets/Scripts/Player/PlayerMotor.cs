using UnityEngine;

public class PlayerMotor : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 playerVelocity;
    private Vector3 moveVelocity;
    private bool isGrounded;


    public float speed = 5f;
    public float gravity = -20f;
    public float jumpHeight = 3f;

    public float acceleration = 20f;
    public float deceleration = 25f;
    public float airControl = 0.4f;
    public float groundSnapForce = -8f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && playerVelocity.y < 0f)
        {
            playerVelocity.y = groundSnapForce;
        }
    }

    public void ProcessMove(Vector2 input)
    {
        if (Time.timeScale == 0f) return;

        Vector3 inputDir = new Vector3(input.x, 0f, input.y);
        inputDir = transform.TransformDirection(inputDir);
        inputDir.Normalize();

        float currentAccel = isGrounded ? acceleration : acceleration * airControl;

        Vector3 targetVelocity = inputDir * speed;
        moveVelocity = Vector3.MoveTowards(
            moveVelocity,
            targetVelocity,
            currentAccel * Time.deltaTime);

        if (inputDir.magnitude < 0.01f)
        {
            moveVelocity = Vector3.MoveTowards(
                moveVelocity,
                Vector3.zero,
                deceleration * Time.deltaTime);
        }

        controller.Move(moveVelocity * Time.deltaTime);

        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);



        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if(isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}
