using UnityEngine;
using System;
public class playerCaught : MonoBehaviour
{
    public static event Action OnPlayerCaught;
    private void OnTriggerEnter2D(Collider2D collision)
    {
       

        if (collision.gameObject.CompareTag("Player"))
        {
            OnPlayerCaught?.Invoke();
            gameObject.SetActive(false);
            
        }
    }

}
