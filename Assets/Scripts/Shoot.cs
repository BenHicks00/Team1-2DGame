using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{

    public Transform shootingPoint;
    public GameObject bulletPrefab;

    private void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            Instantiate(bulletPrefab,shootingPoint.position,transform.rotation);
        }
    }
}
