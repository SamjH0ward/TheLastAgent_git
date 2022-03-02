using TMPro;
using UnityEngine;
using System;

public class PickUp : MonoBehaviour
{
    
    public static event Action onPickUpCollected;
    //public event Action OnPickUpCollected;

    private void OnTriggerEnter2D(Collider2D collision){
        

        if (collision.gameObject.CompareTag("Player"))
        {
            onPickUpCollected?.Invoke();
            gameObject.SetActive(false);
          
        }
    }

    
    
}
