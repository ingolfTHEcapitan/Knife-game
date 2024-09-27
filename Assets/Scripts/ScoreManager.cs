using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _scoreText;
	[SerializeField] private TextMeshProUGUI _highScoreText;

	private int _scoreNumber;

	private void Start()
	{
		// ������������� ����� ��� ���� High Score �� ����������� ������.
		_highScoreText.SetText($"High Score: {PlayerPrefs.GetInt("highScore", 0)}");
	}

	void OnEnable() => GlobalEventManager.EnemyKilled += IncreaseScore;
	void OnDestroy() => GlobalEventManager.EnemyKilled -= IncreaseScore;

	public void IncreaseScore(int value)
	{
		_scoreNumber += value;

		// ��������� ����� ��� ���� �������� �����.
		_scoreText.SetText($"Score: {_scoreNumber}");

		// ���������, ���������� �� ����� ������, � ��������� ��� ��� �������������.
		UpdateHighScore();
	}

	private void UpdateHighScore()
	{
		// ���������, ��������� �� ������� ���� ������ ���������.
		if (_scoreNumber > PlayerPrefs.GetInt("highScore", 0))
		{
			// ���� ��, ��������� ������ ��������� � ����������� ������.
			PlayerPrefs.SetInt("highScore", _scoreNumber);
			// ��������� ����� ��� ���� "������ ���������" �� ������.
			_highScoreText.SetText($"High Score: {_scoreNumber}");
		}
	}
}