using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] Target shield1Prefab;
    [SerializeField] Target shield2Prefab;

    private void Start()
    {
        // Запускаем корутины для спавна щитов
        StartCoroutine(Spawn1Routine());
        StartCoroutine(Spawn2Routine());
    }

    private IEnumerator Spawn1Routine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2f, 1.5f));
            Spawn(shield1Prefab, 3f, 6f, 1.5f, 3f); 
        }
    }

    private IEnumerator Spawn2Routine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(6f, 4f));
            Spawn(shield2Prefab, 2f, 4f, 3.5f, 5f);
        }
    }

    private void Spawn(Target prefab, float speedMin, float speedmax, float sizeMin, float sizeMax)
    {
        Target shield = Instantiate(prefab);
        shield.SetSpeed(speedMin, speedmax);
        shield.SetSize(sizeMin, sizeMax);
    }
}
