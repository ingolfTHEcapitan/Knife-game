using TMPro;
using UnityEngine;

public class KilledText : MonoBehaviour
{
	private int _killedValue;
	private TextMeshProUGUI _killedText;
	
	private void Awake() => _killedText = GetComponent<TextMeshProUGUI>();

	private void OnEnable() => GlobalEventManager.EnemyKilled += (_)=> EnemyKilled();

	private void OnDestroy() => GlobalEventManager.EnemyKilled -= (_)=> EnemyKilled();

	private void EnemyKilled()
	{
		_killedValue++;
		_killedText.text = "Killed: " + _killedValue;
	}
}
