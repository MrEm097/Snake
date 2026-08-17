using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public GameObject tailPrefab;
    public List<Transform> bodyList = new List<Transform>();

    void Start()
    {
        // В начале только башка
        bodyList.Add(this.transform);
    }
}
