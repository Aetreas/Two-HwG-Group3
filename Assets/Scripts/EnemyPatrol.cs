using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour //this is a dead script pretty much, but keeping it around just in case
{
    public Transform[] patrolPoints;
    public int targetPoint; //next waypoint
    public float speed;

    public float rotationspeed;

    // Start is called before the first frame update
    void Start()
    {
        targetPoint = 0;
    }

    // Update is called once per frame
    void Update()
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
