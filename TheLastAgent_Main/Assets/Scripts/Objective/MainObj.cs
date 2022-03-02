using UnityEngine;
using System;


public class MainObj : MonoBehaviour
   
{
  
    // Start is called before the first frame update
    public static event Action onMainOBJCollected;
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Player"))
        {
            onMainOBJCollected?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
