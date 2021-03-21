using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public Transform firePoint;
    public GameObject arrowPrefab;

    public float arrowForce = 20f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Attack();
        }
    }

    void Attack() 
    {
        animator.SetTrigger("Attack");
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * arrowForce, ForceMode2D.Impulse);
    }
}
