using UnityEngine;
using UnityEngine.Diagnostics;
public class AimWeapon : MonoBehaviour
{

    private Transform aimTransform;

    private void Awake()
    {
        aimTransform = transform.Find("ARMPIVOT");

    }

    private void Update()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);


        Vector3 aimDirection = (mouseWorldPosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles= new Vector3(0, 0, angle);
        Debug.Log(angle);
    }



}
