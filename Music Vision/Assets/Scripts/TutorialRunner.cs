using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialRunner : MonoBehaviour
{
    private List<Tutorial> tutorials;
    [SerializeField]
    private GameObject prompt;
    private Coroutine runningTutorial;
    private bool continueInput = false;
    private bool skipInput = false;

    public bool isRunning { get; private set; }

    void Start()
    {
        tutorials = new List<Tutorial>();
        tutorials.Add(new tSemitones());
    }

    private void startTutorial(int index)
    {
        runningTutorial = tutorials[index].startTutorial(this);
        isRunning = true;
    }

    public void stopTutorial()
    {
        StopCoroutine(runningTutorial);
        runningTutorial = null;
        isRunning = false;
    }

    public void switchTutorial(int index)
    {
        if (isRunning)
        {
            StopCoroutine(runningTutorial);
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
            prompt.SetActive(false);
            continueInput = false;
            return true;
        } else {  return false; }
    }

    public bool waitForSkip()
    {
        if (skipInput)
        {
            prompt.SetActive(false);
            skipInput = false;
            return true;
        }
        else { return false; }
    }

    public void displayPrompt(string text)
    {
        prompt.GetComponentInChildren<TextMeshProUGUI>().text = text;
        prompt.SetActive(true);
    }

    public void continueInputEntered()
    {
        continueInput = true;
    }

    public void skipInputEntered()
    {
        skipInput = true;
    }

    public void resetSkip()
    {
        prompt.SetActive(false);
        skipInput = false;
    } 
    
    public void resetContinue()
    {
        prompt.SetActive(false);
        continueInput = false;
    }
}
