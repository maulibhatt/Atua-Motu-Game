using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OchanosTemple : MonoBehaviour
{
    // Start is called before the first frame update
    public bool playerInRange;
    public SignalSender clue;
    private FinalBossDialog BossDialogController;
    private GameObject player;
    private bool boxActive = false;
    public GameObject oldSound;
    public GameObject newSound;

    public GameObject askUI;
    
    void Start()
    {
        player = GameObject.Find("Player");
        BossDialogController = GetComponent<FinalBossDialog>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.Space))
        {
            // activate temple
            if (GameState.day > 3)
            {
                GameObject challenge = GameObject.Find("ChallengeOchano");
                askUI = challenge.transform.GetChild(1).gameObject;
                askUI.SetActive(true);
                askUI.transform.GetChild(1).gameObject.GetComponent<Button>().onClick.AddListener(ChallengeOchano);
                askUI.transform.GetChild(2).gameObject.GetComponent<Button>().onClick.AddListener(CloseWindow);



            }
            else
            {
                StartCoroutine("ShowWarning");
            }
            
        }
    }

    private void ChallengeOchano()
    {
        BossDialogController.EnableBossCanvas();
        player.GetComponent<PlayerMovement>().EnablePlayerMovement();
        playerInRange = false;
        oldSound.SetActive(false);
        newSound.SetActive(true);
    }

    private void CloseWindow()
    {
        askUI.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            clue.Raise();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
            clue.Raise();
        }
    }

    IEnumerator ShowWarning()
    {
        if (!boxActive)
        {
            boxActive = true;
            GameObject SignDialogBox = GameObject.Find("Sign Dialog Canvas").transform.GetChild(1).gameObject;
            GameObject text = SignDialogBox.transform.GetChild(0).gameObject;
            text.GetComponent<Text>().text = "Come back after Day 3!";
            SignDialogBox.SetActive(true);
            yield return new WaitForSeconds(5f);
            SignDialogBox.SetActive(false);
            boxActive = false;
        }
    }


}
