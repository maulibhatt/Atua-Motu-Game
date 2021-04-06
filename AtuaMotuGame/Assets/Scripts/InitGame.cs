using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGame : MonoBehaviour
{
    public List<Quest> questList;
    public Vector2 playerPosition;

    void Start()
    {
        GameState.Inventory = new List<InvItem>();

        for (int i = 0; i < questList.Count; ++i)
        {
            GameState.AddQuest(questList[i]);
        }
        GameState.PlayerPosition = playerPosition;

    }

    public void StartNewGame()
    {
        GameState.Inventory = new List<InvItem>();
        GameState.Apples = new List<bool>(new bool[6]);
        GameState.Gems = new List<bool>(new bool[28]);
        GameState.IsFollowedByBirch = false;
        GameState.LockBirchMovement = false;
        GameState.LadderEnabled = false;
        GameState.SetLastSceneLocation("");
        GameState.day = 1;

        for (int i = 0; i < questList.Count; ++i)
        {
            GameState.AddQuest(questList[i]);
        }
        for (int i = 0; i < questList.Count; ++i)
        {
            GameState.ReInitializeQuest(questList[i]);
        }
        GameState.PlayerPosition = playerPosition;
    }

}
