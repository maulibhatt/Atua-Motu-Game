using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCFollowAI : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] PlayerMovement pm;
    public bool currentlyFollowing;
    [SerializeField] private Animator myAnimation;
    [SerializeField] private GameObject theBDC;
    [SerializeField] private GameObject BirchNPC;

    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        myAnimation = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = false;
		agent.updateUpAxis = false;
        currentlyFollowing = false;
        pm = target.GetComponent<PlayerMovement>();
        myAnimation.SetFloat("Speed", 0);
        if (GameState.LockBirchMovement)
        {
            BirchNPC.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameState.LockBirchMovement && currentlyFollowing)
        {
            agent.SetDestination(target.position);
            agent.speed = pm.moveSpeed;
            UpdateAnimation();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!GameState.LockBirchMovement && other.CompareTag("Player") && !other.isTrigger)
        {
            GameState.IsFollowedByBirch = true;
            currentlyFollowing = true;
            myAnimation.SetFloat("Speed", agent.speed);
        }
    }

    void UpdateAnimation()
    {
        myAnimation.SetFloat("Horizontal", agent.velocity.x);
        myAnimation.SetFloat("Vertical", agent.velocity.y);
        myAnimation.SetFloat("Speed", agent.velocity.magnitude);
    }
}
