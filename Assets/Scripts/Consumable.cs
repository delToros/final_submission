using UnityEngine;

public class Consumable : MonoBehaviour
{
    // ENCAPSULATION
    [SerializeField]
    private float rotationSpeed = 50.0f;

    [SerializeField]
    private GameObject effect;

    // Update is called once per frame
    void Update()
    {
       transform.Rotate(0.0f, rotationSpeed * Time.deltaTime, 0.0f, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (effect != null)
            {
                Destroy(effect);
            }

            Destroy(gameObject);
        }
    }
}
