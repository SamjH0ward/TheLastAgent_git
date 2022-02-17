using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgro : MonoBehaviour
{
    [SerializeField] Transform player;

    [SerializeField] float agroRange;

    [SerializeField] float moveSpeed;

    Rigidbody2D rb2d;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //distance to player 
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        Debug.Log(distToPlayer);

        if(distToPlayer < agroRange)
        {
            ChasePlayer();
        }
        else
        {
            StopChasingPlayer();
        }
    }

    private void StopChasingPlayer()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(aimPoint) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        playerLight.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void ChasePlayer()
    {
        throw new NotImplementedException();
    }
}
