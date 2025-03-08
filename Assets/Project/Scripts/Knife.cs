using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Knife : MonoBehaviour
{
	
	[SerializeField] private float _horizontalSpeed = 13.0f;
	[SerializeField] private float _verticalOscillationSpeed = 3.3f;
	public static event Action<int> EnemyKilled;
	public static event Action KnifeAttacked;
	public static event Action EnemyTakeHit;
	
	private float _startPosition;
	private bool _isFlying;
	private BoxCollider2D _boxCollider2D;
	
	private void Awake()
	{
		_boxCollider2D = GetComponent<BoxCollider2D>();
		
		_startPosition = transform.position.x;
	}

	private void Update()
	{
		int leftButton = 0;
		float horizontalMovementLimit = 7.75f;
		float verticalMovementLimit = 3.25f;
		
		if (Input.GetMouseButtonDown(leftButton) && !PauseMenu.IsPaused)
		{
			if (!_isFlying) 
			{
				KnifeAttacked?.Invoke();
			}

			_isFlying = true;
		}

		if (_isFlying)
		{
			transform.Translate(_horizontalSpeed * Time.deltaTime , 0, 0);
			_boxCollider2D.enabled = true;
		}
		else
		{
			_boxCollider2D.enabled = true;
			
			float verticalPosition = Mathf.Sin(_verticalOscillationSpeed * Time.time) * verticalMovementLimit;
			transform.position = new Vector2(_startPosition, verticalPosition);
		}

		if (transform.position.x > horizontalMovementLimit)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (!_isFlying && _boxCollider2D.enabled)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
		else if (other.TryGetComponent(out Shield shield))
		{
			EnemyTakeHit?.Invoke();
			
			_boxCollider2D.enabled = false;
			
			EnemyKilled?.Invoke(shield.ScoreValue);

			Destroy(other.gameObject);
			
			_isFlying = false;
		}
	}
}