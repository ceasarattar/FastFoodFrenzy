using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public List<string> possibleOrderItems = new List<string> { "Hotdog", "Cookie", "Pretzel" };
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

    public void GenerateRandomOrder()
    {
        List<string> randomItems = new List<string> { "Hotdog", "Cookie", "Pretzel" };

        Order newOrder = new Order(randomItems);
        ordersQueue.Add(newOrder);

        if (currentOrder == null)
        {
            currentOrder = newOrder;
        }
    }

    public void CompleteOrder()
    {
        ordersQueue.RemoveAt(0);
        currentOrder = ordersQueue.Count > 0 ? ordersQueue[0] : null;

        if (currentOrder == null)
        {
            GenerateRandomOrder();
        }
    }

    public bool IsOrderComplete(HashSet<string> itemsOnTray)
    {
        if (currentOrder == null || currentOrder.itemsRequired == null)
        {
            return false;
        }

        foreach (string item in currentOrder.itemsRequired)
        {
            if (!itemsOnTray.Contains(item))
            {
                return false;
            }
        }
        return true;
    }
}
