using UnityEngine;
using System;

public class PickUp : MonoBehaviour
{
    
    public static event Action onPickUpCollected;
    private void OnTriggerEnter2D(Collider2D collision){
      
        if (collision.gameObject.CompareTag("Player"))
        {
            // call for an action in the gameManager script
            onPickUpCollected?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
