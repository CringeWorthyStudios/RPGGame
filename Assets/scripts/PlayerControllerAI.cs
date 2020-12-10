using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(CharacterController))]

public class PlayerControllerAI : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 1;
    public float gravity = -9.81f;

    private Vector3 velocity;

    public float mouseSensitivity = 100f;
    private float xRotation = 0f;

    public Camera camera;

    //-----------------------------------------

    public float maxHealth = 100f;
    public float currentHealth;

    public HealthBar healthBar;

    public float maxStamina = 100f;
    public float currentStamina;

    public StaminaBar staminaBar;

    public float maxMana = 100f;
    public float currentMana;

    public ManaBar manaBar;


    public Text text;

    public GameObject objectText;
    public GameObject deathScreen;

    public GameObject inventoryWindow;
    public GameObject abilitiesWindow;


    void Start()
    {
        controller = GetComponent<CharacterController>();

        //camera = Camera.main;

        Cursor.lockState = CursorLockMode.Locked;

        currentHealth = maxHealth;
        currentMana = maxMana;
        currentStamina = maxStamina;
    }

    int randomdamage;

    private void Update()
    {
        Move();
        MouseLook();

        if (Input.GetKeyDown(KeyCode.Equals))
        {
            randomdamage = Random.Range(0, 30);
            TakeHealthDamage(randomdamage);
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            randomdamage = Random.Range(0, 35);
            TakeManaDamage(randomdamage);
        }
        if (Input.GetKeyDown(KeyCode.Backslash))
        {
            randomdamage = Random.Range(0, 50);
            TakeStaminaDamage(randomdamage);
        }

        if (currentHealth <= 0)
        {
            StartCoroutine(DeathScreen());
        }



        if (Input.GetKeyDown(KeyBindScript.keys["Inventory"]))
        {
            Debug.Log("Inventory Open");
            inventoryWindow.SetActive(!inventoryWindow.activeSelf);
        }

        if (Input.GetKeyDown(KeyBindScript.keys["Skills"]))
        {
            Debug.Log("Abilities Open");
            abilitiesWindow.SetActive(!abilitiesWindow.activeSelf);
        }

    }

    IEnumerator DeathScreen()
    {
        deathScreen.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void MouseLook()
    {

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

    }

    private void Move()
    {

        //input -1 to 1
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");




        //direction we want to move in
        Vector3 move = (transform.right * x) + (transform.forward * z);

        velocity.y += gravity * Time.deltaTime;

        controller.Move((velocity + move) * speed * Time.deltaTime);


    }

    IEnumerator DamageEffect()
    {
        objectText.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        objectText.SetActive(false);
    }

    public void TakeHealthDamage(int damage)
    {
        Debug.Log(damage + " Health");

        text.text = damage.ToString();
        text.color = new Color(255, 0, 0);

        StartCoroutine(DamageEffect());

        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    public void TakeManaDamage(int damage)
    {
        Debug.Log(damage + " Mana");

        text.text = damage.ToString();
        text.color = new Color(0, 0, 255);

        StartCoroutine(DamageEffect());

        currentMana -= damage;

        manaBar.SetMana(currentMana);
    }

    public void TakeStaminaDamage(int damage)
    {
        Debug.Log(damage + " Stamina");

        text.text = damage.ToString();
        text.color = new Color(0, 255, 0);

        StartCoroutine(DamageEffect());

        currentStamina -= damage;

        staminaBar.SetStamina(currentStamina);
    }
}