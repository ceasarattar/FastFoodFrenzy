using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour
{
    public void LoadMainScene()
    {
        Debug.Log("Attempting to load the Demo scene...");
        SceneManager.LoadScene("Demo");
    }

}
