using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Project.Scripts
{
	public class Knife : MonoBehaviour, IDamageable
	{
		private enum State
		{
			MovingUpDown,
			Flying
		}
		
		[SerializeField] private float _horizontalSpeed = 13.0f;
		[SerializeField] private float _verticalSpeed = 3.3f;
		[SerializeField] private int _damage = 1;
		[SerializeField] private int _maxHealth = 1;
		
		public static event Action Flying;
		
		private State _currentState;
		private int _currentHealth;
		private float _startPosition;
		private float _verticalAmplitude = 3.25f;
	
		private void Awake()
		{
			_currentHealth = _maxHealth;
			_startPosition = transform.position.x;
			_currentState = State.MovingUpDown;
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
				case State.MovingUpDown:
					float verticalOffset = Mathf.Sin(_verticalSpeed * Time.time) * _verticalAmplitude;
					transform.position = new Vector2(_startPosition, verticalOffset);
					break;
				case State.Flying:
					transform.Translate(_horizontalSpeed * Time.deltaTime , 0, 0);
					break;
			}
		}
		
		private void HandleInput()
		{
			if (_currentState == State.MovingUpDown && Input.GetMouseButtonDown(0) && !PauseMenu.IsPaused)
			{
				_currentState = State.Flying;
				Flying?.Invoke();
			}
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.TryGetComponent(out Shield shield) && _currentState == State.Flying)
			{
				shield.TakeDamage(_damage);
				_currentState = State.MovingUpDown;
			}
			
			if (other.CompareTag("RightBoundary") && _currentState == State.Flying)
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}
		
		public void TakeDamage(int damage)
		{
			if (_currentState == State.MovingUpDown && Mathf.Approximately(transform.position.x, _startPosition))
			{
				_currentHealth -= damage;
			
				if (_currentHealth <= 0 )
				{
					Destroy(gameObject);
					SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
				}
			}
		}
	}
}