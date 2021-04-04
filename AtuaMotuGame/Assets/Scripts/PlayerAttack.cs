using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    bool canAttack = true;
    bool canBreak = false;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public GameObject dropItem;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canAttack) 
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.Space) && canBreak) 
        {
            Break();
        }
    }

    void Attack() 
    {
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.CompareTag("Bully") )
            {
                Vector2 force = (enemy.transform.position - transform.position).normalized * 150;
                Rigidbody2D rb = enemy.transform.GetComponent<Rigidbody2D>();
                rb.AddForce(force, ForceMode2D.Impulse);
            }
            else if (enemy.CompareTag("Beetle"))
            {                
                Instantiate(dropItem, new Vector3(enemy.transform.position.x, enemy.transform.position.y,0), enemy.transform.rotation);
                Destroy(enemy.gameObject);

            }
        }
    }

    void Break()
    {
        animator.SetTrigger("Attack");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            canAttack = false;
        }

        if (other.CompareTag("Breakable"))
        {
            canBreak = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            canAttack = true;
        }
        if (other.CompareTag("Breakable"))
        {
            canBreak = false;
        }
    }

}
