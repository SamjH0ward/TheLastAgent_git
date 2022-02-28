using UnityEngine.SceneManagement;
using UnityEngine;
using System;


public class Escape : MonoBehaviour
{
    public static bool objcoleccted;
    public event Action PlayerHasEscaped;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);

        }
    }
    // Update is called once per frame

}
