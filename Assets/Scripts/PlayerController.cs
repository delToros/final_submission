using UnityEngine;

public class PlayerController : BasicCharacter // INHERITANCE
{

    public float forwardInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        speed = 10f;
        health = 100f;
    }

    void FixedUpdate()
    {
        forwardInput = Input.GetAxis("Vertical");
        Moving();
    }

    // POLYMORPHISM
    public override void Moving()
    {
        Vector3 movement = Vector3.forward * forwardInput * speed * Time.deltaTime;

        transform.Translate(movement);
    }
}
