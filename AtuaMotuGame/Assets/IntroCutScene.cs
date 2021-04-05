using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroCutScene : MonoBehaviour
{
    [SerializeField] private TextAsset intro;
    [SerializeField] private Story myStory;

    [Header("UI Variables")]
    [SerializeField] private GameObject CutSceneCanvas;
    [SerializeField] private GameObject dialogPrefab;
    [SerializeField] private GameObject dialogHolder;
    [SerializeField] private ScrollRect dialogScrollbar;
    [SerializeField] private GameObject IntroStoryPanel;
    [SerializeField] private GameObject InstructionPanel;
    [SerializeField] private GameObject MainMenuCanvas;
    [SerializeField] public InitGame GameInitializer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IntroStoryPanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                RefreshView();
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                EnableGameInstructions();
            }
        }
        else if(InstructionPanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                BeginGame();
            }
        }
    }

    public void EnableCutSceneCanvas()
    {
        CutSceneCanvas.SetActive(true);
        MainMenuCanvas.SetActive(false);
        IntroStoryPanel.SetActive(true);
        SetStory();
        RefreshView();
    }

    public void SetStory()
    {
        if (intro)
        {
            DeleteOldDialogs();
            myStory = new Story(intro.text);
        }
    }

    public void EnableGameInstructions()
    {
        IntroStoryPanel.SetActive(false);
        InstructionPanel.SetActive(true);
    }

    public void BeginGame()
    {
        CutSceneCanvas.SetActive(false);
        GameInitializer.StartNewGame();
        SceneManager.LoadScene("Town");

    }

    public void RefreshView()
    {
        // Check if story can continue
        if (myStory.canContinue)
        {
            // If it can, then show the next line as a mew dialog
            MakeNewDialog(myStory.Continue());
        }
        else
        {
            EnableGameInstructions();
        }
        // Scrolls to the bottom
        dialogScrollbar.verticalNormalizedPosition = 0f;
        StartCoroutine(ScrollCo());    
    }


    void MakeNewDialog(string newDialog)
    {
        Debug.Log("The next line = " + newDialog);
        // Instantiates the dialog object (the prefab) on the dialog holder
        BossDialogObject newDialogObject = Instantiate(dialogPrefab, dialogHolder.transform).GetComponent<BossDialogObject>();
        StartCoroutine(ScrollCo());
        newDialogObject.Setup(newDialog);
        //afterDialog();
    }

    void DeleteOldDialogs()
    {
        for (int i = 0; i < dialogHolder.transform.childCount; i++)
        {
            Destroy(dialogHolder.transform.GetChild(i).gameObject);
        }
    }

    IEnumerator ScrollCo()
    {
        // waits one frame
        yield return null;
        dialogScrollbar.verticalNormalizedPosition = 0f;
    }

}
