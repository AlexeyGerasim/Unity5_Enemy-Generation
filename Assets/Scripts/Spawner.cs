using System.Collections;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject pointsPrefab;
    private float spawnDelay = 2f;

    private Transform[] spawnPoints;
    private int currentSpawnIndex = 1;

    private void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawn Points").Select(spawnPoint => spawnPoint.transform).ToArray();

        StartCoroutine(SpawnCircles());
    }

    private IEnumerator SpawnCircles()
    {
        while (currentSpawnIndex < spawnPoints.Length)
        {
            SpawnCircle(spawnPoints[currentSpawnIndex]);
            
            currentSpawnIndex++;

            yield return new WaitForSeconds(spawnDelay);
        }
    }
    private void SpawnCircle(Transform spawnPoint)
    {
        Instantiate(pointsPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
