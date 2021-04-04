using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class BranchingDialogController : MonoBehaviour
{
    [Header("UI Variables")]
    // reference canvas, dialog boxes, and choice button prefabs
    [SerializeField] private GameObject dialogCanvas;
    [SerializeField] private GameObject finalBossCanvas;
    [SerializeField] private GameObject dialogPrefab;
    [SerializeField] private GameObject choicePrefab;
    //[SerializeField] private TextAssetValue dialogValue;
    [SerializeField] private GameObject dialogHolder;
    [SerializeField] private GameObject choiceHolder;
    [SerializeField] private ScrollRect dialogScrollbar;
    [SerializeField] private Quest myQuest;

    // [Header("Dialog Variables")]
    // [SerializeField] private TextAsset myDialog;
    // [SerializeField] private Story myStory;

    // [Header("Quest Variables")]
    //[SerializeField] private QuestManager theQM;

    private bool scrollInProgress = false;

    private GameObject player;
    // [SerializeField] private bool myQuestCompleted;
    // [SerializeField] private bool myQuestActive;

    // [SerializeField] private InventoryItem questItem;
    // [SerializeField] private int itemCountNeeded;
    // public string npcName;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && scrollInProgress)
        {
            StopCoroutine("MakeNewDialog");
            scrollInProgress = false;
            afterDialog();
        }
    }

    public void FinalBoss(Quest thisQuest)
    {
        if (thisQuest)
        {
            myQuest = thisQuest;
            finalBossCanvas.SetActive(true);
            dialogCanvas.SetActive(true);
            SetFinalBossStory();
            FinalBossRefreshView();
        }
    }

    // This function toggles the dialog canvas
    public void ShowCanvas(Quest thisQuest)
    {
        if (thisQuest)
        {
           
            if (!dialogCanvas.activeSelf)
            {
                myQuest = thisQuest;
                dialogCanvas.SetActive(true);
                player.GetComponent<PlayerMovement>().DisablePlayerMovement();
                SetStory();
                RefreshView();
            }
            
        }

    }

    public void HideCanvas()
    {
        dialogCanvas.SetActive(false);
        player.GetComponent<PlayerMovement>().EnablePlayerMovement();
    }


    public void SetFinalBossStory()
    {
        // obsolete
        // if (myQuest.myDialog)
        // {
        //     DeleteOldDialogs();
        //     myQuest.myStory = new Story(myQuest.myDialog.text);
        //     myQuest.myStory.variablesState["trout"] = theQM.GetNPCQuestStatus("Trout");
        //     myQuest.myStory.variablesState["erised"] = theQM.GetNPCQuestStatus("Erised");
        //     myQuest.myStory.variablesState["birch"] = theQM.GetNPCQuestStatus("Birch");
        //     myQuest.myStory.variablesState["bones"] = theQM.GetNPCQuestStatus("Bones");
        // }
    }

    // Sets the story. Is called every time the canvas is shown again
    public void SetStory()
    {
        // If a dialog value exists, set it to the story
        if (myQuest.myDialog)
        {
            DeleteOldDialogs();
            myQuest.myStory = new Story(myQuest.myDialog.text);
            BindFunction(myQuest.npcName);

             // Check if player's has the potential to be done the quest, then go 
            if (GameState.CheckPotentialCompletion(myQuest.npcName))
            {
                Debug.Log("has_items has been marked true");
                myQuest.myStory.variablesState["has_items"] = true;
            }
            else {
                myQuest.myStory.variablesState["has_items"] = false;
            }

            // If this NPC's quest is active, start at the quest instruction
            if (GameState.CheckActive(myQuest))
            {
                myQuest.myStory.ChoosePathString("accepted");
            }

            // If another NPC's quest is active, say "Find me after your quest"
            // if (!myQuest.myQuestActive && theQM.PlayerQuestStatus())
            // {
            //     myQuest.myStory.ChoosePathString("other_quest_active");
            // }
            // If the quest is completed
            if (GameState.CheckComplete(myQuest))
            {
                myQuest.myStory.ChoosePathString("after_quest");
            }
        }
        else
        {
            Debug.Log("story set up error.");
        }
    }

    public void FinalBossRefreshView()
    {
        while (myQuest.myStory.canContinue)
        {
            // If it can, then show the next line as a mew dialog
            MakeNewDialog(myQuest.myStory.Continue());
        }
        // if there are choices to make, make them
        if (myQuest.myStory.currentChoices.Count > 0)
        {
            MakeNewChoices();
        }
        // No more choices to make
        else
        {
            Debug.Log("Start Menu?");
            SceneManager.LoadScene("StartMenu");
        }
        // Scrolls to the bottom
        StartCoroutine(ScrollCo());
    }

    public void afterDialog()
    {
        // Check if the quest is current active, and set the quest object to be active
        if ((bool)myQuest.myStory.variablesState["accepted_quest"])
        {
            GameState.SetQuestStatus(myQuest, false);
            //theQM.InitiatePlayerQuest(); // Probably not necessary anymore

            // Do something different if it is Erised. Quest is automatically completd once accepted
            // if (myQuest.npcName == "Erised")
            // {
            //     theQM.SetNPCQuestStatus(myQuest.npcName, true);
            // }
        }

        // Check if the quest is complete
        if ((bool)myQuest.myStory.variablesState["completed_quest"])
        {
            // Probably not necessary anymore. No NPCs give items anymore, so can remove (double check though)
            if (myQuest.npcGivesItem)
            {
                GameState.AddItem(myQuest.sacrificeItem);
                //myQuest.sacrificeItem.IncreaseAmount(1);
                myQuest.npcGivesItem = false;
            }

            // Update the quest object to reflect completion
            GameState.SetQuestStatus(myQuest, true);

        }

        if (myQuest.myStory.canContinue)
        {
            RefreshView();
        }
        else
        {
            if (myQuest.myStory.currentChoices.Count > 0)
            {
                MakeNewChoices();
            }
            // No more choices to make
            else
            {
                HideCanvas();
            }
            // Scrolls to the bottom
            StartCoroutine(ScrollCo());
        }
    }

    // Add dialog boxes and choice buttons as needed. Remove old buttons.
    public void RefreshView()
    {
        // Check if story can continue
        if (myQuest.myStory.canContinue)
        {
            // If it can, then show the next line as a mew dialog
            //MakeNewDialog(myQuest.myStory.Continue());

            StartCoroutine("MakeNewDialog", myQuest.myStory.Continue());
        }
            
    }

    // Deletes dialogs from previous chat
    void DeleteOldDialogs()
    {
        for (int i = 0; i < dialogHolder.transform.childCount; i++)
        {
            Destroy(dialogHolder.transform.GetChild(i).gameObject);
        }
    }
    IEnumerator MakeNewDialog(string newDialog)
    {
        Debug.Log("The next line = " + newDialog);
        // Instantiates the dialog object (the prefab) on the dialog holder
        scrollInProgress = true;
        DialogObject newDialogObject = Instantiate(dialogPrefab, dialogHolder.transform).GetComponent<DialogObject>();
        StartCoroutine(ScrollCo());
        float r = newDialogObject.Setup(newDialog);
        yield return new WaitForSeconds(r);
        scrollInProgress = false;
        afterDialog();
    }


    void RemoveOldChoices()
    {
        for (int i = 0; i < choiceHolder.transform.childCount; i++)
        {
            Destroy(choiceHolder.transform.GetChild(i).gameObject);
        }

    }
    void MakeNewChoices()
    {
        // First remove existing buttons
        // add the current choices to the choice holder.
        for (int i = 0; i < myQuest.myStory.currentChoices.Count; i++)
        {
            MakeNewResponse(myQuest.myStory.currentChoices[i].text, i);
        }
    }

    void MakeNewResponse(string newDialog, int choiceValue)
    {
        ChoiceObject newChoiceObject = Instantiate(choicePrefab, choiceHolder.transform).GetComponent<ChoiceObject>();
        newChoiceObject.Setup(newDialog, choiceValue);

        Button choiceButton = newChoiceObject.gameObject.GetComponent<Button>();
        if (choiceButton)
        {
            // Adds the choice value to the listener that is in the onclick part of the button.
            choiceButton.onClick.AddListener(delegate { ChooseChoice(choiceValue); });
        }
    }

    void ChooseChoice(int choiceIndex)
    {
        myQuest.myStory.ChooseChoiceIndex(choiceIndex);
        RemoveOldChoices();
        RefreshView();
    }

    IEnumerator ScrollCo()
    {
        // waits one frame
        yield return null;
        dialogScrollbar.verticalNormalizedPosition = 0f;
    }

    void BindFunction(string name)
    {
        switch (name)
        {
            // When items are given to Maple, Birch stops following the player
            case "Maple":
                myQuest.myStory.BindExternalFunction("giveItems", (int num) =>
                {
                    GameState.IsFollowedByBirch = false;
                    GameState.LockBirchMovement = true;
                });
                break;

            case "Trout":
                myQuest.myStory.BindExternalFunction("giveItems", (int num) =>
                {
                    GameState.RemoveItem(myQuest.questItem, num);
                });
                break;
            case "Mantis":
                myQuest.myStory.BindExternalFunction("giveItems", (int num) =>
                {
                    GameState.RemoveItem(myQuest.questItem, num);
                });
                break;
            case "MsPie":
                myQuest.myStory.BindExternalFunction("giveItems", (int num) =>
                {
                    GameState.RemoveItem(myQuest.questItem, num);
                });
                break;
            case "Igneous":
                myQuest.myStory.BindExternalFunction("giveItems", (int num) =>
                {
                    GameState.RemoveItem(myQuest.questItem, num);
                });
                break;
            case "Bones":
                myQuest.myStory.BindExternalFunction("giveItems", (int num) =>
                {
                    GameState.RemoveItem(myQuest.questItem, num);
                });
                break;
            case "Erised":
                myQuest.myStory.BindExternalFunction("giveItems", (int num) =>
                {
                    GameState.RemoveItem(myQuest.questItem, num);
                });
                break;
            case "Rocky":
                myQuest.myStory.BindExternalFunction("giveItems", (int num) =>
                {
                    GameState.RemoveItem(myQuest.questItem, num);
                });
                break;
            case "Snowy":
                myQuest.myStory.BindExternalFunction("giveItems", (int num) =>
                {
                    GameState.RemoveItem(myQuest.questItem, num);
                });
            case "Frosty":
                myQuest.myStory.BindExternalFunction("giveItems", (int num) =>
                {
                    GameState.RemoveItem(myQuest.questItem, num);
                });
            default:
                myQuest.myStory.BindExternalFunction("giveItems", (int num) =>
                {
                    myQuest.questItem.DecreaseAmount(num);
                });
                break;

        }
    }

}
