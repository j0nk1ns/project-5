using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed = 0f;
    public float turnSpeed = 0f;
    public float RotateSpeed = 0F;

    private float horizontalInput;
    private float forwardInput;

    private float xRange = 25.0f;
    private float zRange = 25.0f;

    public int maxHealth = 5;
    public int Health { get { return currentHealth; } }
    int currentHealth = 5;
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;

 

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Health: " + currentHealth + "/" + maxHealth);
    }
    void FixedUpdate()
    {
  
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up * horizontalInput * turnSpeed * Time.deltaTime);

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * turnSpeed);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3( -xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xRange)
        {
            transform.position = new Vector3( xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }
        else if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            isInvincible = false;
        }
   
    
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if(isInvincible)
            return;

            isInvincible = true;
            invincibleTimer = timeInvincible;

        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log("Health: " + currentHealth + "/" + maxHealth);

    }
}