using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    bool canAttack = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canAttack) 
        {
            Attack();
        }
    }

    void Attack() 
    {
        animator.SetTrigger("Attack");
  
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            canAttack = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            canAttack = true;
        }
    }

}
