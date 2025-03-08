using System;
using TMPro;
using UnityEngine;

public class KilledText : MonoBehaviour
{
	private int _killedValue;
	private TextMeshProUGUI _killedText;
	
	private void Awake() => _killedText = GetComponent<TextMeshProUGUI>();
	
	private void OnEnable() => Knife.EnemyKilled += EnemyKilled;
	private void OnDisable() => Knife.EnemyKilled -= EnemyKilled;

	private void EnemyKilled(int value)
	{
		_killedValue++;
		_killedText.text = "Killed: " + _killedValue;
	}
}
