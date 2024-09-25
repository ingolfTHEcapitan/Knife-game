using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private int scoreNumber;

    private void Start()
    {
        // ������������� ����� ��� ���� High Score �� ����������� ������.
        highScoreText.SetText($"High Score: {PlayerPrefs.GetInt("highScore", 0)}");
    }

    void OnEnable() => GlobalEventManager.EnemyKilled += IncreaseScore;
    void OnDisable() => GlobalEventManager.EnemyKilled -= IncreaseScore;

    public void IncreaseScore(int value)
    {
        scoreNumber += value;

        // ��������� ����� ��� ���� �������� �����.
        scoreText.SetText($"Score: {scoreNumber}");

        // ���������, ���������� �� ����� ������, � ��������� ��� ��� �������������.
        UpdateHighScore();
    }

    private void UpdateHighScore()
    {
        // ���������, ��������� �� ������� ���� ������ ���������.
        if (scoreNumber > PlayerPrefs.GetInt("highScore", 0))
        {
            // ���� ��, ��������� ������ ��������� � ����������� ������.
            PlayerPrefs.SetInt("highScore", scoreNumber);
            // ��������� ����� ��� ���� "������ ���������" �� ������.
            highScoreText.SetText($"High Score: {scoreNumber}");
        }
    }
}