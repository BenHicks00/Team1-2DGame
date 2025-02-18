using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;

    // Asks for audio source and audio clip to be imported 
    private AudioSource audioSource;
    private AudioClip hit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        hit = GetComponent<AudioClip>();
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BasicEnemy basicEnemy = collision.GetComponent<BasicEnemy>();

        if (basicEnemy != null)
        {
            basicEnemy.TakeDamage(20);
        }
        audioSource.clip = hit;
        audioSource.Play();
        Destroy(gameObject);
    }

}
