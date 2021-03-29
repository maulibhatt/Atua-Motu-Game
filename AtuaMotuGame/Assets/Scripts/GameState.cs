using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public static class GameState
{
    static Vector2 playerPosition;
    static List<InvItem> inventory = new List<InvItem>();
    static List<GameQuest> questList = new List<GameQuest>();

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
                foundItem = false;
                break;
            }
        }
        if (foundItem == false)
        {
            questList.Add(new GameQuest(quest, false));
        }
    }

    public static void SetQuestComplete(Quest quest)
    {
        for (int i = 0; i < questList.Count; ++i)
        {
            if (questList[i].Quest == quest)
            {
                questList[i].Complete = true;
                break;
            }
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
    Story myStory;
    int itemsStillNeeded;

    public GameQuest(Quest quest, bool complete)
    {
        this.quest = quest;
        this.complete = complete;
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
}

