using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{

    public Transform shootingPoint;
    public GameObject bulletPrefab;

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Instantiate(bulletPrefab,shootingPoint.position,transform.rotation);
        }
    }
}
