using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainObj : MonoBehaviour
{
    // Start is called before the first frame update
    public event Action OnMainObj;
    [SerializeField] private GameObject test;
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Player"))
        {

            test.SetActive(true);
            gameObject.SetActive(false);
            GameManager.score += 100;
           
        }
    }
}
