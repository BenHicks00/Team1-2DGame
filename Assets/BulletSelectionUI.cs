using UnityEngine;
using UnityEngine.UI; // Import UI namespaces

public class BulletSelectionUI : MonoBehaviour
{
    public Image regularBulletIcon;
    public Image ricochetBulletIcon;
    public Image explosiveBulletIcon;
    public Color defaultColor = Color.white;
    public Color highlightColor = Color.yellow;

    private void Start()
    {
        HighlightSelectedBullet(BulletType.Regular); // Default selection
    }

    public void HighlightSelectedBullet(BulletType selectedBullet)
    {
        Debug.Log("Updating bullet selection UI...");

        // Reset all icons to default color
        regularBulletIcon.color = defaultColor;
        ricochetBulletIcon.color = defaultColor;
        explosiveBulletIcon.color = defaultColor;

        // Highlight the selected bullet
        switch (selectedBullet)
        {
            case BulletType.Regular:
                regularBulletIcon.color = highlightColor;
                Debug.Log("Regular Bullet Selected");
                break;
            case BulletType.Ricochet:
                ricochetBulletIcon.color = highlightColor;
                Debug.Log("Ricochet Bullet Selected");
                break;
            case BulletType.Explosive:
                explosiveBulletIcon.color = highlightColor;
                Debug.Log("Explosive Bullet Selected");
                break;
        }
    }
}