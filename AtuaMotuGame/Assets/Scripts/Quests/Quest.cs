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

    public InventoryItem questItem;
    public bool npcGivesItem;
    public InventoryItem sacrificeItem;
    public int itemCountNeeded;
    public string npcName;
    public string QuestDescription;

}
