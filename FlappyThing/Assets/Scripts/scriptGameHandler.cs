using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class scriptGameHandler : MonoBehaviour
{

    public float speed;
    public string status;

    public GameObject wall;

    public AudioSource deathSoundImp;
    private AudioSource deathSound;
    public AudioClip deathClip;

    // UI Imports
    public Canvas canvasImp;
    public TMP_Text textScoreImp;

    public TMP_Text menuTitleImp;
    public RectTransform menuPanelImp;
    public Button menuButtonImp;

    public GameObject gameOverPanelsImp;
    public Button gameOverButtonImp;

    // UI
    private Canvas canvas;

    // Score
    private TMP_Text textScore;
    public float score;

    // Menu
    private TMP_Text menuTitle;
    private RectTransform menuPanel;
    private Button menuButton;

    // Game Over
    private GameObject gameOverPanels;
    public Button gameOverButton;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        status = "menu";

        // Instanciar los elementos del menú
        menuTitle = Instantiate(menuTitleImp);
        menuPanel = Instantiate(menuPanelImp);
        menuButton = Instantiate(menuButtonImp);
        canvas = Instantiate(canvasImp);

        // Asignar los elementos al canvas
        menuPanel.transform.SetParent(canvas.transform, false);
        menuTitle.transform.SetParent(canvas.transform, false);
        menuButton.transform.SetParent(canvas.transform, false);

        // Asigna la funcionalidad al botón de inicio
        menuButton.onClick.AddListener(GameStart);

        // Activa el sonido de muerte para cuando corresponda reproducirlo
        deathSound = Instantiate(deathSoundImp);
        deathSound.enabled = true;
    }

    // Timer para controlar la aparición de las paredes
    float wallTimer;

    // Update is called once per frame
    void Update()
    {
        if (status == "play")
        {
            if (wallTimer >= 1f)
            {
                CreateWall();
                wallTimer = 0;
            }
            else
            {
                wallTimer += Time.deltaTime;
            }
        }
    }

    // Cambiar el estado del juego para que empiecen a aparecer los objetos
    public void GameStart()
    {
        status = "play";

        // Elimina los objetos dentro del canvas
        foreach (Transform child in canvas.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        textScore = Instantiate(textScoreImp);

        textScore.transform.SetParent(canvas.transform, false);
    }

    // Cuando el jugador se choca
    public void GameOver(GameObject bird)
    {
        if (status == "play")
        {
            status = "dead"; // Cambia el estado
            
            // Instancia los elementos del UI de game over
            gameOverPanels = Instantiate(gameOverPanelsImp);
            gameOverButton = Instantiate(gameOverButtonImp);

            // Añade los elementos al canvas
            gameOverPanels.transform.SetParent(canvas.transform, false);
            gameOverButton.transform.SetParent(canvas.transform, false);

            // Asigna el listener al botón
            gameOverButton.onClick.AddListener(RestartGame);

            // Asigna el sonido al AudioSource y lo reproduce
            deathSound.clip = deathClip;
            deathSound.Play();

            // Elimina al pájaro
            Destroy(bird);
        }
    }

    // Reiniciar la escena
    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Actualizar el puntaje
    public void updateScore()
    {
        score++;
        textScore.text = score.ToString();
    }

    // Generar las nuevas paredes
    private void CreateWall()
    {
        GameObject newWall = Instantiate(wall);
    }


}