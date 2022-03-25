using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    NavMeshAgent agent; // Reference to our agent

    Transform target; // Target to follow

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Target to follow
        if (target != null)
        {
            agent.SetDestination(target.position);
            FaceTarget();
        }
    }

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    // Target to follow
    public void FollowTarget(Interactable newTarget)
    {
        agent.stoppingDistance = newTarget.radius * .8f; // player with shop within distance
        agent.updateRotation = false;

        target = newTarget.interactionTransform;
    }

    // Target to follow
    public void StopFollowingTarget()
    {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;

        target = null;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
