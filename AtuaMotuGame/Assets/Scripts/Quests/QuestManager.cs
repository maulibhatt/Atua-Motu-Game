using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private bool playerInQuest;
    public PlayerInventory playerInventory;
    // Start is called before the first frame update
    [SerializeField] private bool trout;
    [SerializeField] private bool birch;
    //[SerializeField] private bool playerInQuest;
    [SerializeField] private bool erised;
    [SerializeField] private bool bones;

    public GameObject Birch;

    public List<Quest> questList = new List<Quest>();
    void Start()
    {
        trout = false;
        bones = false;
        erised = false;
        birch = false;
        for (int i = 0; i < questList.Count; i++)
        {
            questList[i].myQuestActive = false;
            questList[i].myQuestCompleted = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InitiatePlayerQuest()
    {
        playerInQuest = true;
    }

    public void CompleteQuest()
    {
        playerInQuest = false;
    }

    // Checks if the player is in a quest
    public bool PlayerQuestStatus()
    {
        return playerInQuest;
    }

    // Sets each npc's bool to true or false depending on if quest is completed

    public void SetNPCQuestStatus(string name, bool status)
    {
        switch (name)
        {
            case "Trout":
                trout = status;
                break;
            case "Birch":
                birch = status;
                break;
            case "Erised":
                erised = status;
                break;
            case "Bones":
                bones = status;
                break;
        }
    }

    public bool CheckCompletion(string name)
    {
        switch (name) {
            case "Maple":
                var BirchAI = Birch.GetComponent<NPCFollowAI>();
                if (BirchAI.currentlyFollowing)
                {
                    return true;
                }
                else
                {   
                    return false;
                }
            
            default:
                return false;


        }
    }

    public bool GetNPCQuestStatus(string name)
    {
        switch (name)
        {
            case "Trout":
                return trout;
            case "Birch":
                return birch;
            case "Erised":
                return erised;
            case "Bones":
                return bones;
            default:
                return false;
        }
    }

}
