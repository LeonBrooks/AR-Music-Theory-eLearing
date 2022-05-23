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
    private GameObject taskPrompt;
    [SerializeField]
    private GameObject exitDialogPrefab;
    [SerializeField]
    private GameObject tootipPrefab;

    private Coroutine runningTutorial;
    private bool continueInput = false;
    private bool skipInput = false;
    private Vector3 defaultTooltipScale;

    public bool isRunning { get; private set; }

    void Start()
    {
        tutorials = new List<Tutorial>();
        tutorials.Add(new tSemitones());
        tutorials.Add(new tNotation());
        defaultTooltipScale = new Vector3(0.03f, 0.03f, 0.03f);
    }

    private void startTutorial(int index)
    {
        runningTutorial = tutorials[index].startTutorial(this);
        isRunning = true;
    }

    private void stopTutorial()
    {
        StopAllCoroutines();
        runningTutorial = null;
        isRunning = false;
    }

    private void exitTutorial()
    {
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
            StopAllCoroutines();
            TTS.stopTTS();
            resetContinue();
            resetSkip();
            hideTaskPrompt();
            runningTutorial = tutorials[index].startTutorial(this);
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

    public void displayTextPrompt(string text)
    {
        textPrompt.GetComponentInChildren<TextMeshProUGUI>().text = text;
        textPrompt.SetActive(true);
    }

    public void displayTaskPrompt(string text)
    {
        taskPrompt.GetComponentInChildren<TextMeshProUGUI>().text = text;
        taskPrompt.SetActive(true);
    }

    public void hideTaskPrompt() 
    {
        taskPrompt.SetActive(false);
    }

    public void continueInputEntered()
    {
        continueInput = true;
    }

    public void skipInputEntered()
    {
        skipInput = true;
    }

    public void exitInputEntered()
    {
        if (!isRunning) { return; }
        Dialog dialog = Dialog.Open(exitDialogPrefab, DialogButtonType.Yes | DialogButtonType.No,
                                    "Exit Tutorial", "Are you sure you want to exit the tutorial?", false);
        if(dialog != null)
        {
            dialog.OnClosed += (DialogResult res) => {
                if(res.Result == DialogButtonType.Yes) { exitTutorial(); }
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

    public GameObject instantiateTooltip(Transform parent, Vector3 pos, string text, Vector3? scale = null)
    {
        GameObject tooltip = Instantiate(tootipPrefab, parent, false);
        tooltip.transform.localPosition = pos;
        tooltip.transform.localScale = scale ?? defaultTooltipScale;
        tooltip.GetComponentInChildren<TextMeshPro>().text = text;
        return tooltip;
    }

}
