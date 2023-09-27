using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    private float speed;
     
    private void Start()
    {
        // ������ ������� ��������� ������� �� � � ��� ����� ��� �� ���������
        // �� Y � ��������� ����� � ����������� ����������
        transform.localPosition = new Vector2(transform.localPosition.x, Random.Range(3.5f, -3.5f));

        // ����� ��������� ��������
        speed = Random.Range(4, 9);

        // ����� �������� ������ ������ � ����������� ����������
        transform.localScale = Vector3.one * Random.Range(3f, 1.5f);
    }


    private void Update()
    {
        // ���������� ������ � ����
        transform.Translate(-speed * Time.deltaTime, 0, 0);

        // ���� ������ �� � ������� �� ������� ������
        if (transform.localPosition.x < -10) 
        {
            // ������������� �������� ����� �� � �������
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }     
    }
}
