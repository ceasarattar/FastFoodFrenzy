using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject dimmingPanel;  // Assign in Inspector
    public GameObject instructionsPanel;  // Assign in Inspector

    public GameObject victoryPanel; // Assign in the inspector
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

    public void ShowVictoryOverlay() {
        victoryPanel.SetActive(true);
    }

    public void HideVictoryOverlay() {
        victoryPanel.SetActive(false);
    }    

    public void LoadGameScene()
    {
        SceneManager.LoadScene("Demo");  // Load the main game scene
    }

    public void LoadCreditsScene() {
        SceneManager.LoadScene("CreditScene"); // Replace "Credits" with your actual credits scene name
    }    

    public void UnlockCursor() {
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor so it can move freely.
        Cursor.visible = true; // Make the cursor visible.
    }     

}
