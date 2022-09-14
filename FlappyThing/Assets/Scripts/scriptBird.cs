using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptBird : MonoBehaviour
{
    // Potencia del salto
    [SerializeField] private int jumpForce = 6;

    private Rigidbody2D playerPhysics;
    private SpriteRenderer playerSprite;

    [SerializeField] private Sprite bird;
    [SerializeField] private Sprite birdJump;

    public AudioSource birdSound;
    private AudioSource brdSnd;
    public AudioClip jumpSound;

    public GameObject gameHandler;
    private GameObject handler;
    private scriptGameHandler scriptHandler;

    private bool firstJump = false;


    // Start is called before the first frame update
    void Start()
    {
        playerPhysics = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();

        brdSnd = Instantiate(birdSound);

        brdSnd.enabled = true;

        // Genera una instancia del Game Handler para enterarse del estado del juego
        handler = Instantiate(gameHandler);
    }

    float timer;

    // Update is called once per frame
    void Update()
    {
        // Extrae el script del handler instanciado
        scriptHandler = handler.GetComponent<scriptGameHandler>();

        // Si está en el menú, va a realizar una animación de salto automática
        if (scriptHandler.status == "menu" && transform.position.y < 0 && timer > 0.5f) 
        {
            Jump();
            timer = 0;
        } else
        {
            timer += Time.deltaTime;
        }

        // Si está jugando, permanece atento a la acción de salto
        if (scriptHandler.status == "play")
        {
            if (!firstJump)
            {
                Jump();
                firstJump = true;
            }
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                Jump();
            }
        }

        if (playerPhysics.velocity.y > 0)
        {
            playerSprite.sprite = birdJump;
        }
        else
        {
            playerSprite.sprite = bird;
        }
    }

    void Jump()
    {
        float compensation = 0;
        if (playerPhysics.velocity.y < 0)
        {
            compensation = playerPhysics.velocity.y * -1;
        }
        playerPhysics.AddForce(Vector2.up * (jumpForce + compensation), ForceMode2D.Impulse);

        brdSnd.clip = jumpSound;
        brdSnd.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            scriptHandler.GameOver(gameObject);
        }

        if (collision.tag == "Score")
        {
            scriptHandler.updateScore();
        }
    }
}
