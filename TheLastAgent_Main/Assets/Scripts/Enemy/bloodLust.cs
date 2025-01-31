using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodLust : MonoBehaviour
{
    public EnemyAgro chasing;
    public float bloodLustTime = 0;
    private float display;

    // Start is called before the first frame update
    void Start()
    {
        chasing = GetComponent<EnemyAgro>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (chasing.playerSeen == true)
        {
            bloodLustTime += Time.deltaTime;
            
            Debug.Log(bloodLustTime);
        }
        else { bloodLustTime = 0; }
        
    }
}
