using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void LoadDemoScene()
    {
        SceneManager.LoadScene("Demo");
    }
}