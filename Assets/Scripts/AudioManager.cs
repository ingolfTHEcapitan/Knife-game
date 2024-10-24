using UnityEngine;

public class AudioManager : MonoBehaviour
{
	[Header("Audio Sourse")]
	[SerializeField] private AudioSource _musicSourse;
	[SerializeField] private AudioSource _effectsSourse;

	[Header("Audio clip")]
	[SerializeField] private AudioClip _backgroundMusic; 
	[SerializeField] private AudioClip _stomp;     
	[SerializeField] private AudioClip _attack;      

	public static AudioManager Instance {get; private set;}
    public AudioClip Attack { get => _attack;}
    public AudioClip Stomp { get => _stomp;}

    private void Awake() 
	{
		if (Instance == null)
			Instance = this;
		else if (Instance != this)
			Destroy(gameObject);
	}

	private void Start()
	{
		_musicSourse.clip = _backgroundMusic;
		_musicSourse.Play();
	}

	public void PlaySound(AudioClip clip)
	{
		_effectsSourse.PlayOneShot(clip); 
		_effectsSourse.pitch = Random.Range(0.9f, 1.2f);
	}

    public void PauseMusic() => _musicSourse.Pause();

    public void UnPauseMusic() => _musicSourse.UnPause();
}
