using UnityEngine;
using UnityEngine.SceneManagement;

public class Shield : MonoBehaviour
{
	[SerializeField] private float _minSpeed;
	[SerializeField] private float _maxSpeed;
	[SerializeField] private float _minSize;
	[SerializeField] private float _maxSize;
	
	private float _speed;
	
	private void Start()
	{
		// Задаем случаную скорость объекта
		_speed = Random.Range(_minSpeed, _maxSpeed);
		
		// Задаём случаный размер обекта
		transform.localScale = Vector3.one * Random.Range(_minSize, _maxSize);
	}

	private void Update()
	{
		// Перемещаем объект в лево
		transform.Translate(-_speed * Time.deltaTime, 0, 0);

		// Если объект по Х выходит за границы экрана
		if (transform.localPosition.x < -9) 
		{
			// Перезагружаем активную сцену по её индексу
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}     
	}
}
