using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	[SerializeField] GameObject _pauseMenu;
	
	public bool IsPaused {get; private set;}
	
	public static PauseMenu Instance {get; private set;}

	 private void Awake() 
	{
		//Проверьяем, существует ли уже экземпляр Food
		if (Instance == null)
			// Если нет делаем текщий экземпляр основным
			Instance = this;
		else if (Instance != this) // Если существует
			Destroy(gameObject); // Удаляем, реализирует принцип Синглтон, точто что экземпляр класса может быть только один
	}
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (IsPaused) 
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
		AudioManager.Instance.UnPauseMusic();
		_pauseMenu.SetActive(false);
		Time.timeScale = 1.0f;
		IsPaused = false;
	}

	public void PauseGame()
	{
		AudioManager.Instance.PauseMusic();
		_pauseMenu.SetActive(true);
		Time.timeScale = 0.0f;
		IsPaused = true;
	}

	public void Restart()
	{
		Time.timeScale = 1.0f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void Menu()
	{
		Time.timeScale = 1.0f;
		SceneManager.LoadSceneAsync("Main menu");
	}
}

