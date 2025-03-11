using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Project.Scripts
{
	public class Shield : MonoBehaviour, IDamageable
	{
		[SerializeField] private float _minSpeed;
		[SerializeField] private float _maxSpeed;
		[SerializeField] private float _minSize;
		[SerializeField] private float _maxSize;
		[SerializeField] private int _damage = 1;
		[SerializeField] private int _maxHealth = 1;
		[SerializeField] private int _scoreValue = 1;
		
		public static event Action<int> Died;
		public static event Action TakeHit;
		
		private int _currentHealth;
		private float _movementSpeed;
		
		private void Start()
		{
			_movementSpeed = Random.Range(_minSpeed, _maxSpeed);
			transform.localScale = Vector3.one * Random.Range(_minSize, _maxSize);
			
			_currentHealth = _maxHealth;
		}

		private void Update()
		{
			transform.Translate(-_movementSpeed * Time.deltaTime, 0, 0);
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.TryGetComponent(out Knife knife))
			{
				knife.TakeDamage(_damage);
			}
			
			if (other.CompareTag("LeftBoundary"))
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}
		
		public void TakeDamage(int damage)
		{
			_currentHealth -= damage;
			TakeHit?.Invoke();
			
			if (_currentHealth <= 0 )
			{
				Died?.Invoke(_scoreValue);
				Destroy(gameObject);
			}
		}
	}
}
