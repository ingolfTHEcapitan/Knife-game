using UnityEngine;
using UnityEngine.SceneManagement;

public class Knife : MonoBehaviour
{
	[SerializeField] private float _horizontalSpeed = 13.0f;
	[SerializeField] private float _verticalSpeed = 3.3f;
	
	private float _startXposition;
	private bool _isFlying;
	private BoxCollider2D _boxCollider2D;

	void Awake()
	{
		_boxCollider2D = GetComponent<BoxCollider2D>();
		
		// Сохраняем место спауна ножа
		_startXposition = transform.position.x;
	}

	private void Update()
	{
		// Если нажата левая кнопка мыши
		if (Input.GetMouseButtonDown(0) && !PauseMenu.Instance.IsPaused)
		{
			if (!_isFlying) 
			{
				AudioManager.Instance.PlaySound(AudioManager.Instance.Attack);
			}

			// Устанавливаем, что нож летит
			_isFlying = true;
		}

		// Если летим
		if (_isFlying)
		{
			// Перемещаем объект в право
			transform.Translate(Time.deltaTime * _horizontalSpeed, 0, 0);
			_boxCollider2D.enabled = true;
		}
		else
		{
			_boxCollider2D.enabled = true;
			// Иначе перемещаемся вверх вниз по вертикали
			transform.position = new Vector2(_startXposition, Mathf.Sin(Time.time * _verticalSpeed) * 3.25f);
		}

		// Если мы вышли за границы экрана
		if (transform.position.x > 7.75f)
		{
			// Перезагружаем активную сцену по её индексу
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (!_isFlying && _boxCollider2D.enabled)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
		else if (collider.TryGetComponent(out Shield shield))
		{
			AudioManager.Instance.PlaySound(AudioManager.Instance.Stomp);
			
			_boxCollider2D.enabled = false;
			
			GlobalEventManager.OnEnemyKilled(shield.ScoreValue);

			Destroy(collider.gameObject);
			
			_isFlying = false;
		}
	}
}