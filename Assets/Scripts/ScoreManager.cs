using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _scoreText;
	[SerializeField] private TextMeshProUGUI _highScoreText;

	private int _scoreNumber;

	private void Start()
	{
		// Устанавливаем текст для поля High Score из сохраненных данных.
		_highScoreText.SetText($"High Score: {PlayerPrefs.GetInt("highScore", 0)}");
	}

	void OnEnable() => GlobalEventManager.EnemyKilled += IncreaseScore;
	void OnDestroy() => GlobalEventManager.EnemyKilled -= IncreaseScore;

	public void IncreaseScore(int value)
	{
		_scoreNumber += value;

		// Обновляем текст для поля текущего счета.
		_scoreText.SetText($"Score: {_scoreNumber}");

		// Проверяем, установлен ли новый рекорд, и обновляем его при необходимости.
		UpdateHighScore();
	}

	private void UpdateHighScore()
	{
		// Проверяем, превышает ли текущий счет лучший результат.
		if (_scoreNumber > PlayerPrefs.GetInt("highScore", 0))
		{
			// Если да, обновляем лучший результат в сохраненных данных.
			PlayerPrefs.SetInt("highScore", _scoreNumber);
			// Обновляем текст для поля "Лучший результат" на экране.
			_highScoreText.SetText($"High Score: {_scoreNumber}");
		}
	}
}