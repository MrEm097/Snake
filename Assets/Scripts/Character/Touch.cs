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

// 1) Исправить баг с кнопками wasd
// 2) Сделать уже наконец UI

// ....может быть добавлю стены
