using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Touch : MonoBehaviour
{
    private SnakeController snakeController;

    void Start()
    {
        snakeController = GetComponent<SnakeController>();
    }
    private void OnTriggerEnter(Collider other) // Реагировние на любой встречный объект
    {
        string nameObject = other.gameObject.name;

        if (nameObject == "Apple")
        {
            GrowSnake();

            SpawnNewApple(other);
        }

        if (nameObject == "Wall_F" || nameObject == "Wall_B" || nameObject == "Wall_R" || nameObject == "Wall_L" /*|| nameObject == "SnakeBody(Clone)"*/)
        {
            Debug.Log("You are dead");
            EndGame();
        }

    }

    private void EndGame() // Завершает игру
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }

    private void GrowSnake() // Удлиняется хвост
    {
        GameObject newBody = Instantiate(snakeController.tailPrefab, transform.position, Quaternion.identity);
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
