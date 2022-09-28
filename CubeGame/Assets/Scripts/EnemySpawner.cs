using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enenymPrefab;
    [SerializeField] private float timeToSpawnEnemy = 0.5f;

    void Start()
    {
        StartCoroutine(EnemySpawnerTrigger());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EnemySpawnerTrigger()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToSpawnEnemy);
            Instantiate(enenymPrefab, new Vector3(Random.Range(-7.5f, 7.5f), 10f, 0f), Quaternion.identity);
        }
    }
}
