using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCFollowAI : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] bool currentlyFollowing;
    [SerializeField] private Animator myAnimation;

    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        myAnimation = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = false;
		agent.updateUpAxis = false;
        currentlyFollowing = false;
        myAnimation.SetFloat("Speed", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentlyFollowing)
        {
            agent.SetDestination(target.position);
            UpdateAnimation();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
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
