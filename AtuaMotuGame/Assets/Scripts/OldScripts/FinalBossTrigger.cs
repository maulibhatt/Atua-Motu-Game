using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossTrigger : MonoBehaviour
{
    [SerializeField] private BranchingDialogController theBDC;
    [SerializeField] private Quest ochanoQuest;
    [SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If the other collider is the player
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            theBDC.FinalBoss(ochanoQuest);
            
        }
    }
}
