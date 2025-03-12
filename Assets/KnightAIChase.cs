using UnityEngine;

public class KnightAICHASE : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float AggroDistance;

    private float distance;
    private bool isFacingRight = true;
    private Animator animator; 

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        if (distance < 3)
        {
            animator.SetBool("isRunning", false);

            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            Attack();
        }
        else if (distance < AggroDistance)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (direction.x > 0 && !isFacingRight)
        {
            Flip(); // Makes enemy face right
        }
        else if (direction.x < 0 && isFacingRight)
        {
            Flip(); // Makes enemy face left
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    
    public void Attack()
    {
        animator.SetTrigger("attack"); 
    }
}