using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class MenuManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _finaleScore;
    

    // Start is called before the first frame update

    private void Awake()
    {
        _finaleScore.text = "Final score: " + GameManager.score;
    }

    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Retry()
    {
        Debug.Log("retry");
        GameManager.score = 0;
        SceneManager.LoadScene("LevelOne", LoadSceneMode.Single);
    }
}
