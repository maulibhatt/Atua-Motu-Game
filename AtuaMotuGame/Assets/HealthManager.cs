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
    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
        GameObject UI = GameObject.Find("HealthUI");
        if

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
        if (Instance.currentLives > 0)
        {
            Instance.currentLives--;
            displayLives();
        }
    }

    void displayLives()
    {
        int i = Instance.currentLives;
        while (i < 3)
        {
            Instance.hearts[i].SetActive(false);
            i++;
        }
    }
}
