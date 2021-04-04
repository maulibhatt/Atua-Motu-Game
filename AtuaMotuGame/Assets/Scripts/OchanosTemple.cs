using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OchanosTemple : MonoBehaviour
{
    // Start is called before the first frame update
    public bool playerInRange;
    public SignalSender clue;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.Return))
        {
            // activate temple
            Debug.Log("Temple Canvas activate!");
            
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            clue.Raise();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
            clue.Raise();
        }
    }


}
