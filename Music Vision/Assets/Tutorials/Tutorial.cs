using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public abstract class Tutorial
{
    public TutorialRunner runner;
    protected MusicController mc;
    protected KeyManager km;
    protected bool correctAnswer;
    protected float deacWaitTime = 2f;
    protected List<Tooltip> tooltips;
    protected static SheetMusic sheet;
    protected Vector3 defaultTooltipScale;
    protected GameObject tootipPrefab;
    protected string repeatText;
    protected HashSet<RepeatData> repeatKeys;

    protected struct RepeatData
    {
        public Key key;
        public Color color;
        public bool wait;

        public RepeatData(Key key, Color color, bool wait)
        {
            this.key = key;
            this.color = color;
            this.wait = wait;
        }
    }

    public Tutorial()
    {
        mc = MusicController.instance;
        if (sheet == null)
        {
            sheet = GameObject.Find("SheetMusicContainer/SheetMusic").GetComponent<SheetMusic>();
        }
        correctAnswer = false;
        tooltips = new List<Tooltip>();
        defaultTooltipScale = new Vector3(0.8f, 0.8f, 0.8f);
        tootipPrefab = Resources.Load("Tooltip") as GameObject;
        repeatText = "";
        repeatKeys = new HashSet<RepeatData>();
        km = GameObject.Find("KeyboardPlacer/RotationOffsetContainer/Keyboard").GetComponent<KeyManager>();
    }

    public abstract IEnumerator tutorial();
    public Coroutine startTutorial(TutorialRunner runner)
    {
        this.runner = runner;
        runner.useScreenTaskPrompt();
        return runner.StartCoroutine(tutorial());
    }

    protected Tooltip instantiateTooltip(Transform parent, Vector3 pos, string text, Vector3? scale = null)
    {
        Tooltip tooltip = UnityEngine.Object.Instantiate(tootipPrefab, parent, false).GetComponent<Tooltip>();
        tooltip.transform.localPosition = pos;
        tooltip.transform.localScale = scale ?? defaultTooltipScale;
        tooltip.changeText(text);
        tooltips.RemoveAll(t => t == null);
        tooltips.Add(tooltip);
        return tooltip;
    }

    protected void clearTooltips()
    {
        foreach (Tooltip tooltip in tooltips)
        {
            if(tooltip != null)
            {
                UnityEngine.Object.Destroy(tooltip.gameObject);
            }
        }
        tooltips.Clear();
    }

    protected void initRepeat()
    {
        repeatKeys.Clear();
        repeatText = "";
    }

    public virtual void exitCleanup() 
    {
        clearTooltips();
        initRepeat();
    }

    private IEnumerator waitForKeyCoroutine(Key key,string taskPromptText, bool showSkipPrompt, bool resetUserInput, bool alternative, params Key[] otherKeys)
    {
        bool pressed = false;
        runner.resetSkip();
        runner.resetRepeat();
        mc.keyInputEnabled = true;
        if (showSkipPrompt) { runner.displayTextPrompt("Say skip to reveal the answer"); }
        runner.displayTaskPrompt(taskPromptText);

        while(true)
        {
            if(runner.waitForSkip()) 
            { 
                mc.keyInputEnabled = resetUserInput ? false : true;
                correctAnswer = false;
                runner.hideTaskPrompt();
                initRepeat();
                mc.resetAllKeys();
                yield break;
            }

            if (runner.waitForRepeat())
            {
                yield return repeat();
            }

            if (mc.areActive(key, alternative,otherKeys)) 
            { 
                if(pressed)
                {
                    mc.keyInputEnabled = resetUserInput ? false : true;
                    correctAnswer = true;
                    runner.hideTaskPrompt();
                    initRepeat();
                    mc.resetAllKeys();
                    yield break;
                } else
                {
                    pressed = true;
                    yield return new WaitForSeconds(1);
                }
            } else { pressed = false; yield return null; }
        }
    }

    protected Coroutine waitForKey(Key key, string taskPromptText, bool showSkipPrompt = true, bool resetUserInput = true,
        bool alternative = false, params Key[] otherKeys)
    {
        return runner.StartCoroutine(waitForKeyCoroutine(key, taskPromptText, showSkipPrompt, resetUserInput, alternative, otherKeys));
    }

    private IEnumerator waitForNameCoroutine(Key key, int flatOrSharp, string taskPromptText, bool showSkipPrompt)
    {
        runner.resetSkip();
        runner.resetRepeat();
        runner.resetNameInput();
        if (showSkipPrompt) { runner.displayTextPrompt("Say skip to reveal the answer"); }
        runner.displayTaskPrompt(taskPromptText);

        while (true)
        {
            if (runner.waitForSkip())
            {
                correctAnswer = false;
                runner.hideTaskPrompt();
                initRepeat();
                yield break;
            }

            if (runner.waitForRepeat())
            {
                yield return repeat();
            }

            if (runner.waitForName())
            {
                if(flatOrSharp != 0) { flatOrSharp = flatOrSharp < 0 ? 1 : 2; }
                if(runner.nameInput[0] == key.ToString()[0] && flatOrSharp == int.Parse("" + runner.nameInput[1]))
                {
                    correctAnswer = true;
                } else { correctAnswer = false; }

                runner.hideTaskPrompt();
                initRepeat();
                yield break;
            }
            yield return null;
        }
    }

    protected Coroutine waitForName(Key key, int flatOrSharp, string taskPromptText, bool showSkipPrompt = true)
    {
        return runner.StartCoroutine(waitForNameCoroutine(key, flatOrSharp, taskPromptText, showSkipPrompt));
    }

    private IEnumerator waitForNoteInputCoroutine(Note[] notes, Key[] goalPostions, int[] goalFlatOrSharp, string taskPromptText, bool showSkipPrompt)
    {
        if(notes.Length != goalPostions.Length || notes.Length != goalFlatOrSharp.Length)
        {
            Debug.Log("Goal arrays must have the same length as note array");
            yield break;
        }
        runner.resetSkip();
        runner.resetRepeat();
        runner.resetConfirm();
        if (showSkipPrompt) { runner.displayTextPrompt("Say confirm when you are done or skip to reveal the answer"); }
        runner.displayTaskPrompt(taskPromptText);
        mc.noteInputEnabled = true;

        while (true)
        {
            if (runner.waitForSkip())
            {
                correctAnswer = false;
                mc.noteInputEnabled = false;
                runner.hideTaskPrompt();
                initRepeat();
                yield break;
            }

            if (runner.waitForRepeat())
            {
                yield return repeat();
            }

            if (runner.waitForConfirm())
            {
                mc.noteInputEnabled = false;
                for (int i = 0; i < goalPostions.Length; i++)
                {
                    if(!Array.Exists(notes, n => n.key == goalPostions[i] && n.flatOrSharp == goalFlatOrSharp[i]))
                    {
                        correctAnswer = false;
                        runner.hideTaskPrompt();
                        initRepeat();
                        yield break;
                    }
                }

                correctAnswer = true;
                runner.hideTaskPrompt();
                initRepeat();
                yield break;
            }

            yield return null;
        }
    }

    protected Coroutine waitForNoteInput(Note[] notes, Key[] goalPostions, int[] goalFlatOrSharp, string taskPromptText, bool showSkipPrompt = true)
    {
        return runner.StartCoroutine(waitForNoteInputCoroutine(notes, goalPostions, goalFlatOrSharp, taskPromptText, showSkipPrompt));
    }

    private IEnumerator waitForMajorMinorInputCoroutine(bool majorExpected, string taskPromptText, bool showSkipPrompt)
    {
        runner.resetSkip();
        runner.resetRepeat();
        runner.resetMajorMinor();
        if (showSkipPrompt) { runner.displayTextPrompt("Say confirm when you are done or skip to reveal the answer"); }
        runner.displayTaskPrompt(taskPromptText);

        while (true)
        {
            if (runner.waitForSkip())
            {
                correctAnswer = false;
                runner.hideTaskPrompt();
                initRepeat();
                yield break;
            }

            if (runner.waitForRepeat())
            {
                yield return repeat();
            }

            if (runner.waitForMajorMinor())
            {
                if(majorExpected == runner.MMValue) { correctAnswer = true; } else { correctAnswer = false; }
                runner.hideTaskPrompt();
                initRepeat();
                yield break;
            }
            yield return null;
        }
    }
    protected Coroutine waitForMajorMinorInput(bool majorExpected, string taskPromptText, bool showSkipPrompt = true)
    {
        return runner.StartCoroutine(waitForMajorMinorInputCoroutine(majorExpected, taskPromptText, showSkipPrompt));
    }

    private IEnumerator waitForContinueCoroutine(bool showPrompt)
    {
        runner.resetContinue();
        runner.resetRepeat();
        if(showPrompt) { runner.displayTextPrompt("Say continue to move on"); }

        while (true)
        {
            if (runner.waitForRepeat())
            {
                yield return repeat();
            }

            if (runner.waitForContinue())
            {
                initRepeat();
                yield break;
            }
            yield return null;
        }
    }

    protected Coroutine waitForContinue(bool showPrompt = true)
    {
        return runner.StartCoroutine(waitForContinueCoroutine(showPrompt));
    }

    private IEnumerator nextTutorialOrExitCoroutine(int successor)
    {
        TTS.speakText("If you want to go on to the next tutorial say continue. If you want to quit instead, say exit.");
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

    protected Coroutine hitKey(Key key, Color color = Color.Black, bool draw = true, bool fix = false, bool resetColor = false, 
        bool addToRepeat = true, bool wait = false) 
    {
        if (addToRepeat) { repeatKeys.Add(new RepeatData(key, color, wait)); }
        return runner.StartCoroutine(hitKeyCoroutine(key, color, draw, fix, resetColor));
    }

    protected WaitWhile speakAndWait(string text, bool addToRepeat = true)
    {
        if(TTS.isSpeaking()) { TTS.stopTTS(); }
        TTS.speakText(text);
        if(addToRepeat) { repeatText += " " + text; }
        return new WaitWhile(() => TTS.isSpeaking());
    }

    private IEnumerator repeatCoroutine()
    {
        bool activateTaskPrompt = runner.taskPromptActive();
        runner.hideTaskPrompt();
        runner.hideTextPrompt();
        if (TTS.isSpeaking()) { TTS.stopTTS(); }
        TTS.speakText(repeatText);
        yield return new WaitWhile(() => TTS.isSpeaking());
        foreach (RepeatData d in repeatKeys)
        {
            if (d.wait)
            {
                yield return hitKey(d.key, d.color, draw: false, addToRepeat: false);
            }
            else { hitKey(d.key, d.color, draw: false, addToRepeat: false); }
        }
        runner.displayTextPrompt();
        if(activateTaskPrompt) { runner.displayTaskPrompt(); }
    }
    protected Coroutine repeat()
    {
        return runner.StartCoroutine(repeatCoroutine());
    }
}
