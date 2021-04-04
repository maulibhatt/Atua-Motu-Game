using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;

public class FinalBossDialog : MonoBehaviour
{
    [SerializeField] private TextAsset bossConvo;
    [SerializeField] private Story myStory;
    [SerializeField] private bool enableSpacebar;
    
    [Header("UI Variables")]
    [SerializeField] private GameObject finalBossCanvas;
    [SerializeField] private GameObject dialogPrefab;
    [SerializeField] private GameObject choicePrefab;

    [SerializeField] private GameObject dialogHolder;
    [SerializeField] private GameObject choiceHolder;
    [SerializeField] private ScrollRect dialogScrollbar;
    [SerializeField] private GameObject spaceText;
    [SerializeField] private GameObject newGameButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enableSpacebar && Input.GetKeyDown(KeyCode.Space))
        {

        }
    }

    public void EnableBossCanvas()
    {
        SetStory();

        RefreshView();
    }
    public void SetStory()
    {
        if (bossConvo)
        {
            DeleteOldDialogs();
            myStory = new Story(bossConvo.text);
        }
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

            if (myStory.currentChoices.Count > 0)
            {
                MakeNewChoices();
            }
            // No more choices to make
            else
            {
                //EndConfrontation();
            }
            // Scrolls to the bottom
            StartCoroutine(ScrollCo());
        }
            
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

     void RemoveOldChoices()
    {
        for (int i = 0; i < choiceHolder.transform.childCount; i++)
        {
            Destroy(choiceHolder.transform.GetChild(i).gameObject);
        }

    }
    void MakeNewChoices()
    {
        // First remove existing buttons
        // add the current choices to the choice holder.
        for (int i = 0; i < myStory.currentChoices.Count; i++)
        {
            MakeNewResponse(myStory.currentChoices[i].text, i);
        }
    }

    void MakeNewResponse(string newDialog, int choiceValue)
    {
        BossChoiceObject newChoiceObject = Instantiate(choicePrefab, choiceHolder.transform).GetComponent<BossChoiceObject>();
        newChoiceObject.Setup(newDialog, choiceValue);

        Button choiceButton = newChoiceObject.gameObject.GetComponent<Button>();
        if (choiceButton)
        {
            // Adds the choice value to the listener that is in the onclick part of the button.
            choiceButton.onClick.AddListener(delegate { ChooseChoice(choiceValue); });
        }
    }

    void ChooseChoice(int choiceIndex)
    {
        myStory.ChooseChoiceIndex(choiceIndex);
        RemoveOldChoices();
        RefreshView();
    }

    IEnumerator ScrollCo()
    {
        // waits one frame
        yield return null;
        dialogScrollbar.verticalNormalizedPosition = 0f;
    }


}
