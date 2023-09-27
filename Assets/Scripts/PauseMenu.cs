using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // ������ �� ������� ���� �����.
    public GameObject pauseMenu;

    // ������ �� �������� �����.
    AudioManager audioManager;

    public bool isPaused;

    // ���������� ��� ������������� ������� �������.
    private void Awake()
    {
        // ������� � ����������� � ���������� ����� � �����.
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) 
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        audioManager.UnPauseMusic();
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void PauseGame()
    {
        audioManager.PauseMusic();
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        // ������������� �����
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        // ��������� ����� Main menu
        SceneManager.LoadSceneAsync("Main menu");
    }
}

