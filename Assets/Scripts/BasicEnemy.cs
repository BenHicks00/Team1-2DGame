using UnityEditorInternal;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public float speed;
    public float health;
    [SerializeField]
    private GameObject redParticles;
    public AudioSource audiosource;
    public AudioClip deathSFX;
    private Rigidbody2D rb;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            audiosource.clip = deathSFX;
            audiosource.Play();
            Instantiate(redParticles);
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(speed, rb.linearVelocity.y, 0);
    }
}
