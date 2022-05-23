using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tutorial
{
    public TutorialRunner runner;
    protected MusicController mc;
    protected bool skipped;
    protected float deacWaitTime = 2f;
    protected List<GameObject> tooltips;
    protected static SheetMusic sheet;

    public Tutorial()
    {
        mc = MusicController.instance;
        if(sheet == null)
        {
            sheet = GameObject.Find("SheetMusicContainer/SheetMusic").GetComponent<SheetMusic>();
        }
        skipped = false;
        tooltips = new List<GameObject>();
    }

    public Coroutine startTutorial(TutorialRunner runner)
    {
        this.runner = runner;
        return runner.StartCoroutine(tutorial());
    }

    public void clearTooltips()
    {
        foreach (GameObject tooltip in tooltips)
        {
            Object.Destroy(tooltip);
        }
        tooltips.Clear();
    }

    private IEnumerator waitForKeyOrSkipCoroutine(Key key,string taskPromptText, bool showSkipPrompt, bool resetUserInput, params Key[] otherKeys)
    {
        bool pressed = false;
        skipped = false;
        runner.resetSkip();
        mc.inputEnabled = true;
        if (showSkipPrompt) { runner.displayTextPrompt("Say skip to reveal the answer"); }
        runner.displayTaskPrompt(taskPromptText);

        while(true)
        {
            if(runner.waitForSkip()) 
            { 
                mc.inputEnabled = resetUserInput ? false : true;
                skipped = true;
                runner.hideTaskPrompt();
                yield break;
            }
            
            if(mc.areActive(key, otherKeys)) 
            { 
                if(pressed)
                {
                    mc.inputEnabled = resetUserInput ? false : true;
                    runner.resetSkip();
                    runner.hideTaskPrompt();
                    yield break;
                } else
                {
                    pressed = true;
                    yield return new WaitForSeconds(1);
                }
            } else { pressed = false; yield return null; }
        }
    }

    protected Coroutine waitForKeyOrSkip(Key key, string taskPromptText, bool showSkipPrompt = true, bool resetUserInput = true, params Key[] otherKeys)
    {
        return runner.StartCoroutine(waitForKeyOrSkipCoroutine(key, taskPromptText, showSkipPrompt, resetUserInput, otherKeys));
    }

    private IEnumerator waitForContinueCoroutine(bool showPrompt)
    {
        runner.resetContinue();
        if(showPrompt) { runner.displayTextPrompt("Say continue to move on"); }
        yield return new WaitUntil(() => runner.waitForContinue());
    }

    protected Coroutine waitForContinue(bool showPrompt = true)
    {
        return runner.StartCoroutine(waitForContinueCoroutine(showPrompt));
    }

    private IEnumerator nextTutorialOrExitCoroutine(int successor)
    {
        TTS.speakText("If you want to go on to the next tutorial say continue. If you want to quit inestead, say exit.");
        runner.displayTaskPrompt("Say exit to quit");
        yield return waitForContinue();
        runner.switchTutorial(successor);
    }

    protected Coroutine nextTutorialOrExit(int successor)
    {
        return runner.StartCoroutine(nextTutorialOrExitCoroutine(successor));
    }

    private IEnumerator hitKeyCoroutine(Key key, Color color, bool draw, bool fix, bool resetColor)
    {
        mc.noteActivated(key,color, fix, draw);
        yield return new WaitForSeconds(deacWaitTime);
        mc.noteDeactivated(key,resetColor, draw);
    }

    protected Coroutine hitKey(Key key, Color color = Color.Black, bool draw = true, bool fix = false, bool resetColor = false) 
    {
        return runner.StartCoroutine(hitKeyCoroutine(key, color, draw, fix, resetColor));
    }

    protected WaitWhile speakAndWait(string text)
    {
        TTS.speakText(text);
        return new WaitWhile(() => TTS.isSpeaking());
    }
    public abstract IEnumerator tutorial();
}
