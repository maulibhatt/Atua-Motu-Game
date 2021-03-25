using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dig : MonoBehaviour
{

    public float digRadius = 0.8f;

    public GameObject digPrefab;

    public LayerMask diggable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Collider2D item = Physics2D.OverlapCircle(this.transform.position, digRadius, diggable);
            if (item == null)
            {
                //display nothing found!
            } else
            {
                //display something found
            }

            Instantiate(digPrefab, this.transform.position, digPrefab.transform.rotation);
        }
    }

}
