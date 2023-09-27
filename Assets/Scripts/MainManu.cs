using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManu : MonoBehaviour
{
    // ����� ������ ������� ���������� � ����� ������ � �����

    // ������ Play
    public void PlayGame()
    {
        // ��������� ����� "Game"
        SceneManager.LoadSceneAsync("Game");
    }

    // ������ Reset
    public void Reset()
    {
        // ������� ���������� ������ ���� highScore
        PlayerPrefs.DeleteKey("highScore");
    }

    // ������ Exit
    public void Exit()
    {
        // ����� �� ����
        Application.Quit();
    }
}
