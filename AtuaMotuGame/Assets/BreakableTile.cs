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
            var tilepos = player.transform.position;
            breakableTilemap.SetTile(breakableTilemap.WorldToCell(tilepos), null);
            breakableTilemap.SetTile(breakableTilemap.WorldToCell(tilepos + Vector3.down), null);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }




}
