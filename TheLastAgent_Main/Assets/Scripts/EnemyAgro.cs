using System;

using UnityEngine;

public class EnemyAgro : MonoBehaviour

{
    public float fovAngle = 60f;
    public Transform fovPoint;
    public float range = 8;

    public Transform target;
    public bool playerSeen;

   void Update()
    {
        Vector2 dir = target.position - transform.position;
        float angle = Vector3.Angle(dir, fovPoint.up);
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
                print("We dont see");
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
        throw new NotImplementedException();
    }
}
