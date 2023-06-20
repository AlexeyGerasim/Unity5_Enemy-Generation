using System.Collections;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _pointsPrefab;

    private Transform[] _spawnPoints;
    private float _spawnDelay = 2f;
    private int _currentSpawnIndex = 0;

    private void Start()
    {
        FindSpawnPoints();
        StartCoroutine(SpawnCircles());
    }

    private void FindSpawnPoints()
    {
        _spawnPoints = new Transform[transform.childCount];

        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            _spawnPoints[i] = transform.GetChild(i);
        }
    }

    private IEnumerator SpawnCircles()
    {
        while (_currentSpawnIndex < _spawnPoints.Length)
        {
            SpawnCircle(_spawnPoints[_currentSpawnIndex]);
            
            _currentSpawnIndex++;

            yield return new WaitForSeconds(_spawnDelay);
        }
    }

    private void SpawnCircle(Transform spawnPoint)
    {
        Instantiate(_pointsPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
