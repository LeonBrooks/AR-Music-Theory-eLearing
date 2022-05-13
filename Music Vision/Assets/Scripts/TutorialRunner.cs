using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialRunner : MonoBehaviour
{
    [SerializeField]
    private List<Tutorial> tutorials;
    private Coroutine runningTutorial;

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
}
