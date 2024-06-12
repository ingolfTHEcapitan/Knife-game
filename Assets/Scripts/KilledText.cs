using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KilledText : MonoBehaviour
{
    private int killed;
    
    void Start()
    {
        GlobalEventManager.onEnemyKilled += EnemyKilled;
    }

    private void OnDestroy()
    {
        GlobalEventManager.onEnemyKilled -= EnemyKilled;
    }


    private void EnemyKilled()
    {
        killed++;
        GetComponent<TextMeshProUGUI>().text = "Killed: " + killed;
    }
}
