using System;
using Pathfinding;
using UnityEngine.AI;
using UnityEngine.Audio;
using UnityEngine;

public class EnemyAgro : MonoBehaviour

{
    IAstarAI agent;

    #region Private veriables
    private float _fovAngle = 80f;
    [SerializeField] private Transform _fovPoint;
    private float _range = 7;
    [SerializeField] private Transform _target;
    [SerializeField] private Transform[] _patrolRoots;
    [SerializeField] private AudioSource alert;
    public bool playerSeen;
    private int index;
    #endregion 

 
    void Start()
    {
        agent = GetComponent<IAstarAI>();
        alert = GetComponent<AudioSource>();

    }
    void Update()
    {
        #region raycaster
        // determine direction to target
        Vector2 dir = _target.position - transform.position;
        // determine angle to target vector
        float angle = Vector2.Angle(dir, _fovPoint.up);
        // cast ray towards target
        RaycastHit2D hit = Physics2D.Raycast(_fovPoint.position, dir, _range);

        // if ray intersects with object

        //check the ray result is not null
        if (hit)
        {
            //check the player is in the rays angle 
            if (angle < _fovAngle / 2)
            {
                // checks if the ray hit the player 
                if (hit.collider.CompareTag("Player"))
                {
                    // plays sound affect only when the player is seen from being out of enemys sight
                    if (!playerSeen)
                    {
                        alert.Play();
                    }
                    playerSeen = true;
                    // draws the ray from the enemy to the player
                    Debug.DrawRay(_fovPoint.position, dir, Color.red);
                }
                // turns playerSeen to false when the payer is behind a wall
                else
                {
                   
                    playerSeen = false;
                }
            }
            // turns playerSeen to false if it leaves the enmies field of view
            else if (playerSeen)
            { playerSeen = false; }
        }


        // white box test
        else if (playerSeen)
        {
            playerSeen = false;
        }
        
        
        
        #endregion

        #region chase player
        if (playerSeen)
        {
            // set the traget of the enemy to the location of the player
            agent.destination = _target.position;
            agent.SearchPath();
            // increases the speed of the enemy when chasing the player
            agent.maxSpeed = 6;
        }
        #endregion

        #region patroll 
        else if (playerSeen == false) {
            // set player speed to a slower speed when not chasing the player
            agent.maxSpeed = 3.5f;
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
            
        
    

