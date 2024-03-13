using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public List<Order> ordersQueue = new List<Order>(); // Queue to hold upcoming orders
    public Order currentOrder; // The current active order


    void Start()
    {
        GenerateRandomOrder();
    }

    public void GenerateRandomOrder()
    {
        
        List<string> randomItems = new List<string> { "Burger", "Fries", "Soda" };
        
        // Create a new order and add it to the orders queue
        Order newOrder = new Order(randomItems);
        ordersQueue.Add(newOrder);
        
        // If there's no current order, make this the current order
        if (currentOrder == null)
        {
            currentOrder = newOrder;
        }
    }
    
    // Call this method to move to the next order
    public void CompleteOrder()
    {
        // Remove the current order from the queue
        ordersQueue.Remove(currentOrder);

        // Check if there are more orders in the queue
        if (ordersQueue.Count > 0)
        {
            // Set the next order as the current order
            currentOrder = ordersQueue[0];
        }
        else
        {
            // No more orders, so set currentOrder to null or generate a new order
            GenerateRandomOrder();
        }
    }
}
