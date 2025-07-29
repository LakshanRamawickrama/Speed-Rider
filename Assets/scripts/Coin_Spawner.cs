using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Spawner : MonoBehaviour
{
    public GameObject CoinPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CoinSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CoinSpawn()
    {
        float rand = Random.Range(-7.4f, 7.4f);
        Instantiate(CoinPrefab, new Vector3(rand, transform.position.y, transform.position.z),Quaternion .identity );

    }

    IEnumerator CoinSpawner()
    {
        while (true)
        {
            int time = Random.Range(10, 20);
            yield return new WaitForSeconds(2);
            CoinSpawn();
        }
    }
}
