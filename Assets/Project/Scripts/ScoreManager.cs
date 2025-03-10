using TMPro;
using UnityEngine;

namespace Project.Scripts
{
	public class ScoreManager : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _currentScoreText;
		[SerializeField] private TextMeshProUGUI _highScoreText;

		private int _currentScore;
		private int _highScore => PlayerPrefs.GetInt("highScore", 0);

		private void OnEnable() => Shield.Died+= IncreaseScore;
		private void OnDisable() => Shield.Died -= IncreaseScore;
	
		private void Start()
		{
			_highScoreText.SetText($"High Score: {_highScore}");
		}

		private void IncreaseScore(int value)
		{
			_currentScore += value;
		
			_currentScoreText.SetText($"Score: {_currentScore}");

			UpdateHighScore();
		}

		private void UpdateHighScore()
		{
			if (_currentScore > _highScore)
			{
				PlayerPrefs.SetInt("highScore", _currentScore);
			
				_highScoreText.SetText($"High Score: {_currentScore}");
			}
		}
	}
}