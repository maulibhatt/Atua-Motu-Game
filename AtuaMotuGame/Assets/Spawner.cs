using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 newPos = GameState.SpawnPosition(SceneManager.GetActiveScene().name);
        if (newPos != new Vector3(-1, -1, -1))
        {
            GameObject player = GameObject.Find("Player");
            player.transform.position = newPos;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
