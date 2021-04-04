using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LadderClimb : Interactable
{
    // Start is called before the first frame update
    public GameObject player;
    public Vector3 a;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            // Check if the dialogbox is already active, then de-activate

            player.transform.position = a;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            clue.Raise();
            //clueOn.Raise();
            playerInRange = false;
        }
    }



}
