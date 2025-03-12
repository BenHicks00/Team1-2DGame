using UnityEngine;

public class BreakWall : MonoBehaviour
{

    public float health;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
    }

    private void FixedUpdate()
    {
    }

   
}



