using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    GameObject enemyPrefab;

    [SerializeField]
    private int poolSize = 5;

    [SerializeField]
    float spawnTimer = 1f;

    GameObject[] pool;

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
