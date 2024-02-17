using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius;
    [Range(0,360)]//limits angle in editor
    public float angle;

    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;
    public Transform[] patrolPoints;
    public Transform playerPos;


    public int targetPoint; //next waypoint
    public float speed;
    public float MaxSpeed;

    public float rotationspeed;

    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
        targetPoint = 0;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if(canSeePlayer == true)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, playerPos.position, 10 * Time.deltaTime);
            var targetRotation = Quaternion.LookRotation(playerPos.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationspeed * Time.deltaTime);
        }

        else
        {
            Invoke("patrolMovement", 0.1f);
        }
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    public void FieldOfViewCheck()//detects player character
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    canSeePlayer = true;
                else
                    canSeePlayer = false;
            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;
    }

        void patrolMovement()
        {
            if(transform.position == patrolPoints[targetPoint].position)
        {
            increaseTargetInt();
        }
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);

        

        var targetRotation = Quaternion.LookRotation(patrolPoints[targetPoint].transform.position - transform.position);
        
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationspeed * Time.deltaTime);
        }

        void increaseTargetInt() //continues patrol movement
    {
        targetPoint++; 
        if(targetPoint >= patrolPoints.Length) // prevents overflow and sends enemy back to start
        {
            targetPoint = 0;
        }
    }
}