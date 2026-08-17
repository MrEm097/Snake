using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    [SerializeField] GameObject tailPrefab;
    private List<Transform> bodyList = new List<Transform>();

    void Start()
    {
        // В начале только башка
        bodyList.Add(this.transform);
    }
}
