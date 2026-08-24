using UnityEngine;
using TMPro;

public class EndGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI endGameText;
    [SerializeField] private GameObject endGamePanel;
    public void EndSnakeGame(string massage, Color color) // Завершает игру
    {
        Time.timeScale = 0f;

        endGameText.text = massage;
        endGameText.color = color;
        endGamePanel.SetActive(true);
    }

}
