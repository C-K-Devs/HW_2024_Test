using UnityEngine;
using TMPro;
using System.Collections;

public class TimerDisplay : MonoBehaviour
{
    private TextMeshPro timerText;  // Reference to the TextMeshPro component
    private float timeLeft;

    void Start()
    {
        // Find the TextMeshPro component in the children of this GameObject
        timerText = GetComponentInChildren<TextMeshPro>();

        // Initially hide the text
        if (timerText != null)
        {
            timerText.gameObject.SetActive(false);
        }
    }

    // Method to start the timer
    public void StartTimer(float duration)
    {
        if (timerText == null) return;

        timeLeft = duration;
        timerText.gameObject.SetActive(true);  // Activate the timer text
        StartCoroutine(UpdateTimer());
    }

    IEnumerator UpdateTimer()
    {
        while (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = timeLeft.ToString("F2");  // Update the text to show time left
            yield return null;
        }

        // Hide the timer text after the pulpit is destroyed
        timerText.gameObject.SetActive(false);
    }
}
