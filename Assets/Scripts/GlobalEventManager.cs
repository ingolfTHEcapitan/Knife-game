using System;
using UnityEngine;

public class GlobalEventManager: MonoBehaviour
{
	public static event Action<int> EnemyKilled;
	public static event Action KnifeAttaked;

    public static void OnEnemyKilled(int scoreValue) => EnemyKilled?.Invoke(scoreValue);
    public static void OnKnifeAttaked() => KnifeAttaked?.Invoke();
}

