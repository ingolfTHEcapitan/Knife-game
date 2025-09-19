using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Project.Scripts
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _exitButton;
        
        private void Awake()
        {
            if (Application.platform == RuntimePlatform.WebGLPlayer)
                _exitButton.gameObject.SetActive(false);
        }

        public void PlayGame() => SceneManager.LoadSceneAsync("Game");

        public void Reset() => PlayerPrefs.DeleteKey("highScore");

        public void Exit() => Application.Quit();
    }
}
