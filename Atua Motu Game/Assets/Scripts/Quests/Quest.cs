using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

[CreateAssetMenu(menuName = "Quest", fileName = "New Quest")]
public class Quest : ScriptableObject
{
    [Header("Dialog Variables")]
    public TextAsset myDialog;
    public Story myStory;

    [Header("Quest Variables")]
    //public QuestManager theQM;
    public bool myQuestCompleted;
    public bool myQuestActive;

    public InventoryItem questItem;
    public bool npcGivesItem;
    public InventoryItem sacrificeItem;
    public int itemCountNeeded;
    public string npcName;
    // Start is called before the first frame update
    void Start()
    {
        myQuestActive = false;
        myQuestCompleted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
