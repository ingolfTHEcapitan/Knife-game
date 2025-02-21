using UnityEngine;
using UnityEngine.SceneManagement;

public class Knife : MonoBehaviour
{
	[SerializeField] private float _horizontalSpeed = 13.0f;
	[SerializeField] private float _verticalOscillationSpeed = 3.3f;
	
	private float _startXposition;
	private bool _isFlying;
	private BoxCollider2D _boxCollider2D;

	void Awake()
	{
		_boxCollider2D = GetComponent<BoxCollider2D>();
		
		_startXposition = transform.position.x;
	}

	private void Update()
	{
		int leftButton = 0;
		float horizontalMovementLimit = 7.75f;
		float verticalMovementLimit = 3.25f;
		
		if (Input.GetMouseButtonDown(leftButton) && !PauseMenu.Instance.IsPaused)
		{
			if (!_isFlying) 
			{
				AudioManager.Instance.PlaySound(AudioManager.Instance.Attack);
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
			transform.position = new Vector2(_startXposition, verticalPosition);
		}

		if (transform.position.x > horizontalMovementLimit)
		{
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
			
			GlobalEvents.OnEnemyKilled(shield.ScoreValue);

			Destroy(collider.gameObject);
			
			_isFlying = false;
		}
	}
}