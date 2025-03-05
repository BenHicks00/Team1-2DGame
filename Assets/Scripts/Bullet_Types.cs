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

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * speed;
        Debug.Log($"Bullet spawned with type: {bulletType}");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) return; // Ignore player

        if (collision.CompareTag("Enemy"))
        {
            BasicEnemy enemy = collision.GetComponent<BasicEnemy>();
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
                Destroy(gameObject); // Regular and ricochet bullets destroy on impact
            }
        }
        else if (!collision.CompareTag("Enemy"))
        {
            Debug.Log($"Bullet {bulletType} hit a non-enemy and is destroyed.");
            Destroy(gameObject);
        }
    }
}