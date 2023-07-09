using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private string _nextScene = "TestDriveLevel";

    public void TransitScene()
    {
        SceneManager.LoadScene(_nextScene);
    }
}
