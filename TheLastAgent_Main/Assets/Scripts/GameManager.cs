using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    //private static Escape _playerEscaped;
    private static PickUp _pickUpCollected;
    private int score = 0;
    private int scoreThisAttempt = 0;
    [SerializeField] private TextMeshProUGUI score_Ui;
    [SerializeField] private TextMeshProUGUI lives_Ui;
    [SerializeField] private GameObject _escapePoint;
    private int lives = 3;

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        score -= scoreThisAttempt;
        scoreThisAttempt = 0;  
        lives_Ui.text = "Lives" + lives;
    }
    

}
