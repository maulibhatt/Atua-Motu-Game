using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestList : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        Text text = this.transform.GetChild(1).gameObject.GetComponent<Text>();
        string text_to_add = "";
        for (int i = 0; i < GameState.questList.Count; ++i)
        {
            if (GameState.questList[i].Complete == false)
            {
                if (GameState.questList[i].Quest.QuestDescription != "")
                {
                    text_to_add += "-" + GameState.questList[i].Quest.QuestDescription + "\n";
                }
            }
        }
        text.text = text_to_add;
    }
}
