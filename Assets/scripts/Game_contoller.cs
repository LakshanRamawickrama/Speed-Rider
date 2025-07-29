using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_contoller : MonoBehaviour
{
    public Text highScoreText;
    public Text scoreText;

    public int score;
    public int highScore;

    public Score_Manager score_manager;

    public GameObject gamePausePanel;

    public Audio_Manager am;
     

    
    // Start is called before the first frame update
    void Start()
    {
        gamePausePanel .SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        highScore = PlayerPrefs.GetInt("high_score");
        score = score_manager.score;

        highScoreText .text = "Highscore: " + highScore.ToString();
        scoreText .text = "You Score: "  + score.ToString();

    }

    
    

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void Pause()
    {
        Time.timeScale = 0;
        gamePausePanel .SetActive(true);
        
        if(Time .timeScale == 0)
        {
            am.carSound.Pause();
        }
        
        
        
    }

    public void Resume()
    { 
        Time .timeScale = 1;
        gamePausePanel .SetActive(false);

        if (Time .timeScale == 1)
        {
            am.carSound .UnPause();
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteAll();
    }
}
