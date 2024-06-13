using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sourse")]
    [SerializeField] AudioSource musicSourse;   // Источник звука для фоновой музыки
    [SerializeField] AudioSource SFXSourse;     // Источник звука для звуковых эффектов

    [Header("Audio clip")]
    public AudioClip background; 
    public AudioClip attack;     
    public AudioClip miss;      

    private void Start()
    {
        // Устанавливаем фоновую музыку
        musicSourse.clip = background;
        musicSourse.Play();
    }

    // Метод для воспроизведения звуковых эффектов
    public void PlaySFX(AudioClip clip)
    {
        SFXSourse.PlayOneShot(clip);  
    }

    // Метод для приостановки фоновой музыки
    public void PauseMusic()
    {
        musicSourse.Pause();
    }

    // Метод для возобновления воспроизведения фоновой музыки после паузы
    public void UnPauseMusic()
    {
        musicSourse.UnPause();
    }

}
