using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Target shield1Prefab;
    [SerializeField] Target shield2Prefab;

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
        Target shield1 = Instantiate(shield1Prefab);

        // Утанавливаем скорость и размер из класса Target.
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

