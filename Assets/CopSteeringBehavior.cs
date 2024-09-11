using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CopSteeringBehavior : MonoBehaviour
{
    private SteeringBehaviour steeringBehaviour;
    public GameObject target; // target could change according to the closest thief

    void Start()
    {
        steeringBehaviour = new SteeringBehaviour();
        steeringBehaviour.Init(this.GetComponent<UnityEngine.AI.NavMeshAgent>(), target, transform);
    }

    // The cops by default will be in "Wander" prowling the map, and when they
    // approach a thief, they will switch to "Seek" to catch the thief
    void Update()
    {
        if ((target = Utility.IsCharacterNear(10, "Robber", transform)) != null) {
            steeringBehaviour.Seek(target.transform.position);
        } else {
            steeringBehaviour.Wander();
        }
    }
}
