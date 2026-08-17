using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Touch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) // Реагировние на любой встречный объект
    {
        string nameObject = other.gameObject.name;

        if (nameObject == "Apple")
        {
            Destroy(other.gameObject); // Яблоко пропадает

            // GrowSnake(); // Удлиняется хвост

            // SpawnNewApple(); // Появление нового яблока
        }

        if (nameObject == "Wall_F" || nameObject == "Wall_B" || nameObject == "Wall_R" || nameObject == "Wall_L" || nameObject == "SnakeBody")
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

    private void GrowSnake()
    {
        GameObject newBody = Instantiate(tailPrefab, transform.position, Quaternion.identity);
        bodyList.Add(newBody.transform);
    }

    private void SpawnNewApple()
    {

    }
}
