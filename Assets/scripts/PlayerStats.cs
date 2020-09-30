using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStats
{
    [Header("PlayerMovement")]
    public float speed = 6f;
    public float sprintSpeed = 12f;
    public float crouchSpeed = 3f;
    public float jumpHeight = 1.0f;

    [Header("Current Stats")]
    public int level;
    public float maxHealth = 100;
    public float currentHealth = 100;
    public float maxMana = 100;
    public float currentMana = 100;
    public float maxStamina = 100;

    private float _currentHealth = 100;
    public float CurrentHealth
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = value;
            if(healthHearts != null)
            {
                healthHearts.UpdateHearts(value, maxHealth);
            }
        }
    }

    public float[] position; // = Vector3
    public PlayerStats(Player player)
    {
        level = player.level;
        maxHealth = player.health;
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }

    public QuarterHearts healthHearts;
}
