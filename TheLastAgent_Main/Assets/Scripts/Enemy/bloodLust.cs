using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloodLust : MonoBehaviour
{
    public EnemyAgro chasing;
    private float bloodLustTime = 0;
    private float display;

    // Start is called before the first frame update
    void Start()
    {
        chasing = GetComponent<EnemyAgro>();
    }

    // Update is called once per frame
    void Update()
    {
        while (chasing.playerSeen == true)
        {
            bloodLustTime += Time.deltaTime;
            bloodLustTime = Mathf.CeilToInt(bloodLustTime);
            bloodLustTime = Mathf.FloorToInt(bloodLustTime);
            Debug.Log("Gay");
        }
        bloodLustTime = 0;
    }
}
