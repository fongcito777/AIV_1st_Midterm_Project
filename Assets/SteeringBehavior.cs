using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class SteeringBehaviour
{
    NavMeshAgent agent;
    GameObject target;
    Transform transform;
    float wanderAngle = 0;

    public void Init(NavMeshAgent _agent, GameObject _target, Transform _transform)
    {
        agent = _agent;
        target = _target;
        transform = _transform;
    }

    public void Seek(Vector3 location)
    {
        agent.SetDestination(location);
    }

    public void Flee(Vector3 location)
    {
        agent.SetDestination(this.transform.position - (location - this.transform.position));
    }

    public void Pursue()
    {
        Vector3 targetDir = target.transform.position - this.transform.position;
        float lookAhead = targetDir.magnitude / (agent.speed + target.GetComponent<NavMeshAgent>().speed);
        Vector3 pursueLocation = target.transform.position + target.transform.forward * lookAhead * 3;

        if (target.GetComponent<NavMeshAgent>().speed <= 0.01f) {
            Seek(target.transform.position);
        } else {
            Seek(pursueLocation);
        }
    }

    public void Evade()
    {
        Vector3 targetDir = target.transform.position - this.transform.position;
        float lookAhead = targetDir.magnitude / (agent.speed + target.GetComponent<NavMeshAgent>().speed);
        Vector3 pursueLocation = target.transform.position + target.transform.forward * lookAhead * 3;

        Flee(pursueLocation);
    }
    
    public void Wander(Vector3 center_circle, float radius)
    {
        // wander around the center of the circle, at a distance of radius
        if (Vector3.Distance(this.transform.position, center_circle) > radius + 0.5f) {
            Seek(center_circle);
        } else {
            wanderAngle += 0.0005f; // change this value to the value of the agent's speed, every 0.1s
            // maybe agent.velocity.magnitude
            Vector3 target = center_circle + radius * new Vector3(Mathf.Cos(wanderAngle), 0, Mathf.Sin(wanderAngle));
            Seek(target);
        }
    }
    
    public void Hide()
    {

    }
}
