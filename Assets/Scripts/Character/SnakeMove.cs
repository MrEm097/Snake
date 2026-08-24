using System.Collections; // Для таймера
using System.Collections.Generic;
using UnityEngine;

public class SnakeMove : MonoBehaviour
{
    public GameObject tailPrefab; // Кусок хвоста змеи

    public List<Transform> bodyList = new List<Transform>(); // Список кусочков змеи

    [SerializeField] Vector3 moveDirection = Vector3.forward; // Дефолтное направление

    [SerializeField] float stepDelay = 0.3f; // Задержка

    [SerializeField] float stepSize = 1f; // Какой шаг

    [SerializeField] bool inputFlag = true; // Нужно для условия в котором запрещается больше одного поворота за одно движение

    void Start()
    {
        bodyList.Add(this.transform); // В начале только появляется башка

        StartCoroutine( MovementBody() );
    }

    private void Update() // Меняем вектор по кнопке, и учитываем механику змейки, что нельзя поворачивать внутрь хвоста
    {
        if (Input.GetKeyDown(KeyCode.W) && moveDirection != Vector3.back && inputFlag)
        {
            moveDirection = Vector3.forward; 
            inputFlag = false;
        }
        
        if (Input.GetKeyDown(KeyCode.S) && moveDirection != Vector3.forward && inputFlag)
        {
            moveDirection = Vector3.back; 
            inputFlag = false;
        }

        if (Input.GetKeyDown(KeyCode.A) && moveDirection != Vector3.right && inputFlag)
        {
            moveDirection = Vector3.left; 
            inputFlag = false;
        }

        if (Input.GetKeyDown(KeyCode.D) && moveDirection != Vector3.left && inputFlag)
        {
            moveDirection = Vector3.right; 
            inputFlag = false;
        }
    }

    IEnumerator MovementBody() 
    {
        while (true)
        {
            Vector3 previousPosition = transform.position; // Запоминаем место где раньше была башка

            transform.position += moveDirection * stepSize; // Двигаем голову

            if ( bodyList.Count > 1 )
            {
                // Присваиваем место где до сдвига была башка
                Vector3 targetPos = previousPosition;

                for (int i = 1; i < bodyList.Count; i++)
                {
                    Vector3 tempPos = bodyList[i].position;
                    bodyList[i].position = targetPos;
                    targetPos = tempPos;
                }
            }

            inputFlag = true;

            // Waiting...
            yield return new WaitForSeconds( stepDelay );
        }
    }
}
