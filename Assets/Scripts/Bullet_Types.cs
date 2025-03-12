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
    private int maxRicochets = 3; // Maximum bounces before destruction
    public float lifetime = 5f; // Bullet lifetime before automatic destruction

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * speed;
        Debug.Log($"Bullet spawned with type: {bulletType}");
        Destroy(gameObject, lifetime); // Destroy bullet after set time
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) return; // Ignore player


        if (collision.CompareTag("BreakWall"))
        {
            BreakWall wall = collision.GetComponent<BreakWall>();
            if (wall != null)
            {
                if (bulletType == BulletType.Piercing || bulletType == BulletType.Explosive)
                {
                    wall.TakeDamage(9999); // One-hit kill for piercing and explosive bullets
                }

            }
        }

        if (collision.CompareTag("Boss"))
        {
            TexEnemy tenemy = collision.GetComponent<TexEnemy>();
            if (tenemy != null)
            {


                tenemy.TakeDamage(20); // Normal damage for regular and ricochet bullets

            }
        }

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
            else if (collision.gameObject.CompareTag("Ground"))
            {
                if (bulletType == BulletType.Ricochet && ricochetCount < maxRicochets)
                {
                    ricochetCount++;
                    Vector2 normal = (Vector2)transform.position - collision.ClosestPoint(transform.position);
                    rb.linearVelocity = Vector2.Reflect(rb.linearVelocity, normal.normalized);
                    Debug.Log($"Ricochet! Remaining bounces: {maxRicochets - ricochetCount}");
                }
                else
                {
                    Debug.Log($"Ricochet bullet exceeded max bounces and is destroyed.");
                    Destroy(gameObject);
                }
            }
            else
            {
                Debug.Log($"Bullet {bulletType} hit a non-enemy and is destroyed.");
                Destroy(gameObject);
            }
        }
    }


