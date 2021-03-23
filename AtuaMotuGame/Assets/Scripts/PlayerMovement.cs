using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    private Vector2 lastMovement;
    private Vector2 movement;

    private Vector3 lastPosition;

    public bool isOnIce = false;

    private bool allowChange;

    public Transform attackPoint;

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
        if (!isOnIce || allowChange)
        {
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

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("LastHorizontal", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("LastVertical", Input.GetAxisRaw("Vertical"));
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            attackPoint.transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            attackPoint.transform.localRotation = Quaternion.Euler(0, 0, -90);
        }
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            attackPoint.transform.localRotation = Quaternion.Euler(0, 0, 180);
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            attackPoint.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

    }

    void FixedUpdate()
    {
        if (isOnIce)
        {
            rb.MovePosition(rb.position + lastMovement * moveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
    IEnumerator AllowChangeCheck()
    {
        Vector3 lastPos = transform.position;
        yield return new WaitForSeconds(0.03f);
        if (lastPos == transform.position)
        {
            allowChange = true;
        }
    }
}
