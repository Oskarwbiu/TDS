using System;
using UnityEngine;

public class Playerh2 : MonoBehaviour
{
    [SerializeField] Transform player;
    Rigidbody2D rb;
    int Health;
    Player playerScript;
    Renderer ren;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        ren = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody2D>();
        try
        {
            player = GameObject.FindWithTag("Player").transform;
            playerScript = player.GetComponent<Player>();
            Health = playerScript.playerHealth;
        }
        catch
        {
            Debug.Log("bad");
        }

    }

    // Update is called once per frame
    void Update()
    {
        Health = playerScript.playerHealth;
        if (Health <= 1)
        {
            Console.Write("1 Health");

            ren.enabled = false;
            Debug.Log("balls");
        }
    }
}
