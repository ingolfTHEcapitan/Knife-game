using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Передаём ссылку на класс со щитом
    public Target shield1;
    public Target shield2; 

    private void Start()
    {
        // Повторяем исполнение метода Spawn с задеркой 
        InvokeRepeating("Spawn1", 2f, 1.5f);
        InvokeRepeating("Spawn2", 6f, 4f);
    }

    private void Spawn1()
    {
        // Спауним объект щит 1
        Instantiate(shield1);
    }
    private void Spawn2()
    {
        // Спауним объект щит 2
        Instantiate(shield2);
    }

}
