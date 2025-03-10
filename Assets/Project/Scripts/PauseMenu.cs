using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts
{
	public class PauseMenu : MonoBehaviour
	{
		[SerializeField] GameObject _pauseMenu;
	
		public static bool IsPaused {get; private set;}
		public static event Action GamePaused;
		public static event Action GameUnPaused;

		private void Awake()
		{
			IsPaused = false;
		}
	
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				if (IsPaused) 
					ResumeGame();
				else
					PauseGame();
			}
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

		public void ResumeGame()
		{
			GameUnPaused?.Invoke();
			_pauseMenu.SetActive(false);
			Time.timeScale = 1.0f;
			IsPaused = false;
		}
	
		private void PauseGame()
		{
			GamePaused?.Invoke();
			_pauseMenu.SetActive(true);
			Time.timeScale = 0.0f;
			IsPaused = true;
		}
	}
}

