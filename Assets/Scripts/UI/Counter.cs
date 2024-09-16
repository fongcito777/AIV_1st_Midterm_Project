using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    private TextMeshProUGUI _counter;
    private int _robberCount;

    private void Start()
    {
        _counter = GameObject.FindGameObjectsWithTag("Counter")[0].GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _robberCount = GameObject.FindGameObjectsWithTag("Robber").Length;
        _counter.text = ("Robbers: " + _robberCount);
        if (_robberCount == 0) {
            Debug.Log("Finish game");
        }
    }
}
