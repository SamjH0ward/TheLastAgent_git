using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    private int _score = 0;
    private PickUp score;

    protected virtual void Awake()
    {
        score = GetComponent<PickUp>();
    }

    private void OnEnable() => score.OnPickUpCollected += PickUpCollected;
    private void OnDisable() => score.OnPickUpCollected -= PickUpCollected;

    private void PickUpCollected()
    {
        _score += 1;
        Debug.Log("The current score is " + _score.ToString());
    }


}
