using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PickUp : MonoBehaviour
{
    public event Action OnPickUpCollected;
    private void OnTriggerEnter2D(Collider2D collision){
        

        if (collision.gameObject.CompareTag("Player"))
        {
            OnPickUpCollected?.Invoke();
            gameObject.SetActive(false);
            
        }
    }

    
}
