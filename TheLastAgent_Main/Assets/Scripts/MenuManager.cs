using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _finaleScore;
    [SerializeField] private TextMeshProUGUI _title;
    // Start is called before the first frame update
    private void Awake()
    {
        if (GameManager.lives > 0)
        {
            _title.text = "Mission completed";
        }
        else
        {
            _title.text = "Game Over";
        }
        _finaleScore.text = "Final score: " + GameManager.score;
    }
    public void Retry()
    {
        GameManager.score = 0;
        SceneManager.LoadScene("LevelOne", LoadSceneMode.Single);
    }
    public void Quit()
    {
        Application.Quit();
    }

}