using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts
{
    public class MainManu : MonoBehaviour
    {
        public void PlayGame() => SceneManager.LoadSceneAsync("Game");

        public void Reset() => PlayerPrefs.DeleteKey("highScore");

        public void Exit() => Application.Quit();
    }
}
