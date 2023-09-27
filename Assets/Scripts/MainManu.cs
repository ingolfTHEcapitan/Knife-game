using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManu : MonoBehaviour
{
    // Сдесь каждая функция привязанна к своей кнопке в юнити

    // Кнопка Play
    public void PlayGame()
    {
        // Загружаем сцену "Game"
        SceneManager.LoadSceneAsync("Game");
    }

    // Кнопка Reset
    public void Reset()
    {
        // Удаляем сохранённые данные поля highScore
        PlayerPrefs.DeleteKey("highScore");
    }

    // Кнопка Exit
    public void Exit()
    {
        // Выход их игры
        Application.Quit();
    }
}
