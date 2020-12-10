using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Player : MonoBehaviour
{

    public PlayerStats playerStats;

    public int level = 3;
    public float health = 55;
    //move()
    //i did this for testing
    public void Save()
    {
        SaveSystem.SavePlayer(this);
    }
    public void Load()
    {
        //public PlayerStats data;
        PlayerStats data = SaveSystem.LoadPlayer();
        level = data.level;
        health = data.maxHealth;
        Vector3 pos = new Vector3(data.position[0],
                                    data.position[1],
                                    data.position[2]);
        transform.position = pos;
    }

    /*

    public float currentHealth;
    public float currentMana;
    public float currentStamina;

    public HealthBar healthBar;
    public ManaBar manaBar;
    public StaminaBar staminaBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = playerStats.maxHealth;
        currentMana = playerStats.maxMana;
        currentStamina = playerStats.maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            DealHealthDamage(20);
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            DealManaDamage(30);
        }
        if (Input.GetKeyDown(KeyCode.Backslash))
        {
            DealStaminaDamage(30);
        }
    }

    void DealHealthDamage(int damage)
    {
        playerStats.currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    void DealManaDamage(int damage)
    {
        playerStats.currentMana -= damage;

        manaBar.SetMana(currentMana);
    }

    void DealStaminaDamage(int damage)
    {
        playerStats.currentStamina -= damage;

        staminaBar.SetStamina(currentStamina);
    }

    */
}
