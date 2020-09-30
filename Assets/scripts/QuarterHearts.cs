using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuarterHearts : MonoBehaviour
{
    public PlayerStats playerStats;

    [SerializeField] private Image[] heartSlots;
    [SerializeField] private Sprite[] hearts;

    private float currentHealth;
    private float maximumHealth;
    private float healthPerSection;


    public void UpdateHearts(float curHealth, float maxHealth)
    {
        currentHealth = curHealth;
        maximumHealth = maxHealth;

        healthPerSection = maximumHealth / (heartSlots.Length * 4);
    }

    private void Update()
    {
        int i = 0;

        foreach(Image slot in heartSlots)
        {
            if (currentHealth >= (healthPerSection * 4) + healthPerSection * 4 * i)
            {
                heartSlots[i].sprite = hearts[0];
            }
            else if (currentHealth >= (healthPerSection * 3) + healthPerSection * 4 * i)
            {
                heartSlots[i].sprite = hearts[1];
            }
            else if (currentHealth >= (healthPerSection * 2) + healthPerSection * 4 * i)
            {
                heartSlots[i].sprite = hearts[2];
            }
            else if (currentHealth >= (healthPerSection * 1) + healthPerSection * 4 * i)
            {
                heartSlots[i].sprite = hearts[3];
            }
            else
            {
                heartSlots[i].sprite = hearts[4];
            }

            i++;
        }
    }
}
