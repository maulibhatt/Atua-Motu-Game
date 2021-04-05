using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isPaused;
    public GameObject pausePanel;
    public GameObject inventoryPanel;
    public GameObject questsPanel;
    public GameObject InstructionPanel;
    private bool isInventoryActive = false;
    private bool isQuestsActive = false;
    //public string mainMenu;

    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Pause"))
        {
            if (isInventoryActive)
            {
                pausePanel.SetActive(true);
                inventoryPanel.SetActive(false);
                isInventoryActive = false;
                return;
            }

            if (isQuestsActive)
            {
                pausePanel.SetActive(true);
                questsPanel.SetActive(false);
                isQuestsActive = false;
                return;
            }
            isPaused = !isPaused;
            if (isPaused)
            {
                PauseGame();
            }
            else 
            {
                UnpauseGame();
            }
        }
    }

    public void ShowInventory()
    {
        pausePanel.SetActive(false);
        inventoryPanel.SetActive(true);
        isInventoryActive = true;
    }

    public void ShowQuests()
    {
        pausePanel.SetActive(false);
        questsPanel.SetActive(true);
        isQuestsActive = true;
    }

    public void Resume()
    {
        isPaused = false;
        UnpauseGame();
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    void UnpauseGame()
    {
        pausePanel.SetActive(false);
        inventoryPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void Abandon()
    {
        List<string> quests = new List<string>() { "Rocky", "Igneous", "Erised", "Bones" };
        foreach (string quest in quests)
        {
            if (GameState.CheckActiveString(quest))
            {
                GameState.DeactivateQuest(quest);
            }
        }
        GameState.StartNewDay();
        SceneManager.LoadScene("Town");

    }

    public void ViewActiveQuests()
    {
        //add code here
    }

    public void ShowHowToPlay()
    {
        InstructionPanel.SetActive(true);
        pausePanel.SetActive(false);
    }

    public void HideHowToPlay()
    {
        InstructionPanel.SetActive(false);
        pausePanel.SetActive(true);
    }
}
