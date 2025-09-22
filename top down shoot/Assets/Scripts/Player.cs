using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    Vector2 moveInput;
    Vector2 screenBoundery;
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float rotationSpeed = 700f;
    [SerializeField] float bulletSpeed = 7f;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject gun;


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
        if (moveInput != Vector2.zero)
        {
         targetAngle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg;
        }

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -screenBoundery.x, screenBoundery.x)
                                    ,    Mathf.Clamp(transform.position.y, -screenBoundery.y, screenBoundery.y));
       
    }

    void FixedUpdate()
    {
        float rotation = Mathf.MoveTowardsAngle(rb.rotation, targetAngle -90, rotationSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(rotation);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        Destroy(gameObject);

    }

}
