using UnityEngine;

public class Movement : MonoBehaviour
{
    // Как часто змейка делает шаг (в секундах)
    [SerializeField] float stepInterval = 0.3f;

    // Текущее направление движения
    private Vector3 directionMove = Vector3.forward;

    // Таймер для отсчета времени
    private float stepTimer;

    void Start()
    {

    }

    void Update()
    {
        // 1. Считываем нажатия клавиш и меняем направление
        if (Input.GetKeyDown(KeyCode.W) && directionMove != Vector3.back) directionMove = Vector3.forward;
        if (Input.GetKeyDown(KeyCode.S) && directionMove != Vector3.forward) directionMove = Vector3.back;
        if (Input.GetKeyDown(KeyCode.A) && directionMove != Vector3.right) directionMove = Vector3.left;
        if (Input.GetKeyDown(KeyCode.D) && directionMove != Vector3.left) directionMove = Vector3.right;

        // 2. Считаем время
        stepTimer += Time.deltaTime;

        // 3. Шаг змейки по таймеру
        if (stepTimer >= stepInterval)
        {
            transform.position += directionMove;
            stepTimer = 0f;
        }
    }
}