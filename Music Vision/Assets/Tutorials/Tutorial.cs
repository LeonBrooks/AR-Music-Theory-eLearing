using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Tutorial
{
    public TutorialRunner runner;
    protected MusicController mc = MusicController.instance;


    public Coroutine startTutorial(TutorialRunner runner)
    {
        this.runner = runner;
        return runner.StartCoroutine(tutorial());
    }
    public abstract IEnumerator tutorial();
}
