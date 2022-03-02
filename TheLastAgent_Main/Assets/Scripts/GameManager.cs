using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    //private static Escape _playerEscaped;
    private static PickUp _pickUpCollected;
    [SerializeField] public static int score = 0;
    [SerializeField] private TextMeshProUGUI score_Ui;
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
    }
    private void OnDisable()
    {
        Escape.PlayerHasEscaped -= LoadNextLevel;
        PickUp.onPickUpCollected -= pickUpCollected;
        MainObj.onMainOBJCollected -= mainOBJCollected;
    }

    private void pickUpCollected()
    {
        score += 50;
        score_Ui.text = "Score: " + GameManager.score;
    }

   

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    } 

    private void mainOBJCollected()
    {
        _escapePoint.SetActive(true);
        score += 100;
        score_Ui.text = "Score: " + GameManager.score;
    }

    

}
