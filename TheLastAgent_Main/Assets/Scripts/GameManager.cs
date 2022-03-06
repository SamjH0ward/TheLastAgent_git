using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    
    
    public static int score;
    private int scoreThisAttempt = 0;
    [SerializeField] private TextMeshProUGUI score_Ui;
    [SerializeField] private TextMeshProUGUI lives_Ui;
    [SerializeField] private GameObject _escapePoint;
    private static int lives = 3;

  


    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }


    private void Awake()
    {
        
      
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
        

    

    private void Start()
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("GameOver"))
        {
            score_Ui.text = "Score: " + score;
            lives_Ui.text = "Lives: " + lives;
        }
    }



    private void OnEnable()
    {
        Escape.PlayerHasEscaped += LoadNextLevel;
        PickUp.onPickUpCollected += pickUpCollected;
        MainObj.onMainOBJCollected += mainOBJCollected;
        playerCaught.OnPlayerCaught += playerWasCaught;
    }
    private void OnDisable()
    {
        Escape.PlayerHasEscaped -= LoadNextLevel;
        PickUp.onPickUpCollected -= pickUpCollected;
        MainObj.onMainOBJCollected -= mainOBJCollected;
        playerCaught.OnPlayerCaught -= playerWasCaught;
    }

    private void pickUpCollected()
    {
        score += 50;
        scoreThisAttempt += 50;
        score_Ui.text = "Score: " + score;
    }

   

    private void LoadNextLevel()
    {
        scoreThisAttempt = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    } 

    private void mainOBJCollected()
    {
        _escapePoint.SetActive(true);
        score += 100;
        scoreThisAttempt += 100;
        score_Ui.text = "Score: " + score;
    }

    private void playerWasCaught()
    {
         
         lives -= 1;
     

        score -= scoreThisAttempt;
        scoreThisAttempt = 0;

        if (lives > 0) { 
        lives_Ui.text = "Lives: " + lives;
        score_Ui.text = "Score: " + score;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        }
        else
        {
          
            scoreThisAttempt = 0;
            lives = 3;
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
    }

   
    

}
