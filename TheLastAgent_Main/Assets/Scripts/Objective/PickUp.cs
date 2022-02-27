
using UnityEngine;
using System;

public class PickUp : MonoBehaviour
{
    public event Action OnPickUpCollected;
    private void OnTriggerEnter2D(Collider2D collision){
        

        if (collision.gameObject.CompareTag("Player"))
        {
            Escape.objcoleccted = true;
            gameObject.SetActive(false);
            GameManager.score += 50;
         
        }
    }

    
    
}
