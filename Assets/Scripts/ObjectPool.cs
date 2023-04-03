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
    GameObject enemyPrefab;

    /// <summary>
    /// The size of the object pool
    /// </summary>
    [SerializeField]
    private int poolSize = 5;

    /// <summary>
    /// The time between enemy spawns
    /// </summary>
    [SerializeField]
    float spawnTimer = 1f;

    /// <summary>
    /// The pool of enemies
    /// </summary>
    GameObject[] pool;

    /// <summary>
    /// Sets up the pool of enemies at start
    /// </summary>
    private void Awake()
    {
        PopulatePool();
    }

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for(int i = 0; i < poolSize; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    private void EnableObjectInPool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            if(!pool[i].activeSelf)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private IEnumerator SpawnEnemy()
    {
        while(true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
