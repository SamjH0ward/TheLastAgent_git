using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    //private static Escape _playerEscaped;
    private static PickUp _pickUpCollected;
    private static int score;
    private int scoreThisAttempt = 0;
    [SerializeField] private TextMeshProUGUI score_Ui;
    [SerializeField] private TextMeshProUGUI lives_Ui;
    [SerializeField] private GameObject _escapePoint;
    private Vector2 playerLocation;
    [SerializeField] private GameObject player;
    private static int lives = 3;
    private GameObject[] test;

    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }


    private void Awake()
    {
        playerLocation = player.transform.position;
        test = GameObject.FindGameObjectsWithTag("PickUp");
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
        

    private GameObject[] tests;

    private void Start()
    {
        //_playerEscaped = GetComponent<Escape>();
        //_pickUpCollected = GetComponent<PickUp>();
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

        foreach (GameObject i in test)
        {
            Debug.LogWarning(i);
            i.SetActive(true);
        }

        player.transform.position = playerLocation;
        
        
        lives_Ui.text = "Lives: " + lives;
        score_Ui.text = "Score: " + score; 
    }
    

}
