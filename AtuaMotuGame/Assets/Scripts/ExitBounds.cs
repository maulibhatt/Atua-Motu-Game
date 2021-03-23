using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBounds : MonoBehaviour
{
    public GameObject player;
    public GameObject bully;
    public GameObject reward;
    public Transform destination;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.transform.position = destination.position;
        }
        else if (other.CompareTag("Bully"))
        {
            player.transform.position = destination.position;
            bully.SetActive(false);
            reward.SetActive(true);
        }
    }
}
