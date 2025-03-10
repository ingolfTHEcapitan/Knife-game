using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts
{
	[RequireComponent(typeof(BoxCollider2D))]
	public class Knife : MonoBehaviour, IDamageable
	{
		public enum KnifeState
		{
			MovingUpDown,
			Flying
		}
		
		[SerializeField] private float _horizontalSpeed = 13.0f;
		[SerializeField] private float _verticalOscillationSpeed = 3.3f;
		[SerializeField] private int _damage = 1;
		[SerializeField] private int _maxHealth = 1;
		
		public static event Action Flying;
		private KnifeState _currentState;
		private int _currentHealth;
		private float _startPosition;
		private bool _isFlying;
		private float _horizontalMovementLimit = 7.75f;
		private float _verticalMovementLimit = 3.25f;
		private BoxCollider2D _boxCollider2D;
	
		private void Awake()
		{
			_boxCollider2D = GetComponent<BoxCollider2D>();
			_currentHealth = _maxHealth;
			_startPosition = transform.position.x;

			_currentState = KnifeState.MovingUpDown;
		}
		
		private void Update()
		{
			HandleInput();
			HandleMovement();

		}
		
		private void HandleMovement()
		{
			switch (_currentState)
			{
				case KnifeState.MovingUpDown:
					float verticalPosition = Mathf.Sin(_verticalOscillationSpeed * Time.time) * _verticalMovementLimit;
					transform.position = new Vector2(_startPosition, verticalPosition);
					break;
				case KnifeState.Flying:
					transform.Translate(_horizontalSpeed * Time.deltaTime , 0, 0);
					break;
			}
			
			if (transform.position.x > _horizontalMovementLimit)
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}
		
		private void HandleInput()
		{
			if (_currentState == KnifeState.MovingUpDown && Input.GetMouseButtonDown(0) && !PauseMenu.IsPaused)
			{
				_currentState = KnifeState.Flying;
			}
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.TryGetComponent(out Shield shield))
			{
				if (_currentState == KnifeState.Flying)
				{
					shield.TakeDamage(_damage);
					_currentState = KnifeState.MovingUpDown;
				}
			}
		}
		
		public void TakeDamage(int damage)
		{
			if (_currentState == KnifeState.MovingUpDown)
			{
				_currentHealth -= damage;
			
				if (_currentHealth <= 0 )
				{
					SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
				}
			}
		}
	}
}