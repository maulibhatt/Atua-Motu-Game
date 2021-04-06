using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.SceneManagement;

public static class GameState
{
    static Vector2 playerPosition;
    static List<InvItem> inventory = new List<InvItem>();
    public static List<GameQuest> questList = new List<GameQuest>();
    static List<bool> apples = new List<bool>(new bool[6]);
    static List<bool> gems = new List<bool>(new bool[28]);
    static bool isFollowedByBirch = false;
    static bool ladderEnabled = false;
    static bool lockBirchMovement = false;
    static string lastSceneLocation = "";
    public static int day = 1;

    static Dictionary<string, Dictionary<string, Vector3>> spawnLocations = new Dictionary<string, Dictionary<string, Vector3>>(){
        {"DiggingInTheDesert", new Dictionary<string, Vector3>(){
                {"Town",  new Vector3(13.68f, 7.97f, 0f) },
                { "Beach", new Vector3(24.42f, 7.97f, 0f) }
                }
        },
        {"Beach", new Dictionary<string, Vector3>(){
                {"DiggingInTheDesert",  new Vector3(-15.98f, 16.1f, 0f) },
                { "Town", new Vector3(-17.08f, 4.41f, 0f) },
                { "Volcano", new Vector3(-17.08f, -5.89f, 0f) }
                }
        },
        {"Forest", new Dictionary<string, Vector3>(){
                {"Town",  new Vector3(29.3f, -1.66f, 0f) },
                { "Volcano", new Vector3(25.48f, -11.8f, 0f) },
                { "RockCave", new Vector3(-15.8f, -5.8f, 0f) },
                { "IceCave", new Vector3(-15.8f, 5.57f, 0f) }
                }
        },
        {"RockCave", new Dictionary<string, Vector3>(){
                {"Rock_Climbn",  new Vector3(16.46f, 0.09f, 0f) },
                { "Forest", new Vector3(16.46f, -5.65f, 0f) }
                }
        },
        {"Volcano", new Dictionary<string, Vector3>(){
                {"Town",  new Vector3(3.3f, 22.22f, 0f) },
                { "Forest", new Vector3(-8.85f, 22.45f, 0f) },
                { "Beach", new Vector3(12.99f, 20.78f, 0f) },
                }
        },
        {"Town", new Dictionary<string, Vector3>(){
                {"DiggingInTheDesert",  new Vector3(31.8f, 29.9f, 0f) },
                { "Forest", new Vector3(-20.2f, -7.3f, 0f) },
                { "Beach", new Vector3(45.5f, 17.58f, 0f) },
                { "Volcano", new Vector3(36.7f, -14.7f, 0f) },

            }
        },

    };
    public static void SetLastSceneLocation(string last)
    {
        lastSceneLocation = last;
    }
    public static Vector3 SpawnPosition(string currentScene)
    {
        if (lastSceneLocation == "") {
            return new Vector3(-1,-1,-1);
        }
        else if (currentScene == "Rock_Climbn" || currentScene == "IceCave")
        {
            return new Vector3(-2, -2, -2);
        }
     else
        {
        return spawnLocations[currentScene][lastSceneLocation];
        }
    }

    public static void StartNewDay()
    {
        day++;
        lastSceneLocation = "";
    }

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
    public static bool LadderEnabled
    {
        get { return ladderEnabled;}
        set { ladderEnabled = value;}
    }
    public static bool LockBirchMovement
    {
        get { return lockBirchMovement;}
        set { lockBirchMovement = value;}
    }
    public static List<bool> Gems
    {
        get { return gems; }
        set { gems = value; }
    }
    public static List<bool> Apples
    {
        get { return apples; }
        set { apples = value; }
    }
    public static int SearchItem(string item) 
    {
        for (int i = 0; i < inventory.Count; ++i)
        {
            if (inventory[i].Item.itemName == item)
            {
                return inventory[i].Quantity;
            }
        }
        return 0;
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

    public static void RemoveItem(InventoryItem item, int amount)
    {
        for (int i = 0; i < inventory.Count; ++i)
        {
            if (inventory[i].Item == item)
            {
                if (inventory[i].Quantity == amount)
                {
                    inventory.RemoveAt(i);
                }
                else
                { 
                    inventory[i].Quantity -= amount;
                }
            }
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
            questList.Add(new GameQuest(quest, false, false, quest.npcName));
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
                    Debug.Log(quest.npcName + " quest complete.");
                }
                else
                {
                    questList[i].Active = true;
                    Debug.Log(quest.npcName + " quest active.");
                }
                
                break;
            }
        }
    }

    public static void ReInitializeQuest(Quest quest)
    {
        for (int i = 0; i < questList.Count; ++i)
        {
            if (questList[i].Quest == quest)
            {
                questList[i].Active = false;
                questList[i].Complete = false;
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

    public static bool CheckActiveString(string quest)
    {
        for (int i = 0; i < questList.Count; ++i)
        {
            if (questList[i].QuestName == quest)
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

    public static bool CheckDayPassed(Quest quest)
    {
        for (int i = 0; i < questList.Count; ++i)
        {
            if (questList[i].Quest == quest)
            {
                return questList[i].DayPassed;
            }
        }
        return false;
    }

    public static bool SetDayPassed(Quest quest)
    {
        for (int i = 0; i < questList.Count; ++i)
        {
            if (questList[i].Quest == quest)
            {
                return questList[i].DayPassed = true;
            }
        }
        return false;
    }

    public static void DeactivateQuest(string Quest)
    {
        for (int i = 0; i < questList.Count; ++i)
        {
            if (questList[i].QuestName == Quest)
            {
                questList[i].Active = false;
            }
        }
    }
    public static void AbandonQuest(string Quest)
    {
        DeactivateQuest(Quest);
        StartNewDay();
        SceneManager.LoadScene("Town");

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
            case "Trout":
                if (SearchItem("Blue Fish") >= 10)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case "Mantis":
                if (SearchItem("Carrot") >= 12)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case "MsPie":
                if (SearchItem("Apple") >= 6)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case "Igneous":
                if (SearchItem("Bone Necklace") >= 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case "Bones":
                if (SearchItem("Tablet") >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case "Erised":
                if (SearchItem("Blue Gem") >= 8)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case "Rocky":
                if (SearchItem("Rock Climbing Glove") >= 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case "Snowy":
                if (ladderEnabled)
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
    string questName;
    bool dayPassed;


    public GameQuest(Quest quest, bool complete, bool active, string q)
    {
        this.quest = quest;
        this.complete = complete;
        this.active = active;
        this.questName = q;
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

    public string QuestName
    {
        get { return questName; }
        set { questName = value; }
    }

    public bool DayPassed
    {
        get { return dayPassed; }
        set { dayPassed  = value; }
    }
}

