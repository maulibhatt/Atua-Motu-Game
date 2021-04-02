using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public static class GameState
{
    static Vector2 playerPosition;
    static List<InvItem> inventory = new List<InvItem>();
    static List<GameQuest> questList = new List<GameQuest>();
    static bool isFollowedByBirch = false;
    static bool lockBirchMovement = false;

    public static Vector2 PlayerPosition
    {
        get { return playerPosition; }
        set { playerPosition = value; }
    }

    public static List<InvItem> Inventory
    {
        get { return inventory; }
        set { inventory = value; }
    }
    public static List<GameQuest> QuestList
    {
        get { return questList; }
        set { questList = value; }
    }
    public static bool IsFollowedByBirch
    {
        get { return isFollowedByBirch;}
        set { isFollowedByBirch = value;}
    }
    public static bool LockBirchMovement
    {
        get { return lockBirchMovement;}
        set { lockBirchMovement = value;}
    }


    public static void AddItem(InventoryItem item) 
    {
        bool foundItem = false;
        for (int i = 0; i < inventory.Count; ++i)
        {
            if (inventory[i].Item == item)
            {
                inventory[i].Quantity += 1;
                foundItem = true;
            }
        }
        if (foundItem == false)
        {
            inventory.Add(new InvItem(item, 1));
        }
    }

    public static void AddQuest(Quest quest)
    {
        bool foundItem = false;
        for (int i = 0; i < questList.Count; ++i)
        {
            if (questList[i].Quest == quest)
            {
                foundItem = true;
                break;
            }
        }
        if (foundItem == false)
        {
            questList.Add(new GameQuest(quest, false, false));
        }
    }

    // True is set complete, false is set active
    public static void SetQuestStatus(Quest quest, bool status)
    {
        for (int i = 0; i < questList.Count; ++i)
        {
            if (questList[i].Quest == quest)
            {
                if (status == true)
                {
                    questList[i].Complete = true;
                    questList[i].Active = false;
                }
                else{
                    questList[i].Active = true;
                }
                
                break;
            }
        }
    }

    public static bool CheckActive(Quest quest)
    {
        for (int i = 0; i < questList.Count; ++i)
        {
            if (questList[i].Quest == quest)
            {
                return questList[i].Active;
            }
        }
        return false;
    }

    public static bool CheckComplete(Quest quest)
    {
        for (int i = 0; i < questList.Count; ++i)
        {
            if (questList[i].Quest == quest)
            {
                return questList[i].Complete;
            }
        }
        return false;
    }

    public static bool CheckPotentialCompletion(string name)
    {
        switch (name) {
            case "Maple":
                if (isFollowedByBirch)
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
}

public class InvItem
{
    InventoryItem item;
    int quantity;

    public InvItem(InventoryItem item, int quantity) 
    {
        this.item = item;
        this.quantity = quantity;
    }

    public InventoryItem Item
    {
        get { return item; }
        set { item = value; }
    }

    public int Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }
}

public class GameQuest
{
    Quest quest;
    bool complete;
    bool active;

    public GameQuest(Quest quest, bool complete, bool active)
    {
        this.quest = quest;
        this.complete = complete;
        this.active = active;
    }

    public Quest Quest
    {
        get { return quest; }
        set { quest = value; }
    }

    public bool Complete
    {
        get { return complete; }
        set { complete = value; }
    }

    public bool Active
    {
        get {return active; }
        set { active = value;}
    }
}

