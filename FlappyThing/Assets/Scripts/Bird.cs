using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    public GameObject player;

    private int jumpForce = 6;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Rigidbody2D playerPhysics = player.GetComponent<Rigidbody2D>();
        float compensation = 0;
        if (playerPhysics.velocity.y < 0)
        {
            compensation = playerPhysics.velocity.y * -1;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerPhysics.AddForce(Vector2.up * (jumpForce + compensation), ForceMode2D.Impulse);
        }
    }
}
