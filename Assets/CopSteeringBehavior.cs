using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopSteeringBehavior : MonoBehaviour
{
    private SteeringBehaviour steeringBehaviour;

    public GameObject target; // target could change according to the closest thief

    void Start()
    {
        steeringBehaviour = new SteeringBehaviour();
        steeringBehaviour.Init(this.GetComponent<UnityEngine.AI.NavMeshAgent>(), target, transform);
    }

    bool is_a_thief_near(int distance)
    {
        // Check if a thief is near
        return false;
    }

    // The cops by default will be in "Wander" prowling the map, and when they
    // approach a thief, they will switch to "Seek" to catch the thief
    void Update()
    {
        if (is_a_thief_near(10)) {
            steeringBehaviour.Seek(target.transform.position);
        } else {
            steeringBehaviour.Wander();
        }
    }
}
