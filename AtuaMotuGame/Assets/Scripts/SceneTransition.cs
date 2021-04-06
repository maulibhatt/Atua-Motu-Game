using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneTransition : MonoBehaviour
{
    public Vector2 position;
    public string scene;
    public bool checkAbandonQuest = false;
    public string quest;
    public GameObject abandonQuestMenu;
    

    private Button yes;
    private Button no;
    private bool givePrompt = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (checkAbandonQuest && GameState.CheckActiveString(quest))
            {
                abandonQuestMenu.SetActive(true);
                Button yes = abandonQuestMenu.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.GetComponent<Button>();
                yes.onClick.AddListener(performSceneTransition);
                Button no = abandonQuestMenu.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.GetComponent<Button>();
                no.onClick.AddListener(closeMenu);
                givePrompt = true;
            } else
            {
                performSceneTransition();
            }

            
        }
    }

    private void performSceneTransition()
    {
        GameObject HM = GameObject.Find("HealthManager");
        if (HM != null)
        {
            Destroy(HM);
        }

        if (!givePrompt)
        {
            GameState.SetLastSceneLocation(SceneManager.GetActiveScene().name);
            GameState.PlayerPosition = position;
            SceneManager.LoadScene(scene);
        } else
        {
            GameState.AbandonQuest(quest);
        }

    }

    private void closeMenu()
    {
        abandonQuestMenu.SetActive(false);

    }

}
