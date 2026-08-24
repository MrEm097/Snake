using UnityEngine;

public class SpawnApple : MonoBehaviour
{
    public void SpawnNewApple(Collider appleCollider, SnakeMove snakeMove)
    {
        Vector3 newApplePos = Vector3.zero;

        bool freeSpace = true;

        while (freeSpace)
        {
            float randomX = Mathf.Round(Random.Range(-5f, 5f));
            float randomZ = Mathf.Round(Random.Range(-5f, 5f));

            newApplePos = new Vector3(randomX, 1f, randomZ);

            freeSpace = false;

            foreach (Transform part in snakeMove.bodyList)
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
