using System;

public class GlobalEvents
{
	public static event Action<int> EnemyKilled;

	public static void OnEnemyKilled(int scoreValue) => EnemyKilled?.Invoke(scoreValue);
}