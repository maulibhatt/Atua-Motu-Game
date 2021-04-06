using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullyManager : MonoBehaviour
{
    public Quest quest;
    public List<GameObject> bullies = new List<GameObject>();
    public List<GameObject> portals = new List<GameObject>();
    void Start()
    {
        if (!GameState.CheckComplete(quest))
        {
            for (int i = 0; i < (3 - GameState.SearchItem("Bone Necklace")); ++i)
            {
                portals[i].SetActive(true); 
                if (i == 0) 
                { 
                    bullies[i].SetActive(true);
                }
                bullies[i+1].SetActive(true);
            }
        }
    }
}
