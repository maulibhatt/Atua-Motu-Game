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

    private Vector3 lastPosition;

    public bool isOnIce = false;

    private bool allowChange;


    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {

        movement = Vector2.zero;
        if (isOnIce)
        {
            StartCoroutine("AllowChangeCheck");
        }
        if (!isOnIce || allowChange) {
            allowChange = false;
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
    IEnumerator AllowChangeCheck()
    {
        Vector3 lastPos = transform.position;
        yield return new WaitForSeconds(0.05f);
        if (lastPos == transform.position)
        {
            allowChange = true;
        }
    }
}
