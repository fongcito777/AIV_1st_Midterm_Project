using UnityEngine;
using UnityEngine.SceneManagement;

public class RobberSteeringBehavior : MonoBehaviour
{
    private SteeringBehaviour steeringBehaviour;

    public GameObject target; // target could change according to the closest cop

    void Start()
    {
        steeringBehaviour = new SteeringBehaviour(this.GetComponent<UnityEngine.AI.NavMeshAgent>(), target, transform);
    }

    // Handle all collisions, pedestrians and cops
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Pedestrian")) {
            Debug.Log("Pedestrian collide");
            Destroy(collision.gameObject);
            target = null;
        } else if (collision.CompareTag("Police")|| collision.CompareTag("Player")) {
            Debug.Log("Cop collide");
            Destroy(this.gameObject);
        }
    }

    // They will have the default "Evade" behavior towards police officers and the player
    // until a pedestrian enters their range, when that happens they will switch to "Seek" to catch
    // the pedestrian
    void Update()
    {
        if ((target = Utility.IsCharacterNear(10, "Pedestrian", transform)) != null) {
            steeringBehaviour.Seek(target.transform.position);
        } else if ((target = Utility.IsCharacterNear(8, "Police", transform)) != null) {
            target = Utility.ClosestCharacter("Police", transform);
            steeringBehaviour.NewTarget(target);
            steeringBehaviour.Flee(target.transform.position);
        } else {
            target = Utility.ClosestCharacter("Police", transform);
            steeringBehaviour.NewTarget(target);
            steeringBehaviour.Evade();
        }
    }
}

// Main menu with game instructions and start game

// Counter in HUD with remaining thieves

// The game returns to main menu after game ends
