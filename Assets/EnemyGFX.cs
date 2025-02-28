using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aipath;

    void Update()
    {
        
        if (aipath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-.25f,.25f, .25f);
        }else if (aipath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(.25f, .25f, .25f);
        }
    }
}
