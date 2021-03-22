using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawns : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] private List<GameObject> fish = new List<GameObject>();
    float startTime;
    bool first = true;
    private void Start()
    {
        startTime = Time.time;
    }
    void Update()
    {
        if (Time.time - startTime > 4 || first)
        {                
            List<int> usedNumbers = new List<int>();
            for (int i = 0; i < 6; i++)
            {
                int position = Random.Range(0, spawnPoints.Count);
                while (usedNumbers.Contains(position))
                {
                    position = Random.Range(0, spawnPoints.Count);
                }
                usedNumbers.Add(position);
                int fishType = Random.Range(0, fish.Count);
                Instantiate(fish[fishType], spawnPoints[position].position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            }
            startTime = Time.time;
            first = false;
        }

    }
}
