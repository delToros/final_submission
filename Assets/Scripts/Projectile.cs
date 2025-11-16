using UnityEngine;

public class Projectile : MonoBehaviour
{
    // For Destroying projectile
    public float northBound = 130;//z
    public float westBound = -130;//x
    public float southBound = -100;//z
    public float eastBound = 120;//x

    // explosion
    public ParticleSystem explosionEffect;

    public float speed = 20;
        // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
        DestructionCheck();
    }

    private void DestructionCheck()
    {
        if (transform.position.z > northBound ||
            transform.position.z < southBound ||
            transform.position.x > eastBound ||
            transform.position.x < westBound)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is tagged as "enemy"
        if (other.CompareTag("enemy"))
        {
            // 1. Play the particle system.
            if (explosionEffect != null)
            {
                // 1. Instantiate the effect at the projectile's position
                // The method automatically returns the new instance's ParticleSystem component
                ParticleSystem newExplosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);

                // 2. Play the new instance
                newExplosion.Play();

                // 3. Set the new instance to destroy itself when it finishes
                Destroy(newExplosion.gameObject, newExplosion.main.duration + 0.1f);
            }

            // 2. Destroy the ENTIRE ENEMY GameObject.
            Destroy(other.gameObject);

            // 3. Destroy the projectile (this GameObject).
            // Use a short delay to let the particles render if the effect is a child object.
            Destroy(gameObject, 0.1f);
        }
    }
}
