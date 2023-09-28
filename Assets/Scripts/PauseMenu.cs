using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Передаём ссылки на классы
    public GameObject pauseMenu;
    private AudioManager audioManager;

    public bool isPaused;

    // Вызывается при инициализации объекта скрипта.
    private void Awake()
    {
        // Находим экземпляр скрипта в сцене
        audioManager = FindObjectOfType<AudioManager>();
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
        // Перезагружаем сцену
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        // Загружаем сцену Main menu
        SceneManager.LoadSceneAsync("Main menu");
    }
}

