using UnityEngine;

public class KnightAICHASE : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float AggroDistance;

    private float distance;
    private bool isFacingRight = true;
    private Animator animator; // Animator component reference

    void Start()
    {
        // Get the Animator component attached to the enemy
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        // Check if the enemy is within aggro range to chase the player
        if (distance < AggroDistance)
        {
            // Move the enemy towards the player and set the running animation
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

            // Trigger the running animation
            animator.SetBool("isRunning", true); // Set isRunning to true when chasing
        }
        else
        {
            // Stop the running animation if the player is out of aggro range
            animator.SetBool("isRunning", false);
        }

        // Flip the enemy's facing direction based on the player's position
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

    // Example: Call this method when the enemy is supposed to attack
    public void Attack()
    {
        animator.SetTrigger("Attack"); // Trigger the "Attack" animation
    }
}