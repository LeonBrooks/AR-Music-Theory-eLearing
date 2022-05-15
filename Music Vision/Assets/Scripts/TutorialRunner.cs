using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialRunner : MonoBehaviour
{
    private List<Tutorial> tutorials;
    [SerializeField]
    private GameObject continuePrompt;
    private Coroutine runningTutorial;
    [SerializeField]
    private bool continueInput = false;

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
            continuePrompt.SetActive(false);
            continueInput = false;
            return true;
        } else {  return false; }
    }

    public void continueReset()
    {
        continueInput = false;
    }

    public void continueInputEntered()
    {
        continueInput = true;
    }

    public void displayContinuePrompt()
    {
        continuePrompt.SetActive(true);
    }
}
