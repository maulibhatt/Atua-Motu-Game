using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    private int currentLives;
    private GameObject[] hearts;
    public bool GodMode = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
        GameObject UI = GameObject.Find("HealthUI");
        if (Instance == null && UI != null)
            {
                DontDestroyOnLoad(gameObject);
                Instance = this;
                Instance.currentLives = 3;
            }
        else if (Instance != this || UI == null)
        {
            Destroy(gameObject);
        }
        Instance.hearts = new GameObject[] { heart1, heart2, heart3 };
        displayLives();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void removeLife()
    {
        if (Instance.currentLives > 0 && !GodMode)
        {
            Instance.currentLives--;
            displayLives();
        }
    }

    public int GetLives()
    {
        return Instance.currentLives;
    }
    public void displayLives()
    {
        int i = Instance.currentLives;
        while (i < 3)
        {
            Instance.hearts[i].SetActive(false);
            i++;
        }
    }
}
