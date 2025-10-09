using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    Vector2 moveInput;
    Vector2 screenBoundery;
    public int playerHealth = 5;
    [SerializeField] float invicibleTime = 5f;
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float rotationSpeed = 3000f;
    [SerializeField] float bulletSpeed = 7f;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject gun;

    
    bool invincible;
    float targetAngle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        screenBoundery = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }



    void OnAttack()
    {
        Rigidbody2D playerBullet = Instantiate(bullet, gun.transform.position, gun.transform.rotation).GetComponent<Rigidbody2D>();
        playerBullet.AddForce(gun.transform.up * bulletSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -screenBoundery.x, screenBoundery.x)
                                    , Mathf.Clamp(transform.position.y, -screenBoundery.y, screenBoundery.y));

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePosition.z = transform.position.z;
        Vector2 direction = (mousePosition - transform.position).normalized;
        targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;


    }


    void ResetInvincibility()
        {
        invincible = false;
         }

    void OnCollisionStay2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy") && !invincible)
        {

            if (playerHealth <= 1)
            {
                playerHealth--;
                Destroy(gameObject);
            }
            else
            {
                playerHealth--;
                invincible = true;
                Invoke("ResetInvincibility", invicibleTime);
                Debug.Log(playerHealth);
            }
        }
      
    } 
    void FixedUpdate()
        {
            float rotation = Mathf.MoveTowardsAngle(rb.rotation, targetAngle, rotationSpeed * Time.fixedDeltaTime);
            rb.MoveRotation(rotation);
        }

}
