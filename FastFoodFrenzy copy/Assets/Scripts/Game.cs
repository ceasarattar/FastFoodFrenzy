using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class Game : MonoBehaviour
{
    [Header("Order Settings")]

    // played around with this and might be wrong, stick to public List<string> possibleOrderItems;
    public List<string> possibleOrderItems = new List<string> { "burger", "soda", "pizza" }; // List of possible food item names
    public int orderSize = 3; // Number of items in each order

    [Header("Time Settings")]
    public float timeForOrder = 120f; // Time to complete the order

    [Header("UI Components")]
    public TextMeshProUGUI orderText; // UI for displaying the order
    public TextMeshProUGUI timerText; // UI for displaying the timer
    public TextMeshProUGUI ratingText; // UI for displaying the rating

    private OrderManager orderManager;

    private List<string> currentOrder;
    private float startTime;
    private bool orderActive = true;
    private Tray tray; // Reference to the Tray script

    private void Start()
    {
        tray = FindObjectOfType<Tray>(); // Find the Tray script in the scene
        orderManager = FindObjectOfType<OrderManager>(); // Cache the OrderManager
        StartNewOrder();
    }

    private void Update()
    {
        if (orderActive)
        {
            UpdateTimer();
            // Check if the player has completed the order
            if (tray.IsOrderComplete())
            {
                orderActive = false;
                float timeTaken = Time.time - startTime;
                int rating = CalculateRating(timeTaken);
                ratingText.text = "Rating: " + rating + " star(s)";
                Invoke(nameof(StartNewOrder), 3f); // Start a new order after a short delay
            }
        }
    }

    private void StartNewOrder()
    {
        orderManager.GenerateRandomOrder(); // Generate a new order
        UpdateOrderUI(orderManager.currentOrder); // Pass the currentOrder object to the method
        ResetTimer(); // Reset the timer for the new order
        orderActive = true; // Set the order as active
    }

    private List<string> GenerateRandomOrder()
    {
        List<string> newOrder = new List<string>();
        for (int i = 0; i < orderSize; i++)
        {
            string randomItem = possibleOrderItems[Random.Range(0, possibleOrderItems.Count)];
            newOrder.Add(randomItem);
        }
        return newOrder;
    }

    private void UpdateOrderUI(Order order)
    {
    // Make sure to check if order is not null before trying to access itemsRequired
        if(order != null && order.itemsRequired != null)
        {
            orderText.text = "Order: " + string.Join(", ", order.itemsRequired);
        }
    }

    private void ResetTimer()
    {
        startTime = Time.time;
    }

    private void UpdateTimer()
    {
        float timeLeft = Mathf.Max(timeForOrder - (Time.time - startTime), 0);
        timerText.text = "Time left: " + timeLeft.ToString("F2");
        Debug.Log("Timer is updating. Time left: " + timeLeft);

        if (timeLeft <= 0)
        {
            Debug.Log("Time's up. Completing order.");
            orderActive = false;
            CompleteOrder();
        }
    }

    public void CompleteOrder()
    {
        OrderManager orderManager = FindObjectOfType<OrderManager>(); // Find the OrderManager script in the scene

        // Calculate the rating based on time taken
        float timeTaken = Time.time - startTime;
        int rating = CalculateRating(timeTaken);

        // Update the rating UI
        ratingText.text = "Rating: " + rating + " star(s)";

        // Complete the current order in the OrderManager
        orderManager.CompleteOrder();

        // Start a new order after a delay
        Invoke(nameof(StartNewOrder), 3f);
    }

    private int CalculateRating(float timeTaken)
    {
        // logic for rating calculation
        if (timeTaken <= 30) return 5;
        if (timeTaken <= 45) return 4;
        if (timeTaken <= 60) return 3;
        if (timeTaken <= 75) return 2;
        if (timeTaken <= 90) return 1;
        return 0;  // Default to 0 star if none of the above conditions are met
    }

    public void ItemPlacedOnTray(string itemName)
    {
    // Get the current order from the OrderManager
        OrderManager orderManager = FindObjectOfType<OrderManager>();
        Order currentOrder = orderManager.currentOrder;

    // Call this method when an item is placed on the tray
        if (currentOrder != null && currentOrder.itemsRequired.Contains(itemName))
        {
            currentOrder.itemsRequired.Remove(itemName);
            UpdateOrderUI(currentOrder); // Pass the currentOrder object to the method

            if (currentOrder.itemsRequired.Count == 0)
            {
            // The order is complete
                orderActive = false;
                float timeTaken = Time.time - startTime;
                int rating = CalculateRating(timeTaken);
                ratingText.text = "Rating: " + rating + " star(s)";
            
            // Invoke the CompleteOrder method to handle finishing the order and starting a new one
                CompleteOrder();
            }
        }
    }

}
