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

    bool is_a_pedestrian_near(int distance)
    {
        foreach (GameObject pedestrian in Utility.GetObjectsWithTag("Pedestrian")) {
            if (Vector3.Distance(pedestrian.transform.position, transform.position) < distance) {
                target = pedestrian;
                return true;
            }
        }
        return false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Pedestrian") {
            Debug.Log("Pedestrian collide");
            Destroy(collision.gameObject);
        } else if (collision.gameObject.tag == "Police") { // Cop or Player
            Debug.Log("Police collide");
            Destroy(this.gameObject);
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

// do collision things


// Main menu with game instructions and start game

// Counter in HUD with remaining thieves


// The game ends when all the thieves have been captured

// The game returns to main menu after game ends