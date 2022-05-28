using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tSemitones : Tutorial
{
    public override IEnumerator tutorial()
    {
        yield return speakAndWait("Hello. Welcome to the first tutorial. Here we will cover one of the basic concepts of classical music theory: The semitone." +
            "The smitone is the smallest unit in classical music theory and bulids the foundation to understanding more complex concepts." +
            "The sheet music won't be relevant for this tutorial so you can ignore it for now." +
            "Take a look at the keyboard and say continue when you are ready to move on.");
        yield return waitForContinue();


        yield return speakAndWait("Every key on the keyboard is excatly one semitone away from the next." +
            "The distance between these keys is one semitone step.");
        hitKey(Key.C4, Color.Blue);
        yield return hitKey(Key.CS4, Color.Blue, wait: true);


        yield return speakAndWait("These two are also one semitone step apart.");
        hitKey(Key.E4, Color.Green);
        yield return hitKey(Key.F4, Color.Green, wait: true);


        yield return speakAndWait("And so are these two as well.");
        hitKey(Key.GS4, Color.Red);
        yield return hitKey(Key.A4, Color.Red, wait: true);

        yield return waitForContinue();

        mc.resetAllKeys();
        yield return speakAndWait("Two semitone steps make up a make up a whole tone step. Here are some examples for whole tone steps.");
        hitKey(Key.C4, Color.Blue);
        yield return hitKey(Key.D4, Color.Blue, wait: true);
        yield return new WaitForSeconds(0.2f);
        hitKey(Key.E4, Color.Green);
        yield return hitKey(Key.FS4, Color.Green, wait: true);
        yield return new WaitForSeconds(0.2f);
        hitKey(Key.GS4, Color.Red);
        yield return hitKey(Key.AS4, Color.Red, wait: true);

        yield return waitForContinue();

        mc.resetAllKeys();
        yield return speakAndWait("As you can see, semitones are not directly connected to black or whithe keys on a keyboard." +
            "Sometimes a semitone step can be between two white keys, like here.");
        hitKey(Key.E4, Color.Blue);
        yield return hitKey(Key.F4, Color.Blue, wait: true);

        yield return speakAndWait("And sometimes it can be between a black and a white key, like here.");
        hitKey(Key.G4, Color.Green);
        yield return hitKey(Key.GS4, Color.Green, wait: true);


        yield return speakAndWait("Now you are probably wondering why the keyboard is set up that way." +
            "The short and somewhat simplified answer is that the keyboard evolved over a long period of time " +
            "and was adapted to fit the need of more complex music." +
            "It started out with only white keys to accompany simple church choire music. As music got more complex the need for extra tones" +
            "in between the existing ones was realized and over time more and more black keys were added in." +
            "As the keyboard works quite well for most western music and it is widely spread it has become the current standard." +
            "In theory however there is no reason why a keyboard couldn't be set up differently, " +
            "especially when looking at music from different cultures that didn't evolve from European classical music.");

        yield return waitForContinue();

        mc.resetAllKeys();
        yield return speakAndWait("Now let's move on to some simple exercises. Given is this tone.");
        yield return hitKey(Key.D4, Color.Green, fix: true, wait: true);

        yield return speakAndWait("Now press and hold the key one semitone above. You can always say skip to reveal the answer");
        yield return waitForKey(Key.DS4, "press and hold the key one semitone above");
        mc.resetAllKeys();
        if (!correctAnswer) { yield return speakAndWait("The correct answer would have been this:"); }
        else { yield return speakAndWait("Correct, these keys are one semitone apart."); }
        hitKey(Key.D4, Color.Green);
        yield return hitKey(Key.DS4, Color.Blue, wait: true);

        yield return waitForContinue();

        mc.resetAllKeys();
        yield return speakAndWait("Now for this tone");
        yield return hitKey(Key.E4, Color.Green, fix: true, wait: true);

        yield return speakAndWait("Press and hold the key one whole tone step above");
        yield return waitForKey(Key.FS4, "press and hold the key one whole tone step above");
        mc.resetAllKeys();
        if (!correctAnswer) { yield return speakAndWait("The correct answer would have been this:"); }
        else { yield return speakAndWait("Correct, these keys are one whole tone step apart."); }
        hitKey(Key.E4, Color.Green);
        yield return hitKey(Key.FS4, Color.Blue, wait: true);

        yield return waitForContinue();

        mc.resetAllKeys();
        yield return speakAndWait("Now for the final exercise. Given this tone");
        yield return hitKey(Key.A4, Color.Green, fix: true, wait: true);

        yield return speakAndWait("Press and hold the key two and a half whole tone steps below");
        yield return waitForKey(Key.E4, "press and hold the key two and a half whole tone steps below");
        mc.resetAllKeys();
        if (!correctAnswer) { yield return speakAndWait("The correct answer would have been this:"); }
        else { yield return speakAndWait("Correct, these keys are two and a half whole tone steps apart."); }
        hitKey(Key.A4, Color.Green);
        yield return hitKey(Key.E4, Color.Blue, wait: true);

        yield return waitForContinue();

        mc.resetAllKeys();
        yield return speakAndWait("This concludes the first tutorial");

        yield return nextTutorialOrExit(1);
    }
}