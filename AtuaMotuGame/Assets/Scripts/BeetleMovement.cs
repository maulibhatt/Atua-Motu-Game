using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleMovement : MonoBehaviour
{
    public float moveSpeed;
    public Animator animator;
    private Vector2 movement;

    public Transform[] moveSpots;
    private int randSpot;

    void Start()
    {
        randSpot = Random.Range(0, moveSpots.Length);
    }

    void Update()
    {
        checkDistance();
    }

    public void SetNewPoint()
    {
        randSpot = Random.Range(0, moveSpots.Length);
    }

    void checkDistance()
    {
        movement = Vector2.MoveTowards(transform.position, moveSpots[randSpot].position, moveSpeed * Time.deltaTime);
        anim(moveSpots[randSpot].position, transform.position);
        transform.position = movement;
        if (Vector2.Distance(transform.position, moveSpots[randSpot].position) < 0.4f)
        {
            SetNewPoint();
        }  
    }

    void anim(Vector2 start, Vector2 end)
    {
        Vector2 animatorState = start - end;

        animator.SetFloat("Horizontal", animatorState.x);
        animator.SetFloat("Vertical", animatorState.y);
    }
}
