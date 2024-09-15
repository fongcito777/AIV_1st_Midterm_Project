using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    [Header("Rotations")] 
    public Transform playerReference;
    public float playerOffset;
    
    void Update()
    {
        if (playerReference != null)
        {
            transform.position = new Vector3(playerReference.position.x, 
                playerReference.position.y + playerOffset,
                playerReference.position.z);
            transform.rotation = Quaternion.Euler(90f, playerReference.eulerAngles.y, 0f);
        }
    }
}
