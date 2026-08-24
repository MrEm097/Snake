using UnityEngine;

public class GrowBody : MonoBehaviour
{
    public void GrowSnake(SnakeMove snakeMove) // Удлиняется хвост
    {
        Vector3 spawnHidden = new Vector3(100, 100, 100);
        GameObject newBody = Instantiate(snakeMove.tailPrefab, spawnHidden, Quaternion.identity);
        snakeMove.bodyList.Add(newBody.transform);
    }
}
