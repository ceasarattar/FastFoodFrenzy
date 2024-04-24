using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class OrderManager : MonoBehaviour
{
    public List<string> possibleOrderItems = new List<string> {"Cookie", "Pretzel", "Soda Bottle", "Pizza Slice", "Bundt Cake", "Udon", "Lamb Chop", "Salmon", "Ice Cream"};
    public List<Order> ordersQueue = new List<Order>();
    public Order currentOrder;

    public bool HasNextOrder()
    {
        return ordersQueue.Count > 0; // True if there are more orders in the queue
    }   


    void Start()
    {
        GenerateRandomOrder();
    }
    private void Shuffle<T>(List<T> list)
    {
        System.Random rng = new System.Random(); // Create a new Random number generator
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }


    public void GenerateRandomOrder()
    {
        // int numItems = UnityEngine.Random.Range(1, possibleOrderItems.Count + 1); // Random number of items
        int numItems = 1;
        List<string> randomItems = new List<string>();

        List<string> shuffledItems = new List<string>(possibleOrderItems);
        Shuffle(shuffledItems); // Assuming a Shuffle method that randomizes the list

        for (int i = 0; i < numItems; i++)
        {
            randomItems.Add(shuffledItems[i]);
        }

        Order newOrder = new Order(randomItems);
        Debug.Log($"Generated new order with items: {string.Join(", ", newOrder.itemsRequired)}");
        ordersQueue.Add(newOrder);

        if (currentOrder == null)
        {
            currentOrder = newOrder;
            Debug.Log("Generated new order: " + string.Join(", ", currentOrder.itemsRequired));
        }

}


    public void CompleteOrder()
    {
        if (ordersQueue.Count > 0)
        {
            ordersQueue.RemoveAt(0); // Remove the completed order from the queue
            Debug.Log("Order completed and removed from queue."); // Log order removal
        }
    
        currentOrder = ordersQueue.Count > 0 ? ordersQueue[0] : null;

        if (currentOrder != null)
        {
            Debug.Log("Next order set: " + string.Join(", ", currentOrder.itemsRequired)); // Log setting next order
        }
        else {
            GenerateRandomOrder();
            
        }
    }

    public bool IsOrderComplete(HashSet<string> itemsOnTray)
    {
        Debug.Log("Current Order: " + currentOrder);
        Debug.Log("Current Order Items: " + currentOrder.itemsRequired);
    // Early return if currentOrder is not set or if the counts don't match.
        if (currentOrder == null || currentOrder.itemsRequired == null || itemsOnTray.Count != currentOrder.itemsRequired.Count)
        {
            Debug.Log("Order completion failed: Current order null or item counts do not match.");
            return false;
        }

    // This check assumes that there are no duplicates and order doesn't matter.
    // All required items must be in the itemsOnTray.
        bool isComplete = currentOrder.itemsRequired.All(requiredItem => itemsOnTray.Contains(requiredItem));
        Debug.Log("Order completion check: " + (isComplete ? "Successful" : "Failed"));
        return isComplete;
    }
}
