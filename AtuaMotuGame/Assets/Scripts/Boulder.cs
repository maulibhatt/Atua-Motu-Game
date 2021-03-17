using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{
    public float boulderSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float newY = this.transform.position.y - boulderSpeed * Time.deltaTime;
        this.gameObject.transform.position = new Vector2(transform.position.x, newY);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            bool safety = other.gameObject.GetComponent<PlayerBoulderManager>().getSafety();
            if (!safety)
            {
                Debug.Log("died");
            }
        }
    }
}
