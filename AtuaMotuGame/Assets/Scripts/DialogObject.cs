using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogObject : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private TextMeshProUGUI myText;

    private string fullText;

    private string cName;

    private float delay = 0.05f;

    public float Setup(string newDialog)
    {
        string[] l = newDialog.Split(':');
        cName = l[0] + ":";
        fullText = l[1];
        myText.text = cName;
        StartCoroutine("showText");
        return delay * fullText.Length+1;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)){
            myText.text = fullText;
            StopCoroutine("showText");
        }
    }

    IEnumerator showText()
    {
        int i = 0;
        while (i < fullText.Length) {
            myText.text = cName + fullText.Substring(0, i);
            i++;
            yield return new WaitForSeconds(delay);
        }
    }
}
