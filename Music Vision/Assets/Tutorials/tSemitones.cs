using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tSemitones : Tutorial
{
    public override IEnumerator tutorial()
    {
        mc.initializeTutorialMode();
        string intro = @"Hello. Welcome to the first tutorial. Here we will cover one of the baisc concepts of classical music theory: The semitone.
                         The smitone is the smallest unit in classical music theory and bulids the foundation to understandin more complex concepts.
                         Take a look at the keyboard and say continue when you are ready to move on.";

        TTS.speakText(intro);
        yield return new WaitWhile(() => TTS.isSpeaking());
        runner.displayContinuePrompt();
        yield return new WaitUntil(() => runner.waitForContinue());


        TTS.speakText("Every key on the keyboard is excatly one semitone away from the next. The distance between these keys is one semitone step.");
        yield return new WaitWhile(() => TTS.isSpeaking());
        mc.noteActivated(Key.C4, Color.Blue);
        mc.noteActivated(Key.CS4, Color.Blue);
        yield return new WaitForSeconds(1);
        mc.noteDeactivated(Key.C4, false);
        mc.noteDeactivated(Key.CS4, false);


        TTS.speakText("These two are also one semitone step apart.");
        yield return new WaitWhile(() => TTS.isSpeaking());
        mc.noteActivated(Key.E4, Color.Green);
        mc.noteActivated(Key.F4, Color.Green);
        yield return new WaitForSeconds(1);
        mc.noteDeactivated(Key.E4, false);
        mc.noteDeactivated(Key.F4, false);


        TTS.speakText("And so are these two as well.");
        yield return new WaitWhile(() => TTS.isSpeaking());
        mc.noteActivated(Key.GS4, Color.Red);
        mc.noteActivated(Key.A4, Color.Red);
        yield return new WaitForSeconds(1);
        mc.noteDeactivated(Key.GS4, false);
        mc.noteDeactivated(Key.A4, false);
    }
}
