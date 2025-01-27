﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : Interactable
{
    // Start is called before the first frame update

    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            // Check if the dialogbox is already active, then de-activate
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            // otherwise, activate the dialogbox
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;

            }
        }
    }

      private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            clue.Raise();
            //clueOn.Raise();
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }



}
