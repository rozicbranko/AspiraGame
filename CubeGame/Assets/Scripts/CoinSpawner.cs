using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private float timeToSpawnCoin = 1f;

    void Start()
    {
        StartCoroutine(CoinSpawnerTrigger());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CoinSpawnerTrigger()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToSpawnCoin);
            Instantiate(coinPrefab, new Vector3(Random.Range(-7.5f, 7.5f), 1f, 0f), Quaternion.identity);
        }
    }
}
