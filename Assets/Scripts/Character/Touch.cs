using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Touch : MonoBehaviour
{
    private int countPoints = 0;
    private SnakeController snakeController;

    void Start()
    {
        snakeController = GetComponent<SnakeController>();
    }
    private void OnTriggerEnter(Collider other) // Реагировние на любой встречный объект
    {
        if (other.CompareTag("Apple"))
        {
            countPoints += 1;
            Debug.Log($"You have {countPoints} points!");

            GrowSnake();

            SpawnNewApple(other);
        }

        if (other.CompareTag("Body") || other.CompareTag("Wall"))
        {
            EndGame();
        }

    }

    private void EndGame() // Завершает игру
    {
        Debug.Log("You crashed");
        Time.timeScale = 0f;
    }

    private void GrowSnake() // Удлиняется хвост
    {
        Vector3 lastBody = snakeController.bodyList[snakeController.bodyList.Count - 1].position;
        GameObject newBody = Instantiate(snakeController.tailPrefab, lastBody, Quaternion.identity);
        snakeController.bodyList.Add(newBody.transform);
    }

    private void SpawnNewApple(Collider other) // Появление нового яблока
    {
        float randomX = Random.Range(-13f, 13f);
        float randomZ = Random.Range(-13f, 13f);

        other.transform.position = new Vector3(randomX, 1f, randomZ);
    }
}

// 1) Появление яблока вне зоны хвоста
// 2) Организация префабов (Хвоста)
