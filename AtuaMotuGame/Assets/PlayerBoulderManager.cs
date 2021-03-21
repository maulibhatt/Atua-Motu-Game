using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoulderManager : MonoBehaviour
{

    public bool safety = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSafety(bool saf)
    {
        safety = saf;
    }

    public bool getSafety()
    {
        return safety;
    }
}
