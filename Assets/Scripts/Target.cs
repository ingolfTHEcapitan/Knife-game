using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    
    private float _speed;

    public void SetSpeed(float minSpeed, float maxSpeed)
    {
        // ����� ��������� ��������
        _speed = Random.Range(minSpeed, maxSpeed);
    }

    public void SetSize(float minSize, float maxSize)
    {
        // ����� �������� ������ ������ � ����������� ����������
        transform.localScale = Vector3.one * Random.Range(minSize, maxSize);
    }

    private void Start()
    {
        // ������ ������� ��������� ������� �� � � ��� ����� ��� �� ���������
        // �� Y � ��������� ����� � ����������� ����������
        transform.localPosition = new Vector2(transform.localPosition.x, Random.Range(3.2f, -3.5f));
    }

    private void Update()
    {
        // ���������� ������ � ����
        transform.Translate(-_speed * Time.deltaTime, 0, 0);

        // ���� ������ �� � ������� �� ������� ������
        if (transform.localPosition.x < -9) 
        {
            // ������������� �������� ����� �� � �������
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }     
    }
}
