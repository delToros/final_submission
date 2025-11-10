using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerController : BasicCharacter // INHERITANCE
{

    public float forwardInput;
    public float horizontalInput;
    public float turnSpeed;
    private Animator animator;

    // For jumping
    private Rigidbody rb;
    public float jumpForce = 8;
    public bool isOnGround = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        speed = 8;
        health = 100f;
        turnSpeed = 100;

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        forwardInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        Moving();

        // Setup f_speed parameter for animation

        // 1.The vector representing the movement direction on the horizontal plane
        Vector3 movementVector = new(horizontalInput, 0f, forwardInput);

        // 2. Calculate the magnitude (length) of the movement vector
        // This value will be 0 when idle and 1 (or greater) when moving at full speed.
       float currentSpeed = movementVector.magnitude;

        // 3. Set the Animator parameter
        animator.SetFloat("f_speed", currentSpeed);



    }

    // POLYMORPHISM
    public override void Moving()
    {
        Vector3 movement = forwardInput * speed * Time.deltaTime * Vector3.forward;

        transform.Translate(movement);

        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //isOnGround = false;



            animator.SetBool("isOnGround", false);
            animator.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            isOnGround = true;
            animator.SetBool("isOnGround", true);
        }
    }
}
