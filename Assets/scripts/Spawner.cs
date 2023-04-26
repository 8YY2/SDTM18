using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnTime;
    private float countTime;


    // Start is called before the first frame update
    public List<GameObject> platforms = new List<GameObject>();
    public void SpawnPlatform()
    {
        Vector3 spawnPosition = transform.position;
        spawnPosition.x = Random.Range(-10f,100f);
        int index = Random.Range(0, platforms.Count);
        GameObject go = Instantiate(platforms[index], spawnPosition,
       Quaternion.identity);
        go.transform.SetParent(this.gameObject.transform);
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        countTime += Time.deltaTime;

        if (countTime >= spawnTime)
        {
            SpawnPlatform();
            countTime = 0;
        }

    }
}
