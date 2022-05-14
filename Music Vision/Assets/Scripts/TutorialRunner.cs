using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialRunner : MonoBehaviour
{
    [SerializeField]
    private List<Tutorial> tutorials;
    private Coroutine runningTutorial;
    private bool continueInput = false;

    public bool isRunning { get; private set; }


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
}
