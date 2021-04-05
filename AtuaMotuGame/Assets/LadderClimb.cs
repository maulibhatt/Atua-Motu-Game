using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LadderClimb : Interactable
{
    // Start is called before the first frame update
    public GameObject player;
    public Vector3 a;

    public bool entrance;
    public GameObject TileMapFloor;
    public GameObject TileMapEntrance;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.LadderEnabled && Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (entrance && !TileMapEntrance.activeSelf)
            {
                TileMapFloor.SetActive(false);
                TileMapEntrance.SetActive(true);
            }
            // Check if the dialogbox is already active, then de-activate
            player.transform.position = a;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            clue.Raise();
            playerInRange = false;
        }
    }

    private void ShowEntrance()
    {

    }



}
