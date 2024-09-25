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
		
		// ��������� ����� ������ ����
		startX = transform.position.x;
	}

	private void Update()
	{
		// ���� ������ ����� ������ ����
		if (Input.GetMouseButtonDown(0) && !pauseMenu.isPaused)
		{
			 // ���������, ��� ���� ��� �� �������������
			if (!hasPlayedSound) 
			{
				// ������������� ��� �����
				SetPitch(1f, 2f);
				// ������������� ����
				audioManager.PlaySFX(audioManager.miss);
				// �������������, ��� ���� �������������
				hasPlayedSound = true; 
			}

			// �������������, ��� ��� �����
			isFlying = true;
		}

		// ���� �����
		if (isFlying)
		{
			// ���������� ������ � �����
			transform.Translate(Time.deltaTime * verticalSpeed, 0, 0);
			_boxCollider2D.enabled = true;
		}
		else
		{
			_boxCollider2D.enabled = true;
			// ����� ������������ ����� ���� �� ���������
			transform.position = new Vector2(startX, Mathf.Sin(Time.time * 3.3f) * 3.25f);
		}

		// ���� �� ����� �� ������� ������
		if (transform.position.x > 7.75f)
		{
			// ������������� �������� ����� �� � �������
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			// �������������, ��� ���� �� �������������
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