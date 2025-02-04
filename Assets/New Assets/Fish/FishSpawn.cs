using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawn : MonoBehaviour
{
    public float spawnFrequency = 1f;
    public GameObject fishPrefab;
    public float spawnRate = 60f;
    private float spawnTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer > spawnFrequency)
        {
            if (spawnRate >= Random.Range(0, 100))
            {
                Instantiate(fishPrefab, transform.position, transform.rotation);
            }

            spawnTimer = 0f;
        }
    }
}
