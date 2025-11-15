using UnityEngine;

public class Consumable : MonoBehaviour
{
    // ENCAPSULATION
    [SerializeField]
    private float rotationSpeed = 50.0f;

    // Update is called once per frame
    void Update()
    {
       transform.Rotate(0.0f, 50.0f * Time.deltaTime, 0.0f, Space.World);
    }
}
