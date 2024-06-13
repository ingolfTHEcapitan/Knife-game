using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sourse")]
    [SerializeField] AudioSource musicSourse;   // �������� ����� ��� ������� ������
    [SerializeField] AudioSource SFXSourse;     // �������� ����� ��� �������� ��������

    [Header("Audio clip")]
    public AudioClip background; 
    public AudioClip attack;     
    public AudioClip miss;      

    private void Start()
    {
        // ������������� ������� ������
        musicSourse.clip = background;
        musicSourse.Play();
    }

    // ����� ��� ��������������� �������� ��������
    public void PlaySFX(AudioClip clip)
    {
        SFXSourse.PlayOneShot(clip);  
    }

    // ����� ��� ������������ ������� ������
    public void PauseMusic()
    {
        musicSourse.Pause();
    }

    // ����� ��� ������������� ��������������� ������� ������ ����� �����
    public void UnPauseMusic()
    {
        musicSourse.UnPause();
    }

}
