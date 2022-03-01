using System;
using Pathfinding;
using UnityEngine.AI;
using UnityEngine;

public class EnemyAgro : MonoBehaviour

{
    IAstarAI agent;

    #region Private veriables
    private float _fovAngle = 80f;
    [SerializeField] private Transform _fovPoint;
    private float _range = 8;
    [SerializeField] private Transform _target;
    [SerializeField] private Transform[] _patrolRoots;
    private bool playerSeen;
    private int index;
    #endregion 

 
    void Start()
    {
        agent = GetComponent<IAstarAI>();


    }
    void Update()
    {
        #region raycaster
        Vector2 dir = _target.position - transform.position;
        float angle = Vector2.Angle(dir, _fovPoint.up);
        RaycastHit2D r = Physics2D.Raycast(_fovPoint.position, dir, _range);

        if (angle < _fovAngle / 2)
        {
            if (r.collider.CompareTag("Player"))
            {

                playerSeen = true;
                Debug.DrawRay(_fovPoint.position, dir, Color.red);
            }
            else
            {

                playerSeen = false;
            }
        }
        else if (playerSeen)
        {
            playerSeen = false;

        }
        #endregion

        #region chase player
        if (playerSeen)
        {
            agent.destination = _target.position;
            agent.SearchPath();
            agent.maxSpeed = 6.5f;
        }
        #endregion

        #region patroll 
        else if (playerSeen == false) {
            agent.maxSpeed = 4;
            if (_patrolRoots.Length == 0) return;
            bool search = false;

            // Checks if the agent has reached the current target.
            if (agent.reachedDestination && !agent.pathPending)
            {
                index += 1;
                search = true;
            }
            // Wrap around to the start of the targets array if its reached the end
            index %= _patrolRoots.Length;
            agent.destination = _patrolRoots[index].position;
            // Immediately calculate a path to the target.
            if (search) agent.SearchPath();
        }
        #endregion 
    }
}
            
        
    

