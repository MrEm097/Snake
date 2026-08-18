using System.Collections; // Для таймера
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public GameObject tailPrefab;

    public List<Transform> bodyList = new List<Transform>();

    [SerializeField] Vector3 moveDirection = Vector3.forward; // Дефолтное направление

    [SerializeField] float stepDelay = 0.3f; // Задержка

    [SerializeField] float stepSize = 1f; // Какой шаг


    void Start()
    {
        bodyList.Add(this.transform); // В начале только башка

        StartCoroutine( MovementBody() );
    }

    private void Update()
    {
        // Меняем вектор по кнопку И учитываем механику змейки
        if (Input.GetKeyDown(KeyCode.W) && moveDirection != Vector3.back) moveDirection = Vector3.forward;
        if (Input.GetKeyDown(KeyCode.S) && moveDirection != Vector3.forward) moveDirection = Vector3.back;
        if (Input.GetKeyDown(KeyCode.A) && moveDirection != Vector3.right) moveDirection = Vector3.left;
        if (Input.GetKeyDown(KeyCode.D) && moveDirection != Vector3.left) moveDirection = Vector3.right;
    }

    IEnumerator MovementBody() // Доделать нахуй
    {
        while (true)
        {
            // Смещаем хвост, кусок звоста появляется там где был предыдущий
            for (int i = bodyList.Count - 1; i > 0;  i--)
            {
                bodyList[i].position = bodyList[i - 1].position; 
            }

            // Смещаем голову
            transform.position += moveDirection * stepSize;

            // Waiting...
            yield return new WaitForSeconds( stepDelay );
        }
    }
}
