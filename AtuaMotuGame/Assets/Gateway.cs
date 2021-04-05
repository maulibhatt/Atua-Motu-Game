using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gateway : MonoBehaviour
{
    private GameObject gateway;
    // Start is called before the first frame update
    void Start()
    {
        gateway = GameObject.Find("Gateway");
        StartCoroutine("Check");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Check()
    {
        if (GameState.CheckActiveString("Rocky"))
        {
            gateway.SetActive(false);
        } else
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine("Check");
        }
    }
}
