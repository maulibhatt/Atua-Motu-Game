using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GoBack : MonoBehaviour
{

    private GameObject SignDialogBox;
    private GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        SignDialogBox = GameObject.Find("Sign Dialog Canvas").transform.GetChild(1).gameObject;
        text = SignDialogBox.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            text.GetComponent<Text>().text = "Its time to face Ochano";
            SignDialogBox.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            SignDialogBox.SetActive(false);
        }
    }
}
