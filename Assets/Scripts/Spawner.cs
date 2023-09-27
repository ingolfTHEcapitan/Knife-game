using UnityEngine;

public class Spawner : MonoBehaviour
{
    // ������� ������ �� ����� �� �����
    public Target shield1;
    public Target shield2; 

    private void Start()
    {
        // ��������� ���������� ������ Spawn � �������� 
        InvokeRepeating("Spawn1", 2f, 1.5f);
        InvokeRepeating("Spawn2", 6f, 4f);
    }

    private void Spawn1()
    {
        // ������� ������ ��� 1
        Instantiate(shield1);
    }
    private void Spawn2()
    {
        // ������� ������ ��� 2
        Instantiate(shield2);
    }

}
