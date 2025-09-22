using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float moveSpeed = 10f;
    Rigidbody2D rb;
    Vector2 direction;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
          rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;

        if (player == null)
        {
            Destroy(gameObject);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            direction = (player.position - transform.position).normalized;

        }
        else
        {
            Destroy(gameObject);
        }
    }
        void FixedUpdate()
        {
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
        }
    
}
