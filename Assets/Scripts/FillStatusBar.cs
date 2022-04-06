using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillStatusBar : MonoBehaviour, IUpdateHealth
{
    //public PlayerHealth playerHealth;
    public Image fillImage;
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        //playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    private void Start()
    {
        Player.instance.pHpListeners.Add(this);
    }

    public void UpdateHealth()
    {
        if (slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }

        if (slider.value > slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }
        
        float fillValue = Player.instance.currentHealth / Player.instance.maxHealth;
        if (fillValue <= slider.maxValue / 3)
        {
            fillImage.color = Color.grey;
        }
        else if (fillValue > slider.maxValue / 3)
        {
            fillImage.color = Color.red;
        }
        
        slider.value = fillValue;
    }
}
