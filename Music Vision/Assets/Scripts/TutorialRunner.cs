using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialRunner : MonoBehaviour
{
    private List<Tutorial> tutorials;
    [SerializeField]
    private GameObject textPrompt;
    [SerializeField]
    private GameObject exitDialogPrefab;
    private GameObject taskPrompt;
    [SerializeField]
    private GameObject screenTaskPrompt;
    [SerializeField]
    private GameObject keyboardTaskPrompt;


    public string nameInput { get; private set; } = "";
    public bool MMValue { get; private set; } = false;

    private int runningTutorial = -1;
    private bool continueInput = false;
    private bool confirmInput = false;
    private bool skipInput = false;
    private bool MMInput = false;
    private bool exitDialogOpen = false;
    private bool repeatInput;

    public bool isRunning { get; private set; }

    void Start()
    {
        tutorials = new List<Tutorial>();
        tutorials.Add(new tControls());
        tutorials.Add(new tSemitones());
        tutorials.Add(new tNotation());
        tutorials.Add(new tAccidentals());
        tutorials.Add(new tScales());
        tutorials.Add(new tChords());
        taskPrompt = screenTaskPrompt;
        switchTutorial(0);
    }

    private void startTutorial(int index)
    {
        tutorials[index].startTutorial(this);
        runningTutorial = index;
        isRunning = true;
    }

    private void stopTutorial()
    {
        StopAllCoroutines();
        runningTutorial = -1;
        isRunning = false;
    }

    private void exitTutorial()
    {
        tutorials[runningTutorial].exitCleanup();
        stopTutorial();
        TTS.stopTTS();
        MusicController.instance.initializeFreeMode();
        resetContinue();
        resetSkip(); 
        hideTaskPrompt();
    }

    public void switchTutorial(int index)
    {
        MusicController.instance.initializeTutorialMode();
        if (isRunning)
        {
            tutorials[runningTutorial].exitCleanup();
            StopAllCoroutines();
            TTS.stopTTS();
            resetContinue();
            resetSkip();
            hideTaskPrompt();
            tutorials[index].startTutorial(this);
            runningTutorial = index;
        } else
        {
            startTutorial(index);
        }     
    }

    public bool waitForContinue()
    {
        if (continueInput)
        {
            textPrompt.SetActive(false);
            continueInput = false;
            return true;
        } else {  return false; }
    }

    public bool waitForSkip()
    {
        if (skipInput)
        {
            textPrompt.SetActive(false);
            skipInput = false;
            return true;
        }
        else { return false; }
    }

    public bool waitForRepeat() 
    {
        if (repeatInput)
        {
            repeatInput = false;
            return true;
        } else { return false; }
    }

    public bool waitForName()
    {
        if(nameInput != "")
        {
            return true;
        } else { return false; }
    }

    public bool waitForConfirm()
    {
        if (confirmInput)
        {
            confirmInput = false;
            return true;
        }
        else { return false; }
    }

    public bool waitForMajorMinor()
    {
        if (MMInput)
        {
            MMInput = false;
            return true;
        }
        else { return false; }
    }

    public void displayTextPrompt(string text)
    {
        textPrompt.GetComponentInChildren<TextMeshProUGUI>().text = text;
        textPrompt.SetActive(true);
    }

    public void displayTextPrompt()
    {
        textPrompt.SetActive(true);
    }

    public void hideTextPrompt()
    {
        textPrompt.SetActive(false);
    }

    public void useScreenTaskPrompt()
    {
        taskPrompt = screenTaskPrompt;
    }

    public void useKeyboardTaskPrompt()
    {
        taskPrompt = keyboardTaskPrompt;
    }

    public void displayTaskPrompt(string text)
    {
        if(taskPrompt.GetComponentInChildren<TextMeshProUGUI>() == null)
        {
            taskPrompt.GetComponentInChildren<TextMeshPro>().text = text;
        } else
        {
            taskPrompt.GetComponentInChildren<TextMeshProUGUI>().text = text;
        }
        taskPrompt.SetActive(true);
    }

    public void displayTaskPrompt()
    {
        taskPrompt.SetActive(true);
    }

    public void hideTaskPrompt() 
    {
        taskPrompt.SetActive(false);
    }

    public bool taskPromptActive()
    {
        return taskPrompt.activeSelf ? true : false;
    }

    public void continueInputEntered()
    {
        continueInput = true;
    }

    public void skipInputEntered()
    {
        skipInput = true;
    }

    public void repeatInputEntered()
    {
        repeatInput = true;
    }

    public void nameInputEntered(string key)
    {
        nameInput = key;
    }

    public void confirmInputEntered()
    {
        confirmInput = true;
    }

    public void majorMinorInputEntered(bool value)
    {
        MMInput = true;
        MMValue = value;
    }

    public void exitInputEntered()
    {
        if (!isRunning || exitDialogOpen) { return; }
        Dialog dialog = Dialog.Open(exitDialogPrefab, DialogButtonType.Yes | DialogButtonType.No,
                                    "Exit Tutorial", "Are you sure you want to exit the tutorial?", true);
        if(dialog != null)
        {
            exitDialogOpen = true;
            dialog.OnClosed += (DialogResult res) => {
                if(res.Result == DialogButtonType.Yes) { exitTutorial(); }
                exitDialogOpen = false;
            };
        }
        
    }
    public void resetSkip()
    {
        textPrompt.SetActive(false);
        skipInput = false;
    } 
    
    public void resetContinue()
    {
        textPrompt.SetActive(false);
        continueInput = false;
    }

    public void resetRepeat()
    {
        repeatInput = false;
    }

    public void resetNameInput()
    {
        nameInput = "";
    }

    public void resetConfirm()
    {
        confirmInput = false;
    }

    public void resetMajorMinor()
    {
        MMInput = false;
    }
}
