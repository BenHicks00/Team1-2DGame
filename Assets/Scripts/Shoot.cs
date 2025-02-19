using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject regularBulletPrefab;
    public GameObject ricochetBulletPrefab;
    public GameObject explosiveBulletPrefab;
    public GameObject piercingBulletPrefab;

    private BulletType currentBulletType = BulletType.Regular;

    private void Update()
    {
        // Switch bullet types with number keys
        if (Keyboard.current.digit1Key.wasPressedThisFrame) currentBulletType = BulletType.Regular;
        if (Keyboard.current.digit2Key.wasPressedThisFrame) currentBulletType = BulletType.Ricochet;
        if (Keyboard.current.digit3Key.wasPressedThisFrame) currentBulletType = BulletType.Explosive;
        if (Keyboard.current.digit4Key.wasPressedThisFrame) currentBulletType = BulletType.Piercing;

        // Fire when left mouse button is clicked
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            FireBullet();
        }
    }

    void FireBullet()
    {
        GameObject selectedBullet = regularBulletPrefab;
        switch (currentBulletType)
        {
            case BulletType.Ricochet:
                selectedBullet = ricochetBulletPrefab;
                break;
            case BulletType.Explosive:
                selectedBullet = explosiveBulletPrefab;
                break;
            case BulletType.Piercing:
                selectedBullet = piercingBulletPrefab;
                break;
        }
        Instantiate(selectedBullet, shootingPoint.position, transform.rotation);
    }
}

