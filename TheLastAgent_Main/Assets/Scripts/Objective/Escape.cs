using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Escape : MonoBehaviour
{
    public static bool objcoleccted;
    private bool escapeopend;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("LevelTwo", LoadSceneMode.Single);

        }
    }
    // Update is called once per frame
    private void Awake()
    {
        Debug.Log("Test");
    }
}
