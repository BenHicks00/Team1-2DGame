using UnityEngine;

public enum BulletType
{
    Regular,
    Ricochet,
    Explosive,
    Piercing
}

public class Bullet_Types : MonoBehaviour
{
    public BulletType bulletType;
    public float speed = 10f;
    private Rigidbody2D rb;
    private int pierceCount = 0;
    private int maxPierces = 3;
    private int ricochetCount = 0;
    private int maxRicochets = 3; // Set how many times the bullet can bounce

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * speed;
        Debug.Log($"Bullet spawned with type: {bulletType}");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Bullet {bulletType} collided with: {collision.gameObject.name}");

        if ((collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Ground")) && bulletType == BulletType.Ricochet)

        {
            HandleRicochet(collision);
            return;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            BasicEnemy enemy = collision.gameObject.GetComponent<BasicEnemy>();
            if (enemy != null)
            {
                if (bulletType == BulletType.Piercing || bulletType == BulletType.Explosive)
                {
                    enemy.TakeDamage(9999); // One-hit kill for piercing and explosive bullets
                }
                else
                {
                    enemy.TakeDamage(20); // Normal damage for regular and ricochet bullets
                }
            }

            Debug.Log($"Bullet {bulletType} hit an enemy!");

            if (bulletType == BulletType.Explosive)
            {
                Destroy(gameObject); // Explosive bullets destroy on impact
            }
            else if (bulletType == BulletType.Piercing)
            {
                pierceCount++;
                if (pierceCount >= maxPierces)
                {
                    Debug.Log("Piercing bullet reached max pierces and is destroyed.");
                    Destroy(gameObject);
                }
            }
            else
            {
                Destroy(gameObject); // Regular and Ricochet bullets destroy on impact unless bouncing
            }
        }
        else if (!collision.gameObject.CompareTag("Enemy") && bulletType != BulletType.Piercing)
        {
            Debug.Log($"Bullet {bulletType} hit a non-enemy and is destroyed.");
            Destroy(gameObject);
        }
    }

    private void HandleRicochet(Collision2D collision)
    {
        if (ricochetCount >= maxRicochets)
        {
            Debug.Log("Ricochet bullet exceeded max bounces and is destroyed.");
            Destroy(gameObject);
            return;
        }

        ricochetCount++;
        Vector2 normal = collision.contacts[0].normal; // Get the surface normal
        rb.linearVelocity = Vector2.Reflect(rb.linearVelocity, normal); // Reflect the velocity
        Debug.Log($"Ricochet! Remaining bounces: {maxRicochets - ricochetCount}");
    }
}
