using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Slider easeHealthSlider;
    public Image Icon;
    public int maxHealth = 100;
    public int health;
    public float lerpSpeed = 0.05f;
    public Character currCharacter;
    public TMP_Text nameText;

    // Start is called before the first frame update
    public void Init(Character character)
    {
        currCharacter = character;
        nameText.text = character.Name;
        maxHealth = currCharacter.GetStats().Health;
        health = maxHealth - currCharacter.LostHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        easeHealthSlider.maxValue = maxHealth;
        easeHealthSlider.value = maxHealth;
        currCharacter.OnHealthChange += UpdateHealthBar;
    }

    void UpdateHealthBar()
    {
        health = maxHealth - currCharacter.LostHealth;
        if (healthSlider.value != health)
        {
            healthSlider.value = health;
        }       
    }
    // Update is called once per frame
    void Update()
    {
        if (healthSlider.value != easeHealthSlider.value)
        {
            easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, health, lerpSpeed);
        }
        
    }
}
