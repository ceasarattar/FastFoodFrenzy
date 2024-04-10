using UnityEngine;
using System.Collections.Generic;

public class Tray : MonoBehaviour
{
    public Game game; // Reference to the Game script

    private HashSet<string> itemsOnTray = new HashSet<string>();
    private List<GameObject> itemsObjects = new List<GameObject>(); // Track the actual GameObjects on the tray
    public AudioClip placeItemSound;
    private AudioSource audioSource;

    void Start()
    {
        // Initialize the AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Add an AudioSource component if not already attached to the GameObject
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickable"))
        {
            itemsOnTray.Add(other.gameObject.name);
            itemsObjects.Add(other.gameObject); // Add the GameObject to the list
            if (placeItemSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(placeItemSound);
            }
            CheckOrderCompletion();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pickable"))
        {
            itemsOnTray.Remove(other.gameObject.name);
            itemsObjects.Remove(other.gameObject); // Remove the GameObject from the list
        }
    }

    private void CheckOrderCompletion()
    {
        if (game.orderManager.IsOrderComplete(itemsOnTray))
        {
            game.CompleteOrder();
            ClearItemsOnTray(); // Clear items after order completion
        }
    }

    // Method to clear items from the tray visually and logically
    private void ClearItemsOnTray()
    {
        foreach (var item in itemsObjects)
        {
            Destroy(item); // Remove the GameObject from the scene
        }
        itemsObjects.Clear(); // Clear the list of GameObjects
        itemsOnTray.Clear(); // Clear the set of item names
    }
}
