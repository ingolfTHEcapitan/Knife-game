using UnityEngine;
using UnityEngine.SceneManagement;

public class Knife : MonoBehaviour
{
	[SerializeField] ScoreManager scoreManager;
	[SerializeField] AudioManager audioManager;
	[SerializeField] AudioSource audioSource;
	[SerializeField] PauseMenu pauseMenu;

	private const int verticalSpeed = 13;
	private float startX;
	private bool isFlying;
	private BoxCollider2D _boxCollider2D;
	private bool hasPlayedSound = false;

	void Awake()
	{
		_boxCollider2D = GetComponent<BoxCollider2D>();
		
		// Сохраняем место спауна ножа
		startX = transform.position.x;
	}

	private void Update()
	{
		// Если нажата левая кнопка мыши
		if (Input.GetMouseButtonDown(0) && !pauseMenu.isPaused)
		{
			 // Проверяем, что звук еще не воспроизведен
			if (!hasPlayedSound) 
			{
				// Устанавливаем тон звука
				SetPitch(1f, 2f);
				// Воспроизводим звук
				audioManager.PlaySFX(audioManager.miss);
				// Устанавливаем, что звук воспроизведен
				hasPlayedSound = true; 
			}

			// Устанавливаем, что нож летит
			isFlying = true;
		}

		// Если летим
		if (isFlying)
		{
			// Перемещаем объект в право
			transform.Translate(Time.deltaTime * verticalSpeed, 0, 0);
			_boxCollider2D.enabled = true;
		}
		else
		{
			_boxCollider2D.enabled = true;
			// Иначе перемещаемся вверх вниз по вертикали
			transform.position = new Vector2(startX, Mathf.Sin(Time.time * 3.3f) * 3.25f);
		}

		// Если мы вышли за границы экрана
		if (transform.position.x > 7.75f)
		{
			// Перезагружаем активную сцену по её индексу
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			// Устанавливаем, что звук не воспроизведен
			hasPlayedSound = false;
		}
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (!isFlying && _boxCollider2D.enabled)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
		else if (collider.TryGetComponent(out Shield shield))
		{
			_boxCollider2D.enabled = false;
			
			SetPitch(0.6f, 1.2f);
			audioManager.PlaySFX(audioManager.attack);
			
			GlobalEventManager.OnEnemyKilled(shield.ScoreValue);

			Destroy(collider.gameObject);
			
			isFlying = false;
		}
	}
	
	private void SetPitch( float minRange, float maxRange)
	{
		audioSource.pitch = UnityEngine.Random.Range(minRange, maxRange);
		
	}
}