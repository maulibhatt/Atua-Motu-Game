using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogObject : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private TextMeshProUGUI myText;

    public void Setup(string newDialog)
    {
        myText.text = newDialog;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
