using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianSteeringBehavior : MonoBehaviour
{
    private SteeringBehaviour steeringBehaviour;

    public GameObject target;

    void Start()
    {
        steeringBehaviour = new SteeringBehaviour();
        steeringBehaviour.Init(this.GetComponent<UnityEngine.AI.NavMeshAgent>(), target, transform);
    }

    void Update()
    {
        steeringBehaviour.Wander();
    }
}
