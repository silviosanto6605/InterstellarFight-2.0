﻿using JetBrains.Annotations;
using UnityEngine;
using Slider = UnityEngine.UI.Slider;

public class CoolDownUI : MonoBehaviour
{
    public static Slider slider;


    void Start() {

        slider = GetComponent<Slider>();
       
    
    }



    void Update() {

        slider.value = Weapon.bullet_shooted;
  
    }

}