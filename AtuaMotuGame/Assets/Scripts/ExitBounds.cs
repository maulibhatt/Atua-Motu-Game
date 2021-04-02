using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBounds : MonoBehaviour
{
    public ArenaBattle arena;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            arena.EndBattle();
        }
        else if (other.CompareTag("Bully"))
        {
            arena.BullyDefeated();
            other.gameObject.SetActive(false);
        }
    }
}
