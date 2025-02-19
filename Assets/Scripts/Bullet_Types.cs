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
    public BulletType bulletType; // Exposed in Inspector

    public void HandleBulletBehavior()
    {
        switch (bulletType)
        {
            case BulletType.Regular:
                Debug.Log("Regular bullet fired.");
                break;
            case BulletType.Ricochet:
                Debug.Log("Ricochet bullet behavior triggered.");
                break;
            case BulletType.Explosive:
                Debug.Log("Explosive bullet behavior triggered.");
                break;
            case BulletType.Piercing:
                Debug.Log("Piercing bullet behavior triggered.");
                break;
        }
    }
}