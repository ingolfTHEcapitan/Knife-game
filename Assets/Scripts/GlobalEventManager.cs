using System;
using UnityEngine.Events;

public class GlobalEventManager
{
    public static event Action onEnemyKilled;
    public static UnityEvent <int> enemyKilled = new UnityEvent<int>();


    public static void SendEnemyKilled()
    {
       if(onEnemyKilled != null) onEnemyKilled.Invoke();
    }

    public static void CallEnemyKilled(int reward)
    {
        if (enemyKilled != null) enemyKilled.Invoke(reward);
    }

}

