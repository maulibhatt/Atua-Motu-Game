using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaBattle : MonoBehaviour
{
    public GameObject player;
    public GameObject entryPortal;
    public int bullyNum;
    public GameObject reward;
    public Transform destination;
    private int bullyDefeated = 0;

    public void BullyDefeated()
    {
        bullyDefeated += 1;

        if (bullyDefeated >= (bullyNum*2))
        {
            player.transform.position = destination.position;
            reward.SetActive(true);
            entryPortal.SetActive(false);
            EndBattle();
        }
    }

    public void EndBattle()
    {
        player.transform.position = destination.position;
    }
}
