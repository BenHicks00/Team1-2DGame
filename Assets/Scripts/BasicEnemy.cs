using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public float speed;
    public float health;
    public int damageToPlayer; // Damage dealt to player on contact
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
        // rb.velocity = new Vector3(speed, rb.velocity.y, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision) // Using Collision instead of Trigger
    {
        Debug.Log($"Enemy collided with: {collision.gameObject.name}");

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy hit the player!");

            Player_Health playerHealth = collision.gameObject.GetComponent<Player_Health>();
            if (playerHealth != null)
            {
                Debug.Log($"Player takes {damageToPlayer} damage!");
                playerHealth.TakeDamage(damageToPlayer);
            }
            else
            {
                Debug.LogWarning("PlayerHealth script not found on player!");
            }
        }
    }
}
