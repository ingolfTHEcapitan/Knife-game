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
            Spawn1(); 
        }
    }

    private IEnumerator Spawn2Routine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(6f, 4f));
            Spawn2();
        }
    }

    private void Spawn1()
    {
        Target shield1 = Instantiate(shield1Prefab);
        shield1.SetSpeed(3f, 6f);
        shield1.SetSize(1.5f, 3f);
    }

    private void Spawn2()
    {
        Target shield2 = Instantiate(shield2Prefab);
        shield2.SetSpeed(2f, 4f);
        shield2.SetSize(3.5f, 5f);
    }
}
