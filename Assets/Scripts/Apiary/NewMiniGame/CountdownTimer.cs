using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 60.0f; // Время обратного отсчета в секундах
    private float currentTime;

    public TextMeshProUGUI countdownText; // Ссылка на TextMeshPro для отображения времени

    void Start()
    {
        currentTime = countdownTime;
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            currentTime = 0;
            // Действия по окончании таймера
            SceneLoader.LoadMenuScene();
        }
    }

    void UpdateTimerDisplay()
    {
        // Преобразование времени в формат ММ:СС (минуты:секунды)
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        // Обновление отображения времени в TextMeshPro
        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}