using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void OnClick()
    {
        SceneManager.LoadScene(sceneName);
    }
}
