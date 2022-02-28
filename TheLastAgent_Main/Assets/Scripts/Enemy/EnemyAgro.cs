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

    [SerializeField] private Transform target;
    [SerializeField]  private Transform[] _patrolRoots;
    private int index;
    public bool playerSeen;

    private bool chaseing;
    

    void Start()
    {
        agent = GetComponent<IAstarAI>();
        StopChasingPlayer();
        
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
                print("Seen!");
                playerSeen = true;
                Debug.DrawRay(fovPoint.position, dir, Color.red);
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
        if (playerSeen ) { ChasePlayer(); }
        else if (playerSeen == false && chaseing) { StopChasingPlayer(); }
        
    }

   
    private void StopChasingPlayer()
    {
        while (playerSeen == false) {  
        if (_patrolRoots.Length == 0) return;
        bool search = false;
        // Check if the agent has reached the current target.
        // We must check for 'pathPending' because otherwise we might
        // detect that the agent has reached the *previous* target
        // because the new path has not been calculated yet.
        if (agent.reachedDestination && !agent.pathPending)
        {
            index = index + 1;
            search = true;
        }
        // Wrap around to the start of the targets array if we have reached the end of it
        index = index % _patrolRoots.Length;
        agent.destination = _patrolRoots[index].position;
        // Immediately calculate a path to the target.
        // Note that this needs to be done after setting the destination.
        if (search) agent.SearchPath();
        }
    }



    private void ChasePlayer()
    {
        agent.destination = target.position;
        agent.SearchPath();
        chaseing = true;
    }
}
