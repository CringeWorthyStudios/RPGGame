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


    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DealDamage(20);
        }
    }

    void DealDamage(int damage)
    {
        playerStats.currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
