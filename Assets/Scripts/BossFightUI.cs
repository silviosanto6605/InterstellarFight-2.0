using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossFightUI : MonoBehaviour
{
    public Slider healthbar;
    public Text healthAmountText;


    void Update()
    {
        if (SpawnSystem.bossactive)
        {
            gameObject.SetActive(true);
            
            healthbar.value = Boss1.BossHealth;
            healthAmountText.text = Boss1.BossHealth.ToString() + " / "+ Boss1.MaxHealth.ToString();
        }
    }
}
