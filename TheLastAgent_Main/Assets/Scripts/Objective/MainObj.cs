using UnityEngine;
using TMPro;


public class MainObj : MonoBehaviour
   
{
    public  TextMeshProUGUI score_Ui;
    // Start is called before the first frame update

    [SerializeField] private GameObject _escapePoint;
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Player"))
        {

            _escapePoint.SetActive(true);
            gameObject.SetActive(false);
            GameManager.score += 100;
            score_Ui.text = "Score: " + GameManager.score;

        }
    }
}
