using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : Interactable
{

    private Vector3 direction;
    private Transform myPosition;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Animator myAnimation;
    public Collider2D myBounds;
    private bool isMoving;
    public float moveTime;
    // when moveTimeSeconds = 0, it moves in a different direction
    private float moveTimeSeconds;
    public float waitTime;
    private float waitTimeSeconds;

    // Dialog fields commented out
    //[SerializeField] private TextAssetValue dialogValue;
    //[SerializeField] private TextAsset myDialog;
    //[SerializeField] private SignalSender dialogSignal;
    //[SerializeField] private GameObject dialogCanvas;

    public Quest myQuest;
    public BranchingDialogController theBDC;



    // Start is called before the first frame update
    void Start()
    {
        moveTimeSeconds = moveTime;
        waitTimeSeconds = waitTime;
        myPosition = GetComponent<Transform>();
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimation = GetComponent<Animator>();
        ChangeDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            moveTimeSeconds -= Time.deltaTime;
            if (moveTimeSeconds <= 0)
            {
                moveTimeSeconds = moveTime;
                isMoving = false; ;
            }
            if (!playerInRange)
            {
                
                myAnimation.SetFloat("Speed", speed);
                Move();
            }
            if (playerInRange)
            {
                myAnimation.SetFloat("Speed", 0);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    //dialogSignal.Raise();
                    theBDC.ShowCanvas(myQuest);
                }
            }
        }
        else
        {
            waitTimeSeconds -= Time.deltaTime;
            if (waitTimeSeconds <= 0)
            {
                ChooseDifferentDirection();
                isMoving = true;
                waitTimeSeconds = waitTime;
            }
        }
    }

    void ChangeDirection()
    {
        int newDirection = Random.Range(0, 4);

        if (newDirection == 0)
        {
            // Walk right
            direction = Vector3.right;
        }
        else if (newDirection == 3)
        {
            // Walk left
            direction = Vector3.left;
        }
        else if (newDirection == 2)
        {
            // Walk up
            direction = Vector3.up;
        }
        else if (newDirection == 1)
        {
            // Walk down
            direction = Vector3.down;
        }
        UpdateAnimation();
    }

    private void Move()
    {
        Vector3 newPoint = myPosition.position + direction * speed * Time.deltaTime;
        if (myBounds.bounds.Contains(newPoint))
        {
            myRigidbody.MovePosition(newPoint);
        }
        else
        {
            ChangeDirection();
        }
    }

    void UpdateAnimation()
    {
        myAnimation.SetFloat("Horizontal", direction.x);
        myAnimation.SetFloat("Vertical", direction.y);
        myAnimation.SetFloat("Speed", speed);
    }

    private void ChooseDifferentDirection()
    {
        Vector3 temp = direction;
        ChangeDirection();
        // avoid infinite loop
        int loops = 0;
        while (temp == direction && loops < 100)
        {
            loops++;
            ChangeDirection();
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        ChooseDifferentDirection();
    }

     private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            clue.Raise();
            //clueOn.Raise();
            playerInRange = false;
            theBDC.HideCanvas();
        }
    }

}
