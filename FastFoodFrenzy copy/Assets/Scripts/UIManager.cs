using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject dimmingPanel;  // Assign in Inspector
    public GameObject instructionsPanel;  // Assign in Inspector
    public void ShowInstructions()
    {
        instructionsPanel.SetActive(true);
        dimmingPanel.SetActive(true);  // Enable the dimming effect
    }

    public void HideInstructions()
    {
        instructionsPanel.SetActive(false);
        dimmingPanel.SetActive(false);  // Disable the dimming effect
    }


    public void LoadGameScene()
    {
        SceneManager.LoadScene("Demo");  // Load the main game scene
    }

}
