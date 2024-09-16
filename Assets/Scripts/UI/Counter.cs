using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] 
    TextMeshProUGUI _count;
    GameObject[] turretCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        turretCount = GameObject.FindGameObjectsWithTag("Robber");
        _count.text = ("Thieves: " + turretCount.Length);
    }
}
