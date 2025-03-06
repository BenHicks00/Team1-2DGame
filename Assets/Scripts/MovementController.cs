using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MovementController : MonoBehaviour
{

    // Speeds and floats 
    private float horizontal;
    private float speed = 8f;
    private float jumpPower = 16f;
    private float health = 100f;
    private bool isFacingRight = true;

    public Healthbar hp;
    private int Health = 100;

    // Where we import the Player block, groundcheck for jumping, and the ground layer to know what to jump on
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;



  
    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");





        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
        }
        if(Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f) 
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }

        hp.SetHealth(Health);
        Flip();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(horizontal * speed, rb.linearVelocityY);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position,0.2f,groundLayer);
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            

            transform.Rotate(0, 180, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //This event/function handles trigger events (collsion between a game object with a rigid body)

        if (other.gameObject.CompareTag("DeathBox"))
        {
            SceneManager.LoadScene(4);
        }

        if (other.gameObject.CompareTag("LevelOneGate"))
        {
            SceneManager.LoadScene(5);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            Health = Health - 10;  
        }
    }
}
// hi