using System.Collections;
using UnityEngine;

/// <summary>
/// The script for the pool of enemy objects
/// </summary>
public class ObjectPool : MonoBehaviour
{
    /// <summary>
    /// The prefab for the enemy
    /// </summary>
    [SerializeField]
    private GameObject enemyPrefab;

    /// <summary>
    /// The size of the object pool
    /// </summary>
    [SerializeField]
    [Range(0, 50)]
    private int poolSize = 5;

    /// <summary>
    /// The time between enemy spawns
    /// </summary>
    [SerializeField]
    [Range(0.1f, 30f)]
    private float spawnTimer = 1f;

    /// <summary>
    /// The pool of enemies
    /// </summary>
    private GameObject[] pool;

    /// <summary>
    /// Sets up the pool of enemies at start
    /// </summary>
    private void Awake()
    {
        PopulatePool();
    }

    /// <summary>
    /// Starts the enemy spawning coroutine
    /// </summary>
    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    /// <summary>
    /// Populates the pool
    /// </summary>
    private void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    /// <summary>
    /// Enables the enemy object
    /// </summary>
    private void EnableObjectInPool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            if(pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }

    /// <summary>
    /// Spawns the enemy
    /// </summary>
    /// <returns>The wait time between spawns</returns>
    private IEnumerator SpawnEnemy()
    {
        while(true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
