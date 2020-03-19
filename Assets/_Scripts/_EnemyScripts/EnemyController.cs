﻿/*
 * The EnemyController controls the AI movement of an Enemy
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;  // The radius at which the enemy will look

    Transform target;               // The target of the enemy
    NavMeshAgent agent;             // The mesh that the enemy can see within

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        target = PlayerStats.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // Finding the distance from the enemy to the player
        float distance = Vector3.Distance(target.position, transform.position);

        // If the distance of the enemy to the player is within the radius of the mesh than move towards the player
        if(distance <= lookRadius){
            agent.SetDestination(target.position);

            // Setting the stopping distance from the player
            if(distance <= agent.stoppingDistance ){
                // Attack the target
                FaceTarget();
            }
        }
    }

    /// <summary>
    /// In order for the enemy to face the target it must rotate accordingly
    /// </summary>
    void FaceTarget(){
        // Necessary direction and rotation needed to look at player
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        // To the turning within a certain delta time
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    /// <summary>
    /// Draw the mesh around the enemy
    /// </summary>
    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
