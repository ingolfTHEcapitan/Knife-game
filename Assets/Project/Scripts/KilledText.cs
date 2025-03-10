using TMPro;
using UnityEngine;

namespace Project.Scripts
{
	public class KilledText : MonoBehaviour
	{
		private int _killedValue;
		private TextMeshProUGUI _killedText;
	
		private void Awake() => _killedText = GetComponent<TextMeshProUGUI>();
	
		private void OnEnable() => Shield.Died += EnemyKilled;
		private void OnDisable() => Shield.Died -= EnemyKilled;

		private void EnemyKilled(int value)
		{
			_killedValue++;
			_killedText.text = "Killed: " + _killedValue;
		}
	}
}
