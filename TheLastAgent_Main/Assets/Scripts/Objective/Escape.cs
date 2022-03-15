using UnityEngine.SceneManagement;
using UnityEngine;
using System;


public class Escape : MonoBehaviour
{
    public static bool objColeccted;
    public static event Action PlayerHasEscaped;

   


    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHasEscaped?.Invoke();

        }
    }
    // Update is called once per frame

}
