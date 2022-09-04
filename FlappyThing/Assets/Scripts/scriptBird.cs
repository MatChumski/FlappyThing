using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptBird : MonoBehaviour
{
    
    [SerializeField]
    private int jumpForce = 6;

    Rigidbody2D playerPhysics;
    public GameObject gameHandler;

    // Start is called before the first frame update
    void Start()
    {
        playerPhysics = GetComponent<Rigidbody2D>();  
        
        GameObject handler = Instantiate(gameHandler);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float compensation = 0;
            if (playerPhysics.velocity.y < 0)
            {
                compensation = playerPhysics.velocity.y * -1;
            }
            playerPhysics.AddForce(Vector2.up * (jumpForce + compensation), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            //Destroy(transform.root.gameObject);
        }

        if (collision.tag == "Score")
        {
            Debug.Log("score");
        }
    }
}
