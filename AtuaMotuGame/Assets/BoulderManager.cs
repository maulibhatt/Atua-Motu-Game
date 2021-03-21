using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderManager : MonoBehaviour
{

    public float top;
    public float leftBound;
    public float rightBound;
    public GameObject boulderPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("throwRocks");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator throwRocks()
    {
        float x = Random.Range(leftBound, rightBound);
        Vector2 pos = new Vector2(x, top);
        GameObject boulder = Instantiate(boulderPrefab);
        boulder.transform.position = pos;
        yield return new WaitForSeconds(0.8f);
        StartCoroutine("throwRocks");
    }
}
