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
		// ������ �������� �������� �������
		_speed = Random.Range(_minSpeed, _maxSpeed);
		
		// ����� �������� ������ ������
		transform.localScale = Vector3.one * Random.Range(_minSize, _maxSize);
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
