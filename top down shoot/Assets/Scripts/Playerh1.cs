using System;
using UnityEngine;

public class Playerh1 : MonoBehaviour
{
    [SerializeField] Transform player;
    int Health;
    Player playerScript;
    Renderer ren;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
        ren = GetComponent<Renderer>();
       
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
        if (Health == 0)
        {
            Console.Write("0 Health");

           ren.enabled = false;
           
        }
    }
}
