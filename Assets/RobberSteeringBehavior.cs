using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobberSteeringBehavior : MonoBehaviour
{
    private SteeringBehaviour steeringBehaviour;

    public GameObject target; // target could change according to the closest cop

    void Start()
    {
        steeringBehaviour = new SteeringBehaviour();
        steeringBehaviour.Init(this.GetComponent<UnityEngine.AI.NavMeshAgent>(), target, transform);
    }

    GameObject[] getObjectsWithTag(string tag)
    {
        return GameObject.FindGameObjectsWithTag(tag);
    }

    bool is_a_pedestrian_near(int distance)
    {
        foreach (GameObject pedestrian in getObjectsWithTag("Pedestrian")) {
            if (Vector3.Distance(pedestrian.transform.position, transform.position) < distance) {
                target = pedestrian;
                return true;
            }
        }
        return false;
    }

    private void OnTriggerEnter (Collider collision)
    {
        if (collision.tag == "Player") {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            Debug.Log("Hit: " + collision.transform.name);
        }
    }

    // They will have the default "Evade" behavior towards police officers and the player
    // until a pedestrian enters their range, when that happens they will switch to "Seek" to catch
    // the pedestrian
    void Update()
    {
        if (is_a_pedestrian_near(10)) {
            steeringBehaviour.Seek(target.transform.position);
        } else {
            steeringBehaviour.Evade();
        }
    }
}
