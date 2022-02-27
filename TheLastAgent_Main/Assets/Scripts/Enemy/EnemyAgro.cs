using System;
using Pathfinding;
using UnityEngine.AI;
using UnityEngine;

public class EnemyAgro : MonoBehaviour

{
    IAstarAI agent;

    public float fovAngle = 60f;
    public Transform fovPoint;
    public float range = 8;

    public Transform target;
    public bool playerSeen;
    

    void Start()
    {
        GetComponent<IAstarAI>();
        
    }
   void Update()
    {
        Vector2 dir = target.position - transform.position;
        float angle = Vector2.Angle(dir, fovPoint.up);
        RaycastHit2D r = Physics2D.Raycast(fovPoint.position, dir, range);

        if (angle < fovAngle / 2)
        {
            if (r.collider.CompareTag("Player"))
            {
                //print("Seen!");
                playerSeen = true;
                //Debug.DrawRay(fovPoint.position, dir, Color.red);
            }
            else
            {
                print("I can't see you");
                playerSeen = false;
            }
        }
        else if (playerSeen)
        {
            playerSeen = false;
            print("dont see");
        }
        
    }

   
    private void StopChasingPlayer()
    {
       
    }



    private void ChasePlayer()
    {
    }
}
