using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
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
        if ((GameState.CheckActiveString("Igneous") || GameState.CheckActiveString("Rocky")))
        {
            if (!isActive)
            {
               
                this.transform.GetChild(0).gameObject.SetActive(true);
                this.transform.GetChild(1).gameObject.SetActive(true);
                this.transform.GetChild(2).gameObject.SetActive(true);
                GameObject.Find("HealthManager").GetComponent<HealthManager>().displayLives();
            }
        }
        else if (isActive)
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
            this.transform.GetChild(1).gameObject.SetActive(false);
            this.transform.GetChild(2).gameObject.SetActive(false);
        }

        yield return new WaitForSeconds(2f);
        StartCoroutine("ShowTheThing");

    }
}

