using UnityEngine;
using System;


public class MainObj : MonoBehaviour
{
    public static event Action onMainOBJCollected;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // call for an action in the gameManager script
            onMainOBJCollected?.Invoke();

            gameObject.SetActive(false);
        }
    }
}
