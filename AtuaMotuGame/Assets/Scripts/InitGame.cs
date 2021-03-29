using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGame : MonoBehaviour
{
    void Start()
    {
        GameState.Inventory = new List<InvItem>();
    }
}
