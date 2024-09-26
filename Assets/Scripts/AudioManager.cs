using UnityEngine;

public class AudioManager : MonoBehaviour
{
	[Header("Audio Sourse")]
	[SerializeField] private AudioSource _musicSourse;   // Источник звука для фоновой музыки
	[SerializeField] private AudioSource _effectsSourse;     // Источник звука для звуковых эффектов

	[Header("Audio clip")]
	[SerializeField] private AudioClip _backgroundMusic; 
	[SerializeField] private AudioClip _stomp;     
	[SerializeField] private AudioClip _attack;      

	public static AudioManager Instance {get; private set;}
    public AudioClip Attack { get => _attack;}
    public AudioClip Stomp { get => _stomp;}

    private void Awake() 
	{
		//Проверьяем, существует ли уже экземпляр Food
		if (Instance == null)
			// Если нет делаем текщий экземпляр основным
			Instance = this;
		else if (Instance != this) // Если существует
			Destroy(gameObject); // Удаляем, реализирует принцип Синглтон, точто что экземпляр класса может быть только один
	}

	private void Start()
	{
		// Устанавливаем фоновую музыку
		_musicSourse.clip = _backgroundMusic;
		_musicSourse.Play();
	}

	// Метод для воспроизведения звуковых эффектов
	public void PlaySound(AudioClip clip)
	{
		_effectsSourse.PlayOneShot(clip); 
		_effectsSourse.pitch = Random.Range(0.9f, 1.2f);
	}

	// Метод для приостановки фоновой музыки
	public void PauseMusic()
	{
		_musicSourse.Pause();
	}

	// Метод для возобновления воспроизведения фоновой музыки после паузы
	public void UnPauseMusic()
	{
		_musicSourse.UnPause();
	}
}
