using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private AudioSource audioSource;
    public AudioClip hitSFX;
    private Bullet_Types bulletTypes;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * speed;
        bulletTypes = GetComponent<Bullet_Types>(); // Ensure bullet type script is attached
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BasicEnemy basicEnemy = collision.GetComponent<BasicEnemy>();

        if (basicEnemy != null)
        {
            basicEnemy.TakeDamage(20);
        }

        // Play hit sound
        if (audioSource != null && hitSFX != null)
        {
            audioSource.PlayOneShot(hitSFX);
        }

        // Bullet_Types already handles destruction, so remove extra Destroy() calls here
    }
}