using UnityEngine;
using UnityEngine.SceneManagement;

public class Shield : MonoBehaviour
{
	[SerializeField] private float _minSpeed;
	[SerializeField] private float _maxSpeed;
	[SerializeField] private float _minSize;
	[SerializeField] private float _maxSize;
	[SerializeField] private int _scoreValue;
	
	private float _speed;
	
	public int ScoreValue => _scoreValue;

	private void Start()
	{
		float randomSpeed = Random.Range(_minSpeed, _maxSpeed);
		_speed = randomSpeed;
		
		Vector2 randomScale = Vector2.one * Random.Range(_minSize, _maxSize);
		transform.localScale = randomScale;
	}

	private void Update()
	{
		float movementSpeed = _speed;
		float leftBoundaryX = -9;

		transform.Translate(-movementSpeed * Time.deltaTime, 0, 0);

		if (transform.localPosition.x < leftBoundaryX)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}     
	}
}
