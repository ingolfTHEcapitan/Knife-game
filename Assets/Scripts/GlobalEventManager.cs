using System;

public class GlobalEventManager
{
	public static event Action<int> EnemyKilled;

	public static void OnEnemyKilled(int scoreValue) => EnemyKilled?.Invoke(scoreValue);
}

