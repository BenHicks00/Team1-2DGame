using UnityEngine;

public class TexEnemy : MonoBehaviour
{
    public float speed;
    public float health;
    public int damageToPlayer; // Damage dealt to player on contact
    public ParticleSystem redParticles;
    public AudioSource audiosource;
    public AudioClip deathSFX;
    public AudioClip damageSFX;
    public AudioClip bossFightMusic; // Music to play during animation
    private Rigidbody2D rb;
    private Animator animator;

    public LevelLoader levelloader;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Get the Animator
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        redParticles.Play();

        if (audiosource != null && damageSFX != null)
        {
            audiosource.PlayOneShot(damageSFX);
        }

        if (health <= 0)
        {
            audiosource.clip = deathSFX;
            audiosource.Play();

            levelloader.LoadWinScene();
            //Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        // rb.velocity = new Vector3(speed, rb.velocity.y, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
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

    // NEW: Play continuous audio when the "Tex Boss fight1" animation is triggered
    private void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Tex Boss fight1"))
        {
            if (!audiosource.isPlaying) // Prevent restarting the audio each frame
            {
                audiosource.clip = bossFightMusic;
                audiosource.loop = true; // Ensure the sound loops
                audiosource.Play();
                Debug.Log("Boss fight music started!");
            }
        }
        else
        {
            if (audiosource.clip == bossFightMusic) // Stop only if it's playing the boss music
            {
                audiosource.Stop();
                Debug.Log("Boss fight music stopped!");
            }
        }
    }
}