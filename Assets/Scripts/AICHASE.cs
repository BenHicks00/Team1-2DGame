using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class AICHASE : MonoBehaviour
{

    public GameObject player;
    public float speed;

    public float AggroDistance;

    private float distance;

    private bool isFacingRight = true;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;


        if (distance < AggroDistance)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
        if (direction.x > 0 && !isFacingRight)
        {
            Flip(); 
            //makes enemy face right
        }
        else if (direction.x < 0 && isFacingRight)
        {
            Flip(); 
            //make enemy face left
        }
        
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;  
        transform.localScale = theScale;
    }
}
