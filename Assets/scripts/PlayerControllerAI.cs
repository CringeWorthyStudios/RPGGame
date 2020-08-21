using System.Collections;
using System.Collections.Generic;
using UnityEngine;



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


    void Start()
    {
        controller = GetComponent<CharacterController>();

        //camera = Camera.main;

        Cursor.lockState = CursorLockMode.Locked;

        currentHealth = maxHealth;
    }


    private void Update()
    {
        Move();
        MouseLook();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
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

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

}