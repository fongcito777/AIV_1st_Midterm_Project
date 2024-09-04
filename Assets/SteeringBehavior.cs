using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class SteeringBehaviour
{
    NavMeshAgent agent;
    GameObject target;
    Transform transform;


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

    // maybe not GetComponent<Drive>()
    // only the player will have this component
    // remplace GetComponent<Drive>() by GetComponent<NavMeshAgent>()

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
    
    public void Wander()
    {

    }
    
    public void Hide()
    {

    }
}
