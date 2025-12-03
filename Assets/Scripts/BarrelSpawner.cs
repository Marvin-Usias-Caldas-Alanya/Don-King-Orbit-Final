using System.Collections.Generic;
using UnityEngine;

public class BarrelSpawner : MonoBehaviour
{
    [SerializeField] private GameObject barrelPrefab;
    [SerializeField] private Vector2 spawnRateMinMax;
    private float nextSpawnTime;
    private List<GameObject> barrelsList = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
            SpawnBarrel();
    }

    private void SpawnBarrel()
    {
        float spawnRate = Random.Range(spawnRateMinMax.x, spawnRateMinMax.y);
        nextSpawnTime = Time.time + spawnRate;
        barrelsList.Add(Instantiate(barrelPrefab, transform.position, Quaternion.identity));
    }

    public void DestroyBarrels()
    {
        // function called in Player script once player gets hit by barrel
        foreach (GameObject activeBarrel in barrelsList)
        {
            Destroy(activeBarrel);
        }
        barrelsList.Clear();
    }
}
