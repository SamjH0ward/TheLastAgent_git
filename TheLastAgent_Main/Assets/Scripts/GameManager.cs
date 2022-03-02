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

    private void Start()
    {
        //_playerEscaped = GetComponent<Escape>();
        //_pickUpCollected = GetComponent<PickUp>();
    }



    private void OnEnable()
    {
        Escape.PlayerHasEscaped += LoadNextLevel;
        PickUp.onPickUpCollected += pickUpCollected;
    }
    private void OnDisable()
    {
        Escape.PlayerHasEscaped -= LoadNextLevel;
        PickUp.onPickUpCollected -= pickUpCollected;
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

    

}
