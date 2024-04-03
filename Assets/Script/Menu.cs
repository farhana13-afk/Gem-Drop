using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    public int score;
    public int dropped; 
    private int highscore;
    private bool gameEnd; 
    private bool gameStart; 
    private bool gamePause; 
    private float timerTime; 
    public GameObject panel;
    public TextMeshProUGUI scoreText; 
    public TextMeshProUGUI timeText; 
    public TextMeshProUGUI whatText; 
    public Button start; 
    public Button pause; 
    public Button continues; 
    public Button quit; 
    public Button restart; 
    public TextMeshProUGUI highScoreText; 
    public TextMeshProUGUI finalScoreText; 
    public TextMeshProUGUI droppedText; 
    public TextMeshProUGUI startedNew; 


    // Start is called before the first frame update
    void Start()
    {
        score = 0; 
        timerTime = 60.0f; 
        dropped = 0; 
        gameStart = false; 
        gamePause = false; 
        gameEnd = false; 
        highscore = PlayerPrefs.GetInt("highscore", highscore);

        quit.gameObject.SetActive(false); 
        panel.SetActive(true);
        continues.gameObject.SetActive(false);
        pause.gameObject.SetActive(false);
        restart.gameObject.SetActive(false);
        highScoreText.text = "";
        scoreText.text = "";
        timeText.text = "";
        finalScoreText.text = "";
        droppedText.text = ""; 
        startedNew.text = ""; 
        whatText.text = "START GAME!";
        Time.timeScale = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        
        if(gameStart)
        {
            //displaying score while playing
            scoreText.text = "Score: "+ score; 

            timeText.text = "Time Left: "+ Mathf.Round(timerTime) +"s"; 
            timerTime -= Time.deltaTime; 
            Time.timeScale = 1; 
            finalScoreText.text ="";
            startedNew.text = ""; 
            whatText.text = "";
            highScoreText.text = "";
            droppedText.text = "";
            panel.gameObject.SetActive(false);
            pause.gameObject.SetActive(true);    
            restart.gameObject.SetActive(false);
            continues.gameObject.SetActive(false);
            quit.gameObject.SetActive(false); 
            gamePause = false; 
        }

        if(gamePause)
        {
            pause.gameObject.SetActive(false);
            gameStart = false; 
            Time.timeScale = 0;
            whatText.text = "PAUSED!";
            panel.gameObject.SetActive(true);
            continues.gameObject.SetActive(true);
            quit.gameObject.SetActive(true);  
            restart.gameObject.SetActive(true);

            ///displaying score while paused
            finalScoreText.text = "Score: " + score;
            droppedText.text = "Dropped: "+ dropped; 

        }

        if(timerTime <= 0.0f)
        {
            gameStart = false; 
            gameEnd = true; 
        }
        
        if(gameEnd)
        {
            Time.timeScale = 0;     
            scoreText.text = "";   
            quit.gameObject.SetActive(true);
            pause.gameObject.SetActive(false);     
            restart.gameObject.SetActive(true);
            panel.SetActive(true);
            highScoreText.text = "HighScore: " + highscore;

            ///displaying score while ended
            finalScoreText.text = "Score: " + score;
            droppedText.text = "Dropped: "+ dropped; 

            whatText.text = "GAME ENDED";
             if(score > highscore)
             {
                highscore = score; 
                startedNew.text = "SET A NEW HIGHSCORE!"; 
                PlayerPrefs.SetInt("highscore", highscore);
             }
             else if(score > 0)
             {
                startedNew.text = "YOU SURVIVED!";
             }
             else if(score< 0)
             {
                startedNew.text = "YOU LOST!";
             }
             else if(score == 0)
             {
                startedNew.text = "Could Have Done Better!";
             }
        }

    }

    public void OnClickStart()
    {
        gameStart = true;  
        timerTime = 60.0f; 
        start.gameObject.SetActive(false);
    }
    
    public void OnClickQuit()
    {
        
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    public void OnClickPause()
    {
        gameStart = false; 
        gamePause = true; 

    }
    public void OnClickContinue()
    {
        gameStart = true; 
        gamePause = false; 
    }

    public void OnClickRestart()
    {
        gameEnd = false; 
        gameStart = true; 
        gamePause = false; 
        gameStart = true;  
        timerTime = 60.0f; 
        start.gameObject.SetActive(false);
        score = 0; 
        dropped = 0; 
    }
}
