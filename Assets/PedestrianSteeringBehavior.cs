using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PedestrianSteeringBehavior : MonoBehaviour
{
    private SteeringBehaviour steeringBehaviour;

    public GameObject target; // target could change according to the closest thief


    void Start()
    {
        steeringBehaviour = new SteeringBehaviour();
        steeringBehaviour.Init(this.GetComponent<UnityEngine.AI.NavMeshAgent>(), target, transform);
    }

    // They will have “Wander” behavior by default, and when a thief approaches
    // them, they will switch to “Flee” to try to escape from them.
    void Update()
    {
        if ((target = Utility.IsCharacterNear(10, "Robber", transform)) != null) {
            steeringBehaviour.Flee(target.transform.position);
        } else {
            steeringBehaviour.Wander();
        }
    }
}
