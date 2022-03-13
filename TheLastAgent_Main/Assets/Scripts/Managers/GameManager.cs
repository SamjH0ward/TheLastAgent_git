using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Audio;


public class GameManager : MonoBehaviour
{
    
    
    public static int score;
    private int scoreThisAttempt = 0;
    [SerializeField] private TextMeshProUGUI score_Ui;
    [SerializeField] private TextMeshProUGUI lives_Ui;
    [SerializeField] private TextMeshProUGUI timer_Ui;
    [SerializeField] private GameObject _escapePoint;
    [SerializeField] private AudioSource _pickUpAudio;
    public static int lives = 3;

  


    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }


    private void Awake()
    {
        _pickUpAudio = GetComponent<AudioSource>();
      
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
        // get the name of the curent sceen
        Scene currenScene = SceneManager.GetActiveScene();
        //check if the user is int the game over screne
        if (currenScene != SceneManager.GetSceneByName("GameOver"))
        {
            // if the user is not int the game over screne hud is displayed a
            score_Ui.text = "Score: " + score;
            lives_Ui.text = "Lives: " + lives;
            // statrs the timer depending on the level the user is on
            if (currenScene == SceneManager.GetSceneByName("LevelOne"))
            {
                Debug.Log(currenScene);
                // starts a timer for 2 minutes and 30 seconds
                StartCoroutine(levelTimer(150));
            }
            else if (currenScene == SceneManager.GetSceneByName("LevelTwo"))
            {

                StartCoroutine(levelTimer(165));
            }
            else
            {
                StartCoroutine(levelTimer(180));
            }
        }

    }



    private void OnEnable()
    {
        //event listeners
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
        // adds and displays new score 
        score += 50;
        scoreThisAttempt += 50;
        score_Ui.text = "Score: " + score;
        //plays the pickup sound affect 
        _pickUpAudio.Play();
    }

   

    private void LoadNextLevel()
    {
        if(lives == 3)
        {
            score += 100;
        }
        else
        {
            lives += 1;
        }
        scoreThisAttempt = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    } 

    private void mainOBJCollected()
    {
        // enables escape point 
        _escapePoint.SetActive(true);
        // adds and displays new score 
        score += 100;
        scoreThisAttempt += 100;
        score_Ui.text = "Score: " + score;

        _pickUpAudio.Play();
    }

    private void playerWasCaught()
    {
         
         lives -= 1;

        // reverts score to score achived on last level   
        score -= scoreThisAttempt;
        scoreThisAttempt = 0;
        // checks if the user still has lives left 
        if (lives > 0) {
            // updates hud and reloads the level
            lives_Ui.text = "Lives: " + lives;
            score_Ui.text = "Score: " + score;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        }
        else
        {
          
            scoreThisAttempt = 0;
            // loads gameover screen
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
    }

    IEnumerator levelTimer(float time)
    {

        int display;
        int mins;
        int secs;
        while (time > 0f)
        {
            time -= Time.deltaTime;
            // seperates time into a diffrent veriable
            display = Mathf.CeilToInt(time);
            // formats time into minute and seconds 
            mins = Mathf.FloorToInt(display / 60);
            secs = Mathf.FloorToInt(display % 60);
            timer_Ui.text = mins + ":" + string.Format("{0:00}", secs);
            yield return null;
        }
        playerWasCaught();
    }




}
