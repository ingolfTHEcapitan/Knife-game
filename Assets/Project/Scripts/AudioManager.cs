using UnityEngine;

namespace Project.Scripts
{
	public class AudioManager : MonoBehaviour
	{
		[Header("Audio Source")]
		[SerializeField] private AudioSource _musicSource;
		[SerializeField] private AudioSource _effectsSource;

		[Header("Audio clip")]
		[SerializeField] private AudioClip _backgroundMusic; 
		[SerializeField] private AudioClip _stomp;     
		[SerializeField] private AudioClip _attack;      
	
		private void OnEnable()
		{
			PauseMenu.GamePaused += _musicSource.Pause;
			PauseMenu.GameUnPaused += _musicSource.UnPause;
			Shield.TakeHit += OnEnemyTakeHit;
			Knife.Flying += OnFlying;
		}

		private void OnDisable()
		{
			PauseMenu.GamePaused -= _musicSource.Pause;
			PauseMenu.GameUnPaused -= _musicSource.UnPause;
			Shield.TakeHit -= OnEnemyTakeHit;
			Knife.Flying -= OnFlying;
		}
    
		private void Start()
		{
			_musicSource.clip = _backgroundMusic;
			_musicSource.Play();
		}
    
		private void OnFlying() => PlaySound(_attack);
		private void OnEnemyTakeHit() => PlaySound(_stomp);
    
		private void PlaySound(AudioClip clip)
		{
			_effectsSource.PlayOneShot(clip); 
			_effectsSource.pitch = Random.Range(0.9f, 1.2f);
		}
	}
}
