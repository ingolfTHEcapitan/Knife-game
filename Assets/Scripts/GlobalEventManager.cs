using System;
using UnityEngine.Events;

public class GlobalEventManager
{
    public static event Action<int> EnemyKilled;
  
    public static void OnEnemyKilled(int scoreValue)
    {
        EnemyKilled?.Invoke(scoreValue);
    }
}

