using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class BreakableTile : MonoBehaviour
{
    public Tilemap breakableTilemap;
    public bool playerInRange;
    public GameObject player;

    public GameObject digText;
    public int currentDigs;
    public int intialDigs = 15;
    // Start is called before the first frame update
    void Start()
    {
        //breakableTilemap = GetComponent<Tilemap>();
        playerInRange = false;
        currentDigs = intialDigs;
        updateDigs();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange && GameState.CheckActiveString("Erised") && currentDigs > 0)
        {
            currentDigs--;
            updateDigs();
            var tilepos = player.transform.position;
            breakableTilemap.SetTile(breakableTilemap.WorldToCell(tilepos), null);
            breakableTilemap.SetTile(breakableTilemap.WorldToCell(tilepos + Vector3.up), null);
            breakableTilemap.SetTile(breakableTilemap.WorldToCell(tilepos + 2*Vector3.up), null);
            breakableTilemap.SetTile(breakableTilemap.WorldToCell(tilepos + Vector3.down), null);
            breakableTilemap.SetTile(breakableTilemap.WorldToCell(tilepos + 2*Vector3.down), null);
            breakableTilemap.SetTile(breakableTilemap.WorldToCell(tilepos + 3*Vector3.down), null);
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

    void updateDigs()
    {
        digText.gameObject.GetComponent<Text>().text = ": " + currentDigs.ToString();
    }





}
