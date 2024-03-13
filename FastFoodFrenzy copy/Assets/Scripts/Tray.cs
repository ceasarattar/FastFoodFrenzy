using UnityEngine;
using System.Collections.Generic;

public class Tray : MonoBehaviour
{
    public Game game; // Reference to the Game
    private HashSet<string> itemsOnTray = new HashSet<string>(); // Tracks items on the tray

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is a food item
        if (other.CompareTag("FoodItem"))
        {
            // Add the food item to the set
            itemsOnTray.Add(other.gameObject.name);
            // Inform the Game that an item has been added
            game.ItemPlacedOnTray(other.gameObject.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the exiting object is a food item
        if (other.CompareTag("FoodItem") && itemsOnTray.Contains(other.gameObject.name))
        {
            // Remove the food item from the set
            itemsOnTray.Remove(other.gameObject.name);
            // Inform the GameManager or handle removal if necessary
        }
    }

    public bool IsOrderComplete(List<string> currentOrder)
    {
        // Check if all items in the current order are on the tray
        foreach (string item in currentOrder)
        {
            if (!itemsOnTray.Contains(item))
            {
                return false;
            }
        }
        return true;
    }
}
