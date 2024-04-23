using UnityEngine;
using System.Collections.Generic;

public class Tray : MonoBehaviour
{
    public Game game; // Reference to the Game script

    private HashSet<string> itemsOnTray = new HashSet<string>();
    private List<GameObject> itemsObjects = new List<GameObject>(); // Track the actual GameObjects on the tray
    public AudioClip placeItemSound;
    private AudioSource audioSource;
    private Dictionary<string, Vector3> originalPositions = new Dictionary<string, Vector3>();


    void Start()
    {
        // Initialize the AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Add an AudioSource component if not already attached to the GameObject
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        foreach (var item in GameObject.FindGameObjectsWithTag("Pickable"))
        {
            originalPositions[item.name] = item.transform.position;
        }
    }

    private bool canAddItems = true;
    private bool canProcessNewOrder = true;

    public void ProcessOrderCompletion()
    {
        canProcessNewOrder = false;
        CheckOrderCompletion();
        ClearItemsOnTray();
        canProcessNewOrder = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickable") && canAddItems && canProcessNewOrder)
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
            Debug.Log("Item removed from tray: " + other.gameObject.name); // Log item removal
        }
    }

    private void CheckOrderCompletion()
    {
        Debug.Log("Checking order completion. Items on tray: " + string.Join(", ", itemsOnTray));
        if (game.orderManager.IsOrderComplete(itemsOnTray))
        {
            Debug.Log("Order is complete!"); // Log completion success
            game.CompleteOrder();
            ClearItemsOnTray(); // Clear items after order completion
        }
    }

    // Method to clear items from the tray visually and logically
    public void ClearItemsOnTray()
    {
        canAddItems = false; // Prevent adding new items
        foreach (GameObject item in itemsObjects)
        {
            // Instead of destroying the item, reset its position and activate it
            if (originalPositions.TryGetValue(item.name, out var originalPos))
            {
                item.transform.position = originalPos; // Reset position
                item.SetActive(true); // Re-activate the GameObject
            }
            else
            {
                // Log error if the original position is not found
                Debug.LogError("Original position for " + item.name + " not found!");
            }
        }
        itemsObjects.Clear(); // Clear the list of GameObjects
        itemsOnTray.Clear(); // Clear the set of item names
        Debug.Log("Tray cleared.");
        Invoke(nameof(AllowAddingItems), 0.1f);
    }

    private void AllowAddingItems()
{
    canAddItems = true;
}
}
