using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private static MainObj _mainObjCollected;
    private static PickUp _pickUpCollected;
    [SerializeField] public static int score = 0;

    private void Start()
    {
        _mainObjCollected = GetComponent<MainObj>();
        _pickUpCollected = GetComponent<PickUp>();
    }



    private void OnEnable() {
        _pickUpCollected.OnPickUpCollected += LoadNextLevel; }
    private void OnDisable() { Debug.Log("Test disable"); _pickUpCollected.OnPickUpCollected -= LoadNextLevel; }
    
    private void LoadNextLevel()
    {
        Debug.Log("Test");

        
        


    }

    

}
