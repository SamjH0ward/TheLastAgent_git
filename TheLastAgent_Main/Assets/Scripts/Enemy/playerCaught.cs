using UnityEngine;
using System;
public class playerCaught : MonoBehaviour
{
    public static event Action OnPlayerCaught;
    private void OnTriggerEnter2D(Collider2D collision)
    {
       

        if (collision.gameObject.CompareTag("Player"))
        {
            // call for an action in the gameManager script
            OnPlayerCaught?.Invoke();
        }
    }

}
