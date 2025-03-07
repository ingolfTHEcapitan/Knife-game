using UnityEngine;
using UnityEngine.SceneManagement;

public class Shield : MonoBehaviour
{
	[SerializeField] private float _minSpeed;
	[SerializeField] private float _maxSpeed;
	[SerializeField] private float _minSize;
	[SerializeField] private float _maxSize;
	[SerializeField] private int _scoreValue;
	
	private float _movementSpeed;
	
	public int ScoreValue => _scoreValue;

	private void Start()
	{
		_movementSpeed = Random.Range(_minSpeed, _maxSpeed);
		transform.localScale = Vector3.one * Random.Range(_minSize, _maxSize);
	}

	private void Update()
	{
		float leftBoundaryX = -9;
		
		transform.Translate(-_movementSpeed * Time.deltaTime, 0, 0);

		if (transform.localPosition.x < leftBoundaryX)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}     
	}
}
