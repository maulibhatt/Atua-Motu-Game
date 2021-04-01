using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionClue : Interactable
{
    //public GameObject interactionClue;
    [SerializeField] private bool clueActive = false;
    [SerializeField] private SpriteRenderer mySprite;

    public void Toggle()
    {
        clueActive = !clueActive;
        mySprite.enabled = clueActive;

    }

    // Update is called once per frame
    //public void Disable()
    //{
      //  interactionClue.SetActive(false);
    //}
}
