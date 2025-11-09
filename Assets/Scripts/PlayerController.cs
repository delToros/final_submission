using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerController : BasicCharacter // INHERITANCE
{

    public float forwardInput;
    public float horizontalInput;
    public float turnSpeed;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        speed = 8;
        health = 100f;
        turnSpeed = 100;

        animator = GetComponent<Animator>();

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
       Debug.Log("Calculated Speed: " + currentSpeed);

        // 3. Set the Animator parameter
        animator.SetFloat("f_speed", currentSpeed);
    }

    // POLYMORPHISM
    public override void Moving()
    {
        Vector3 movement = forwardInput * speed * Time.deltaTime * Vector3.forward;

        transform.Translate(movement);

        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }
}
