using UnityEngine;
using TMPro;

public class SnakeCollision : MonoBehaviour
{
    private int countPoints = 0;
    private SnakeController snakeController;

    // UI
    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private TextMeshProUGUI endGameText;
    [SerializeField] private GameObject endGamePanel;

    [SerializeField] private int maxCountPoints = 100;

    void Start()
    {
        snakeController = GetComponent<SnakeController>();

        pointsText.text = "Points: 0";
    }

    private void OnTriggerEnter(Collider other) // Реагировние на любой встречный объект
    {
        if (other.CompareTag("Apple"))
        {
            pointsText.text = $"Points: {countPoints += 1}";

            if (maxCountPoints == countPoints)
            {
                EndGame("WIN!", Color.green);
            }

            GrowSnake();

            SpawnNewApple(other);
        }

        if (other.CompareTag("Body") || other.CompareTag("Wall"))
        {
            EndGame("CRASHED", Color.red);
        }

    }

    private void EndGame(string massage, Color color) // Завершает игру
    {
        Time.timeScale = 0f;

        endGameText.text = massage;
        endGameText.color = color;
        endGamePanel.SetActive(true);
    }

    private void GrowSnake() // Удлиняется хвост
    {
        Vector3 spawnHidden = new Vector3(100, 100, 100);
        GameObject newBody = Instantiate(snakeController.tailPrefab, spawnHidden, Quaternion.identity);
        snakeController.bodyList.Add(newBody.transform);
    }

    private void SpawnNewApple(Collider appleCollider) // Появление нового яблока
    {
        Vector3 newApplePos = Vector3.zero;

        bool freeSpace = true;

        while (freeSpace)
        {
            float randomX = Mathf.Round( Random.Range(-5f, 5f) );
            float randomZ = Mathf.Round( Random.Range(-5f, 5f) );

            newApplePos = new Vector3(randomX, 1f, randomZ);

            freeSpace = false;

            foreach(Transform part in snakeController.bodyList)
            {
                if (Vector3.Distance(newApplePos, part.position) < 0.9f)
                {
                    freeSpace = true; 
                    break;
                }
            }
        }

        appleCollider.transform.position = newApplePos;
    }
}