using UnityEngine;
using UnityEngine.UI;

public class CoolDownUI : MonoBehaviour
{
    public static Slider slider;


    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = Weapon.maxbulletallowed;
    }


    private void Update()
    {
        slider.value = Weapon.bullet_shooted;
    }
}