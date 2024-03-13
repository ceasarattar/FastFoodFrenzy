using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    [Header("Time and UI Settings")]
    public float timeForOrder = 120f;
    public TextMeshProUGUI orderText, timerText, ratingText;

    public OrderManager orderManager; // Assign in the Inspector

    private float startTime;
    private bool orderActive = true;

    void Start()
    {
        orderManager = FindObjectOfType<OrderManager>();
        StartNewOrder();
    }

    void Update()
    {
        if (orderActive)
        {
            UpdateTimer();
        }
    }

    private void StartNewOrder()
    {
        orderManager.GenerateRandomOrder();
        UpdateOrderUI();
        ResetTimer();
        orderActive = true;
    }

    private void UpdateOrderUI()
    {
        orderText.text = "Order: " + string.Join(", ", orderManager.currentOrder.itemsRequired);
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
        orderActive = false;
        float timeTaken = Time.time - startTime;
        int rating = CalculateRating(timeTaken);
        ratingText.text = $"Rating: {rating} star(s)";
        orderManager.CompleteOrder();
        Invoke(nameof(StartNewOrder), 3f);
    }

    private int CalculateRating(float timeTaken)
    {
        if (timeTaken <= 30) return 5;
        if (timeTaken <= 60) return 4;
        if (timeTaken <= 90) return 3;
        if (timeTaken <= 120) return 2;
        return 1; // Default minimal rating
    }
}
