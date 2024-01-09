using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient; //use to change color depends on how many health left
    public Image fill;

    //set the maximum value for health for the player
    public void SetMaxHealth(int maxHealth)
    { 
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        fill.color = gradient.Evaluate(1f);
    }

    //set the current health for the player 
    public void SetHealth(int health)
    { 
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
