using TMPro;
using UnityEngine;
using System;

public class PickUp : MonoBehaviour
{
    public  TextMeshProUGUI score_Ui; 
    public event Action OnPickUpCollected;
    
    private void OnTriggerEnter2D(Collider2D collision){
        

        if (collision.gameObject.CompareTag("Player"))
        {
            
            print("E");
            gameObject.SetActive(false);
            GameManager.score += 50;

            score_Ui.text = "Score: " + GameManager.score;
            
         
        }
    }

    
    
}
