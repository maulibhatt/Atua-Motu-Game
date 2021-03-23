using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeginArenaBattle : Interactable
{
    public GameObject player;
    public Transform destination;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            player.transform.position = destination.position;
        }
    }
}
