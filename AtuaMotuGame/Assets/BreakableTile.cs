using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BreakableTile : MonoBehaviour
{
    public Tilemap breakableTilemap;
    public bool playerInRange;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //breakableTilemap = GetComponent<Tilemap>();
        playerInRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            Debug.Log("Tile Broken");
            var tilepos = player.transform.position;
            breakableTilemap.SetTile(breakableTilemap.WorldToCell(tilepos), null);
            breakableTilemap.SetTile(breakableTilemap.WorldToCell(tilepos+ Vector3.up), null);
            breakableTilemap.SetTile(breakableTilemap.WorldToCell(tilepos + Vector3.up + Vector3.up), null);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
        //Debug.Log("Hit!!");
        // if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space))
        // {
            
        //     Vector3 hitPosition = Vector3.zero;
        //     foreach(ContactPoint2D hit in other.contacts)
        //     {
        //         hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
        //         hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
        //         breakableTilemap.SetTile(breakableTilemap.WorldToCell(hitPosition), null);
        //     }
        // }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }




}
