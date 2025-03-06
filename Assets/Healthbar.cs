using UnityEngine;
using UnityEngine.UI;


public class Healthbar : MonoBehaviour
{

    public Slider slider;

    public void SetMaxHealth(int hp)
    {
        slider.maxValue = hp;
        slider.value = hp;
    }
    public void SetHealth(int hp)
    {
        slider.value = hp;
    }


}
