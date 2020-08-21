using UnityEngine;
using UnityEngine.UI;

public class CoolDownUI : MonoBehaviour
{
    public static Slider bulletshootedSlider;

    
    private void Start()
    {
        bulletshootedSlider = GetComponent<Slider>();
        bulletshootedSlider.maxValue = Weapon.maxbulletallowed;
    }


    private void Update()
    {
        bulletshootedSlider.value = Weapon.bullet_shooted;
    }
}