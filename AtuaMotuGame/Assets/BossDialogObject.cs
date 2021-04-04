using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossDialogObject : MonoBehaviour
{

    [SerializeField] private Text myText;
    private int choiceValue;

    public void Setup(string newDialog)
    {
        myText.text = newDialog;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
