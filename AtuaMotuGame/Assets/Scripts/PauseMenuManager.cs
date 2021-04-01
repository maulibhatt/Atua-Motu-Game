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
    private bool isInventoryActive = false;
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

    public void Resume()
    {
        isPaused = false;
        UnpauseGame();
    }

    void PauseGame()
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
        //needs to be coded with scene and quest shit
    }

    public void ViewActiveQuests()
    {
        //add code here
    }
}
