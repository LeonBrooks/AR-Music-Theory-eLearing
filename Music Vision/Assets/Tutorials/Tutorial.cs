using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tutorial
{
    public TutorialRunner runner;
    protected MusicController mc;

    public Tutorial()
    {
        mc = MusicController.instance;
    }

    public Coroutine startTutorial(TutorialRunner runner)
    {
        this.runner = runner;
        return runner.StartCoroutine(tutorial());
    }

    protected IEnumerator waitForKeyOrSkip(Key key, bool showPrompt = true, bool resetUserInput = true, params Key[] otherKeys)
    {
        bool pressed = false;
        runner.resetSkip();
        mc.inputEnabled = true;
        if (showPrompt) { runner.displayPrompt("Say skip to reveal the answer"); }

        while(true)
        {
            if(runner.waitForSkip()) { mc.inputEnabled = resetUserInput ? false : true; yield break; }
            
            if(mc.areActive(key, otherKeys)) 
            { 
                if(pressed)
                {
                    mc.inputEnabled = resetUserInput ? false : true;
                    runner.resetSkip();
                    yield break;
                } else
                {
                    pressed = true;
                    yield return new WaitForSeconds(1);
                }
            } else { pressed = false;  yield return null; }
        }
    }

    protected IEnumerator waitForContinue(bool showPrompt = true)
    {
        runner.resetContinue();
        if(showPrompt) { runner.displayPrompt("Say continue to move on"); }
        yield return new WaitUntil(() => runner.waitForContinue());
    }

    public abstract IEnumerator tutorial();
}
