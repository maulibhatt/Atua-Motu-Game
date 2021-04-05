using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{

    private float uiTimer = 0f;
    private GameObject SignDialogBox;
    private GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 newPos = GameState.SpawnPosition(SceneManager.GetActiveScene().name);
        if (newPos != new Vector3(-1, -1, -1) && newPos != new Vector3(-2, -2, -2))
        {
            GameObject player = GameObject.Find("Player");
            player.transform.position = newPos;
        } else if (newPos == new Vector3(-1f,-1f,-1f))
        {
            SignDialogBox = GameObject.Find("Sign Dialog Canvas").transform.GetChild(1).gameObject;
            text = SignDialogBox.transform.GetChild(0).gameObject;
            text.GetComponent<Text>().text = "Day " + GameState.day.ToString();
            SignDialogBox.SetActive(true);
            uiTimer = 5f;
            if (GameState.day == 10)
            {
                GameObject.Find("Grid").transform.GetChild(5).gameObject.SetActive(true);
                GameObject.Find("Grid").transform.GetChild(6).gameObject.SetActive(true);
                GameObject player = GameObject.Find("Player");
                player.transform.position = new Vector3(11.18f, 6.48f, 0f);

            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (uiTimer > 0f)
        {
            uiTimer -= Time.deltaTime;
            if (uiTimer <= 0f)
            {
                SignDialogBox.SetActive(false);
            }
        }
    }
}
