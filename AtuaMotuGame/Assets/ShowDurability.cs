using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDurability : MonoBehaviour
{
    private bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ShowTheThing");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ShowTheThing()
    {
        if ((GameState.CheckActiveString("Bones") || GameState.CheckActiveString("Erised")))
        {
            if (!isActive)
            {
                this.transform.GetChild(0).gameObject.SetActive(true);
                this.transform.GetChild(2).gameObject.SetActive(true);
                this.transform.GetChild(3).gameObject.SetActive(true);
            }
        } else if (isActive)
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
            this.transform.GetChild(2).gameObject.SetActive(false);
            this.transform.GetChild(3).gameObject.SetActive(false);
        }

        yield return new WaitForSeconds(2f);
        StartCoroutine("ShowTheThing");

    }
}
