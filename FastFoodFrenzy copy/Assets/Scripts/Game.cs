using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class Game : MonoBehaviour
{
    [Header("Order Settings")]
    public List<string> possibleOrderItems; // List of possible food item names
    public int orderSize = 3; // Number of items in each order

    [Header("Time Settings")]
    public float timeForOrder = 120f; // Time to complete the order

    [Header("UI Components")]
    public TextMeshProUGUI orderText; // UI for displaying the order
    public TextMeshProUGUI timerText; // UI for displaying the timer
    public TextMeshProUGUI ratingText; // UI for displaying the rating

    private List<string> currentOrder;
    private float startTime;
    private bool orderActive;
    private Tray tray; // Reference to the Tray script

    private void Start()
    {
        tray = FindObjectOfType<Tray>(); // Find the Tray script in the scene
        StartNewOrder();
    }

    private void Update()
    {
        if (orderActive)
        {
            UpdateTimer();
            // Check if the player has completed the order
            if (tray.IsOrderComplete(currentOrder))
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
        currentOrder = GenerateRandomOrder();
        UpdateOrderUI();
        ResetTimer();
        orderActive = true;
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

    private void UpdateOrderUI()
    {
        orderText.text = "Order: " + string.Join(", ", currentOrder);
    }

    private void ResetTimer()
    {
        startTime = Time.time;
    }

    private void UpdateTimer()
    {
        float timeLeft = Mathf.Max(timeForOrder - (Time.time - startTime), 0);
        timerText.text = "Time left: " + timeLeft.ToString("F2");

        if (timeLeft <= 0)
        {
            orderActive = false;
            CompleteOrder();
        }
    }

    public void CompleteOrder()
    {
        // Here you would check if the order is correct and then give a rating
        ratingText.text = "Order Completed!";
        Invoke(nameof(StartNewOrder), 3f); // Start a new order after a delay
    }

    private int CalculateRating(float timeTaken)
    {
        // Your logic to calculate the rating based on timeTaken
        // This is just a placeholder for the actual logic
        return 5;
    }

    public void ItemPlacedOnTray(string itemName)
    {
        // Call this method when an item is placed on the tray
        if (currentOrder.Contains(itemName))
        {
            currentOrder.Remove(itemName);
            UpdateOrderUI();
            if (currentOrder.Count == 0)
            {
                // The order is complete
                orderActive = false;
                float timeTaken = Time.time - startTime;
                int rating = CalculateRating(timeTaken);
                ratingText.text = "Rating: " + rating + " star(s)";
            }
        }
    }
}
