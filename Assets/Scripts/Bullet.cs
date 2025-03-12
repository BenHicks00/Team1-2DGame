using UnityEngine;
using UnityEngine.Rendering;

public class Bullet : MonoBehaviour
{
    public float force;
    private Rigidbody2D rb;
    private AudioSource audioSource;
    public AudioClip hitSFX;
    private Bullet_Types bulletTypes;

    private Camera mainCam;
    private Vector3 mousePos;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play(); // Play shooting sound when bullet is created
        }
        
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot - 180);
        bulletTypes = GetComponent<Bullet_Types>(); // Ensure bullet type script is attached
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BasicEnemy basicEnemy = collision.GetComponent<BasicEnemy>();

        if (basicEnemy != null)
        {
            basicEnemy.TakeDamage(20);
        }
    }
}