using UnityEngine;
using System.Collections.Generic;

public class Tray : MonoBehaviour
{
    public Game game; // Reference to the Game script

    private HashSet<string> itemsOnTray = new HashSet<string>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickable"))
        {
            itemsOnTray.Add(other.gameObject.name);
            CheckOrderCompletion();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pickable"))
        {
            itemsOnTray.Remove(other.gameObject.name);
        }
    }

    private void CheckOrderCompletion()
    {
        if (game.orderManager.IsOrderComplete(itemsOnTray))
        {
            game.CompleteOrder();
        }
    }
}
