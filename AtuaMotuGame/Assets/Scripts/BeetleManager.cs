using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleManager : MonoBehaviour
{
    public Quest quest;
    public List<GameObject> beetles = new List<GameObject>();

    void Start()
    {
        if (!GameState.CheckComplete(quest)) 
        {
            List<int> usedNumbers = new List<int>();
            for (int i = 0; i < (12 - GameState.SearchItem("Carrot")); ++i)
            {
                int position = Random.Range(0, beetles.Count);
                while (usedNumbers.Contains(position))
                {
                    position = Random.Range(0, beetles.Count);
                }
                usedNumbers.Add(position);
                beetles[position].SetActive(true);
            }
        }
    }
}
