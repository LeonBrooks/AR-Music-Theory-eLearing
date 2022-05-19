using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tSemitones : Tutorial
{
    float deacWaitTime = 2f;
    public override IEnumerator tutorial()
    {
        mc.initializeTutorialMode();
        TTS.speakText(@"Hello. Welcome to the first tutorial. Here we will cover one of the baisc concepts of classical music theory: The semitone.
                        The smitone is the smallest unit in classical music theory and bulids the foundation to understandin more complex concepts.
                        Take a look at the keyboard and say continue when you are ready to move on.");
        yield return new WaitWhile(() => TTS.isSpeaking());
        yield return runner.StartCoroutine(waitForContinue());


        TTS.speakText("Every key on the keyboard is excatly one semitone away from the next. The distance between these keys is one semitone step.");
        yield return new WaitWhile(() => TTS.isSpeaking());
        mc.noteActivated(Key.C4, Color.Blue);
        mc.noteActivated(Key.CS4, Color.Blue);
        yield return new WaitForSeconds(deacWaitTime);
        mc.noteDeactivated(Key.C4, false);
        mc.noteDeactivated(Key.CS4, false);


        TTS.speakText("These two are also one semitone step apart.");
        yield return new WaitWhile(() => TTS.isSpeaking());
        mc.noteActivated(Key.E4, Color.Green);
        mc.noteActivated(Key.F4, Color.Green);
        yield return new WaitForSeconds(deacWaitTime);
        mc.noteDeactivated(Key.E4, false);
        mc.noteDeactivated(Key.F4, false);


        TTS.speakText("And so are these two as well.");
        yield return new WaitWhile(() => TTS.isSpeaking());
        mc.noteActivated(Key.GS4, Color.Red);
        mc.noteActivated(Key.A4, Color.Red);
        yield return new WaitForSeconds(deacWaitTime);
        mc.noteDeactivated(Key.GS4, false);
        mc.noteDeactivated(Key.A4, false);

        yield return runner.StartCoroutine(waitForContinue());

        mc.resetAllKeys();
        TTS.speakText("Two semitone-steps make up a make up a whole tone step. Here are some examples for whole tone steps.");
        yield return new WaitWhile(() => TTS.isSpeaking());
        mc.noteActivated(Key.C4, Color.Blue);
        mc.noteActivated(Key.D4, Color.Blue);
        yield return new WaitForSeconds(deacWaitTime);
        mc.noteDeactivated(Key.C4, false);
        mc.noteDeactivated(Key.D4, false);
        yield return new WaitForSeconds(0.2f);
        mc.noteActivated(Key.E4, Color.Green);
        mc.noteActivated(Key.FS4, Color.Green);
        yield return new WaitForSeconds(deacWaitTime);
        mc.noteDeactivated(Key.E4, false);
        mc.noteDeactivated(Key.FS4, false);
        yield return new WaitForSeconds(0.2f);
        mc.noteActivated(Key.GS4, Color.Red);
        mc.noteActivated(Key.AS4, Color.Red);
        yield return new WaitForSeconds(deacWaitTime);
        mc.noteDeactivated(Key.GS4, false);
        mc.noteDeactivated(Key.AS4, false);

        yield return runner.StartCoroutine(waitForContinue());

        mc.resetAllKeys();
        TTS.speakText(@"As you can see, semitiones are not directly connected to black or whithe keys on a keyboard.
                        Sometimes a semitone step can be between two white keys, like here.");
        yield return new WaitWhile(() => TTS.isSpeaking());
        mc.noteActivated(Key.E4, Color.Blue);
        mc.noteActivated(Key.F4, Color.Blue);
        yield return new WaitForSeconds(deacWaitTime);
        mc.noteDeactivated(Key.E4, false);
        mc.noteDeactivated(Key.F4, false);

        TTS.speakText("And sometimes it can be between a black and a white key, like here.");
        yield return new WaitWhile(() => TTS.isSpeaking());
        mc.noteActivated(Key.G4, Color.Green);
        mc.noteActivated(Key.GS4, Color.Green);
        yield return new WaitForSeconds(deacWaitTime);
        mc.noteDeactivated(Key.G4, false);
        mc.noteDeactivated(Key.GS4, false);


        TTS.speakText(@"Now you are probably wondering why the keyboard is set up that way.
                        The short answer and somewhat simplified is that the keyboard evolved over a long period of time 
                        and was adapted to fit the need of more complex music.
                        It started out with only white keys to work for simple church choire music. As music got more complex the need for extra tones
                        in between the existing ones was realized and over time more and more black keys were added in.
                        As the keyboard works quite well for most western music and it is widely spread it has become the current standard.
                        In theory however there is no reason why a keyboard couldn't be set up differently, 
                        especially when looking at music from different cultures that didn't evolve from European classical music.");
        yield return new WaitWhile(() => TTS.isSpeaking());

        yield return runner.StartCoroutine(waitForContinue());

        mc.resetAllKeys();
        TTS.speakText("Now let's move on to some simple excercises. Given is this tone.");
        yield return new WaitWhile(() => TTS.isSpeaking());
        mc.noteActivated(Key.D4, Color.Green, true);
        yield return new WaitForSeconds(deacWaitTime);
        mc.noteDeactivated(Key.D4, false);

        TTS.speakText("Now press the key one semitone above. You can always say skip to reveal the answer");
        yield return new WaitWhile(() => TTS.isSpeaking());
        yield return runner.StartCoroutine(waitForKeyOrSkip(Key.DS4));
        mc.resetAllKeys();
        TTS.speakText("Test end");

    }
}
