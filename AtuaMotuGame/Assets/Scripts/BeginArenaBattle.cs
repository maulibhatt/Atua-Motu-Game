using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeginArenaBattle : Interactable
{
    public GameObject player;
    public Transform destination;
    public bool boxActive = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (GameState.CheckActiveString("Igneous"))
            {
                player.transform.position = destination.position;
            } else
            {
                StartCoroutine("ShowWarning");
            }
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

    IEnumerator ShowWarning()
    {
        if (!boxActive)
        {
            boxActive = true;
            GameObject SignDialogBox = GameObject.Find("Sign Dialog Canvas").transform.GetChild(1).gameObject;
            GameObject text = SignDialogBox.transform.GetChild(0).gameObject;
            text.GetComponent<Text>().text = "Talk to Igneous First!";
            SignDialogBox.SetActive(true);
            yield return new WaitForSeconds(5f);
            SignDialogBox.SetActive(false);
            boxActive = false;
        }
    }
}
