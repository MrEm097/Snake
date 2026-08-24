using UnityEngine;
using TMPro;

public class SnakeController : MonoBehaviour
{
    private SnakeMove snakeMove;
    private SpawnApple spawnApple;
    private GrowBody growBody;
    private EndGame endGame;

    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private int maxCountPoints = 100;
    [SerializeField] private int countPoints = 0;

    void Start()
    {
        snakeMove = GetComponent<SnakeMove>();
        spawnApple = GetComponent<SpawnApple>();
        growBody = GetComponent<GrowBody>();
        endGame = GetComponent<EndGame>();
        
        pointsText.text = "Points: 0";
    }

    private void OnTriggerEnter(Collider other) // Реагировние на любой встречный объект
    {
        if (other.CompareTag("Apple"))
        {
            pointsText.text = $"Points: {countPoints += 1}";

            if (maxCountPoints == countPoints)
            {
                endGame.EndSnakeGame("WIN!", Color.green);
            }

            growBody.GrowSnake(snakeMove);

            spawnApple.SpawnNewApple(other, snakeMove);
        }

        if (other.CompareTag("Body") || other.CompareTag("Wall"))
        {
            endGame.EndSnakeGame("CRASHED", Color.red);
        }

    }

}