using UnityEngine;
using UnityEngine.SceneManagement;


public class mainMenuManager : MonoBehaviour
{
    // change test
    [SerializeField] GameObject _mainMenu;
    [SerializeField] GameObject _howToPlay;
    public void OnClickStart()
    {
        //loads first level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single );
    }

    public void HowToPlay()
    {
        // displays the how to play menue and hides the main menu
        _howToPlay.SetActive(true);
        gameObject.SetActive(false);
    }

    public void MainMenu()
    {
        // displays the main menu and hides th how to play screen
        _mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
