using UnityEngine;
using UnityEngine.SceneManagement; // Required for changing scenes
using TMPro;

public class Game : MonoBehaviour
{
    [Header("Time and UI Settings")]
    public float timeForOrder = 120f;
    public TextMeshProUGUI orderText, timerText, ratingText;

    public OrderManager orderManager; // Assign in the Inspector

    public Animator characterAnimator;

    private float startTime;
    private bool orderActive = true;
    private int orderCount = 0; // Variable to track the number of orders completed

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
        if (orderCount < 2) // Adjust this number based on how many orders you want the game to have
        {
            orderManager.GenerateRandomOrder();
            UpdateOrderUI();
            ResetTimer();
            ResetRating();
            orderActive = true;
        }
        else
        {
            // If all orders are completed, transition to the credits scene
            TransitionToCredits();
        }
    }

    private void UpdateOrderUI()
    {
        orderText.text = "Order: " + string.Join(", ", orderManager.currentOrder.itemsRequired);
    }

    private void ResetTimer()
    {
        startTime = Time.time;
        timerText.text = "Time left: " + timeForOrder.ToString("F2"); // Reset timer text to full duration
    }

    private void ResetRating()
    {
        ratingText.text = "Rating: "; // Clear rating text or reset as needed
    }

    private void UpdateTimer()
    {
        if (!orderActive) return;

        float timeLeft = Mathf.Max(timeForOrder - (Time.time - startTime), 0);
        timerText.text = "Time left: " + timeLeft.ToString("F2");

        characterAnimator.SetBool("IsAngry", timeLeft < 100f);

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

        orderCount++; // Increment the number of completed orders
        Tray tray = FindObjectOfType<Tray>(); // Find the Tray object
        if (tray != null)
        {
            tray.ClearItemsOnTray(); // Make sure to clear the tray items
        }

        if (orderCount >= 2) // Adjust this number based on how many orders you want the game to have
        {
            TransitionToCredits();
        }
        else
        {
            Invoke(nameof(StartNewOrder), 3f);
        }
    }

    private int CalculateRating(float timeTaken)
    {
        if (timeTaken <= 30) return 5;
        if (timeTaken <= 60) return 4;
        if (timeTaken <= 90) return 3;
        if (timeTaken <= 120) return 2;
        return 1; // Default minimal rating
    }

    private void TransitionToCredits()
    {
        SceneManager.LoadScene("CreditScene"); // Make sure this matches the name of your credits scene
    }
}
