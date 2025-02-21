using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI _currentScoreText;
	[SerializeField] private TextMeshProUGUI _highScoreText;

	private int _currentScore;
	private int HighScore => PlayerPrefs.GetInt("highScore", 0);

	void OnEnable() => GlobalEvents.EnemyKilled += IncreaseScore;
	void OnDestroy() => GlobalEvents.EnemyKilled -= IncreaseScore;
	
	private void Start()
	{
		_highScoreText.SetText($"High Score: {HighScore}");
	}

	public void IncreaseScore(int value)
	{
		_currentScore += value;
		
		_currentScoreText.SetText($"Score: {_currentScore}");

		UpdateHighScore();
	}

	private void UpdateHighScore()
	{
		if (_currentScore > HighScore)
		{
			PlayerPrefs.SetInt("highScore", _currentScore);
			
			_highScoreText.SetText($"High Score: {_currentScore}");
		}
	}
}