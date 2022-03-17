using UnityEngine.SceneManagement;
using UnityEngine;
using System;


public class Escape : MonoBehaviour
{
    public static bool objColeccted;
    public static event Action PlayerHasEscaped;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // call for an action in the gameManager script
            PlayerHasEscaped?.Invoke();
        }
    }


}
