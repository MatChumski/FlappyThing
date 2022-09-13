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

    float wallTimer;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        status = "menu";

        menuTitle = Instantiate(menuTitleImp);
        menuPanel = Instantiate(menuPanelImp);
        menuButton = Instantiate(menuButtonImp);

        canvas = Instantiate(canvasImp);

        menuPanel.transform.SetParent(canvas.transform, false);
        menuTitle.transform.SetParent(canvas.transform, false);
        menuButton.transform.SetParent(canvas.transform, false);

        menuButton.onClick.AddListener(GameStart);

        deathSound = Instantiate(deathSoundImp);
        deathSound.enabled = true;
    }

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

    public void GameStart()
    {
        status = "play";

        foreach (Transform child in canvas.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        textScore = Instantiate(textScoreImp);

        textScore.transform.SetParent(canvas.transform, false);
    }
    public void GameOver(GameObject bird)
    {
        if (status == "play")
        {
            status = "dead";

            gameOverPanels = Instantiate(gameOverPanelsImp);
            gameOverButton = Instantiate(gameOverButtonImp);

            gameOverPanels.transform.SetParent(canvas.transform, false);
            gameOverButton.transform.SetParent(canvas.transform, false);

            gameOverButton.onClick.AddListener(RestartGame);

            deathSound.clip = deathClip;
            deathSound.Play();

            Destroy(bird);
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void updateScore()
    {
        score++;
        textScore.text = score.ToString();
    }

    private void CreateWall()
    {
        GameObject newWall = Instantiate(wall);
    }


}