using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private TextMeshProUGUI _counter;
    private int _robberCount;

    private void Start()
    {
        _counter = GameObject.FindGameObjectWithTag("Counter").GetComponent<TextMeshProUGUI>();
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
