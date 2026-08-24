using UnityEngine;
using UnityEngine.SceneManagement; // Нужно как оказывается для управления сценой

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene"); // Загружает мою вторую сцену
    }

    public void ExitGame()
    {
        Application.Quit(); // Выход из игры

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void ReplayGame()
    {
        Time.timeScale = 1.0f; // Восстанавливает ход времени

        string sceneName = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(sceneName);
    }
}
