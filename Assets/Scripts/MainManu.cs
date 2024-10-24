using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManu : MonoBehaviour
{
    public void PlayGame() => SceneManager.LoadSceneAsync("Game");

    public void Reset() => PlayerPrefs.DeleteKey("highScore");

    public void Exit() => Application.Quit();
}
