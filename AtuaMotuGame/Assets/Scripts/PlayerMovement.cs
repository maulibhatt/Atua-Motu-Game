using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 10f;

    public Rigidbody2D rb;
    public Animator animator;

    private Vector2 lastMovement;
    private Vector2 movement;

    public bool isOnIce = false;


    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        movement = Vector2.zero;
        if (!isOnIce) { 
 
            //// Input: Left arrow = -1, Right arrow = 1, None = 0
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            if (movement.x != 0 || movement.y != 0)
            {
                lastMovement = movement;
            }
        }
        animator.SetFloat("Horizontal", lastMovement.x);
        animator.SetFloat("Vertical", lastMovement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        // Movement: updates at a fixed amount per unit time
        if (isOnIce)
        {
            rb.MovePosition(rb.position + lastMovement * moveSpeed * Time.fixedDeltaTime);
        } else
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
