using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderManager : MonoBehaviour
{

    public float top;
    public float leftBound;
    public float rightBound;
    public GameObject boulderPrefab;
    private float offset; 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("throwRocks");
        offset = 1.73f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator throwRocks()
    {
        float rand = Random.Range(0f, 100f);
        if (rand < 7f)
        {
            float count = leftBound;
            int c = 0;
            while (count <= rightBound)
            {
                c++;
                Vector2 pos = new Vector2(count, top);
                GameObject boulder = Instantiate(boulderPrefab);
                boulder.transform.position = pos;
                count += offset;
            }
            Debug.Log(c);
        }
        else
        {
            float x = Random.Range(leftBound, rightBound);
            Vector2 pos = new Vector2(x, top);
            GameObject boulder = Instantiate(boulderPrefab);
            boulder.transform.position = pos;
        }
        yield return new WaitForSeconds(0.8f);
        StartCoroutine("throwRocks");
    }
}
