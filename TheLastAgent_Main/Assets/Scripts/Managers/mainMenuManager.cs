using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class mainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject _mainMenu;
    [SerializeField] GameObject _howToPlay;
    public void OnClickStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single );
    }

    public void HowToPlay()
    {
        _howToPlay.SetActive(true);
        gameObject.SetActive(false);
    }

    public void MainMenu()
    {
        _mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
