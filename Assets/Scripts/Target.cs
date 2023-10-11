using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    
    public float _speed;

    public void SetSpeed(float minSpeed, float maxSpeed)
    {
        // Задаём случайную скорость
        _speed = Random.Range(minSpeed, maxSpeed);
    }

    public void SetSize(float minSize, float maxSize)
    {
        // Задаём случаный размер обекта в определённом промежутке
        transform.localScale = Vector3.one * Random.Range(minSize, maxSize);
    }

    private void Start()
    {
        // Задаем позицию появления объекта по Х в том месте где он находится
        // По Y в случайном месте в определённом промежутке
        transform.localPosition = new Vector2(transform.localPosition.x, Random.Range(3.5f, -3.5f));
    }

    private void Update()
    {
        // Перемещаем объект в лево
        transform.Translate(-_speed * Time.deltaTime, 0, 0);

        // Если объект по Х выходит за границы экрана
        if (transform.localPosition.x < -10) 
        {
            // Перезагружаем активную сцену по её индексу
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }     
    }
}
