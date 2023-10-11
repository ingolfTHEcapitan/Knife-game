using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Переменная для префабов обоих щитов
    public GameObject shield1Prefab;
    public GameObject shield2Prefab;

    private void Start()
    {
        // Повторяем исполнение метода Spawn с задеркой 
        InvokeRepeating("Spawn1", 2f, 1.5f);
        InvokeRepeating("Spawn2", 6f, 4f);
    }

    private void Spawn1()
    {
        // Используем метод Instantiate() для создания новых экземпляров на сцене

        /* Он создает копию указанного объекта, который 
           может быть префабом, моделью или любым другим объектом */
        var shield1 = Instantiate(shield1Prefab);

        // Присваиваем каждому префабу класс Target.
        var target = shield1.GetComponent<Target>();
        target.SetSpeed(3f, 6f);
        target.SetSize(1.5f, 3f);
    }
    private void Spawn2()
    {
      
        var shield2 = Instantiate(shield2Prefab);
        var target = shield2.GetComponent<Target>();
        target.SetSpeed(2f, 4f);
        target.SetSize(3.5f, 5f);
    }
}

