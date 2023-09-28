using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // Ссылки на текстовые поля
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private int scoreNumber;

    private void Start()
    {
        // Устанавливаем текст для поля High Score из сохраненных данных.
        highScoreText.SetText($"High Score: {PlayerPrefs.GetInt("highScore", 0)}");
    }

    public void IncreaseScore()
    {
        scoreNumber++;

        // Обновляем текст для поля текущего счета.
        scoreText.SetText($"Score: {scoreNumber}");

        // Проверяем, установлен ли новый рекорд, и обновляем его при необходимости.
        UpdateHighScore();
    }

    private void UpdateHighScore()
    {
        // Проверяем, превышает ли текущий счет лучший результат.
        if (scoreNumber > PlayerPrefs.GetInt("highScore", 0))
        {
            // Если да, обновляем лучший результат в сохраненных данных.
            PlayerPrefs.SetInt("highScore", scoreNumber);
            // Обновляем текст для поля "Лучший результат" на экране.
            highScoreText.SetText($"High Score: {scoreNumber}");
        }
    }
}