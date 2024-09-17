using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject _endMenu;
    private GameObject _miniMap;
    private GameObject _counter;
    private TextMeshProUGUI _counterText;
    private int _robberCount;

    private void Start()
    {
        _miniMap = GameObject.FindGameObjectWithTag("Minimap");
        _counter = GameObject.FindGameObjectWithTag("Counter");
        _counterText = _counter.GetComponentInChildren<TextMeshProUGUI>();
        
        _endMenu = GameObject.FindGameObjectWithTag("EndMenu");
        _endMenu.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        _robberCount = GameObject.FindGameObjectsWithTag("Robber").Length;
        _counterText.text = ("Robbers: " + _robberCount);
        
        if (_robberCount == 0) {
            Debug.Log("Finish game");
            
            _miniMap.SetActive(false);
            _counter.SetActive(false);
            
            _endMenu.SetActive(true);
        }
    }
}
