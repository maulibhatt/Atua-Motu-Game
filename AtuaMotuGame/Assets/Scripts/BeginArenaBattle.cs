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

    private void OnTriggerExit2D(Collider2D other)
    {
        // If the other collider is the player
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerInRange = false;
            clue.Raise();
        }
    }
}
