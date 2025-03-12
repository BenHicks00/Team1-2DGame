using UnityEngine;

public class EnemyHealthSFX : MonoBehaviour
{
    public float health;
    public ParticleSystem redParticles;
    public AudioSource audiosource;
    public AudioClip deathSFX;
    private Rigidbody2D rb;

    public void TakeDamage(float damage)
    {
        health -= damage;
        redParticles.Play();
        if (health <= 0)
        {
            audiosource.clip = deathSFX;
            audiosource.Play();
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
    }
}
