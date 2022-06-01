using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tScales : Tutorial
{
    public override IEnumerator tutorial()
    {
        Note n1,n2,n3,n4,n5,n6,n7, n8;
        Tooltip t1, t2;
        deacWaitTime = 1f;
        defaultTooltipScale = new Vector3(0.7f, 0.7f, 0.7f);
        /*yield return speakAndWait("Welcome to the fourth tutorial. As we covered all of the most important basics in the" +
            "last three tutorials, this time we can take a first look at simple concepts of harmony. " +
            "Harmony is the idea of analyzing how different tones sound together. Over time this has of course led to rules and guidelines being" +
            "set up to better formalize what one experiences when listening or making music." +
            "But as with any other art it is always usefull to keep in mind that there are no absolutes and styles, traditions and associaions may differ" +
            "between cultures and just personal prefference. Nevertheless it is always good to use these concepts to better understand why certain thing" +
            "might sound similar or differen and prehaps even get an understanding of the composers intentions. " +
            "But to not blow things out of proporting, what we will be looking at here are just the most basic concepts " +
            "which will hopefully interst you enough to motivate you to find out morein the future.");
        yield return waitForContinue();

        yield return speakAndWait("More specifically, in this tutorial we are going to go into detail about two terms you might already be familiar with: " +
            "Minor and major. They are also known as keys. Although the same word, a key like minor or major is not anything you can press on the keyboard. " +
            "But if your hear someone talking about the key of a pice of music that is what they are refering to.");
        yield return waitForContinue();

        yield return speakAndWait("For now just listen for a moment.");
        yield return hitKey(Key.C4, resetColor: true, wait: true);
        yield return hitKey(Key.D4, resetColor: true, wait: true);
        yield return hitKey(Key.E4, resetColor: true, wait: true);
        yield return hitKey(Key.F4, resetColor: true, wait: true);
        yield return hitKey(Key.G4, resetColor: true, wait: true);
        yield return hitKey(Key.A4, resetColor: true, wait: true);
        yield return hitKey(Key.B4, resetColor: true, wait: true);
        yield return hitKey(Key.C5, resetColor: true, wait: true);
        yield return speakAndWait("Now compare that to this", false);
        mc.drawAsSharp = false;
        yield return hitKey(Key.C4, resetColor: true, wait: true);
        yield return hitKey(Key.D4, resetColor: true, wait: true);
        yield return hitKey(Key.DS4, resetColor: true, wait: true);
        yield return hitKey(Key.F4, resetColor: true, wait: true);
        yield return hitKey(Key.G4, resetColor: true, wait: true);
        yield return hitKey(Key.GS4, resetColor: true, wait: true);
        yield return hitKey(Key.AS4, resetColor: true, wait: true);
        yield return hitKey(Key.C5, resetColor: true, wait: true);
        yield return waitForContinue();

        yield return speakAndWait("The first example you just heard was a C major scale while the second was a C minor scale. " +
            "As you could hear, although being a bit similar one could say that they both convey different moods. " +
            "So let's unpack what is happening here and use the C major scale as an example.");
        Note n1 = sheet.drawNote(Key.C4, 0, 0);
        Note n2 = sheet.drawNote(Key.D4, 0, 1);
        Note n3 = sheet.drawNote(Key.E4, 0, 2);
        Note n4 = sheet.drawNote(Key.F4, 0, 3);
        Note n5 = sheet.drawNote(Key.G4, 0, 4);
        Note n6 = sheet.drawNote(Key.A4, 0, 5);
        Note n7 = sheet.drawNote(Key.B4, 0, 6);
        Note n8 = sheet.drawNote(Key.C5, 0, 7);
        yield return waitForContinue();

        yield return speakAndWait("First, what even is a scale? A scale is a collections of notes in some way ordered by their pitch." +
            "All of these notes are within one octave since anything more would just be repeating the scale.");
        yield return waitForContinue();
        yield return speakAndWait("All major and minor scales contain exactly eight notes. Although there are many other scales as well, " +
            "major and minor ones are what is generally used in classical music.");
        yield return waitForContinue();
        yield return speakAndWait("So how can you recognize a major scale just by the notes? The answer is fairly simple. All but two pairs of notes are" +
            "exactly one whole tone step apart. The outliers are a semitone step between the third and fourth as well as the seventh and the eigth note.");
        n3.changeColor(Color.Red);
        n4.changeColor(Color.Red);
        n7.changeColor(Color.Red);
        n8.changeColor(Color.Red);
        instantiateTooltip(n3.transform, new Vector3(-25,35,0), "3");
        instantiateTooltip(n4.transform, new Vector3(25, 35, 0), "4");
        Tooltip t1 = instantiateTooltip(n3.transform, new Vector3(30,-20, 0), "semitone step", new Vector3(0.9f, 0.9f, 0.9f));
        t1.activateSecondLine(n4.gameObject);
        instantiateTooltip(n7.transform, new Vector3(-25, 35, 0), "7");
        instantiateTooltip(n8.transform, new Vector3(25, 35, 0), "8");
        Tooltip t2 = instantiateTooltip(n7.transform, new Vector3(-3, -20, 0), "semitone step", new Vector3(0.9f, 0.9f, 0.9f));
        t2.activateSecondLine(n8.gameObject);
        yield return hitKey(Key.C4, draw: false, wait: true);
        yield return hitKey(Key.D4, draw: false, wait: true);
        yield return hitKey(Key.E4, Color.Red, draw: false, wait: true);
        yield return hitKey(Key.F4, Color.Red, draw: false, wait: true);
        yield return hitKey(Key.G4, draw: false, wait: true);
        yield return hitKey(Key.A4, draw: false, wait: true);
        yield return hitKey(Key.B4, Color.Red, draw: false, wait: true);
        yield return hitKey(Key.C5, Color.Red, draw: false, wait: true);
        yield return waitForContinue();

        yield return speakAndWait("This pattern is the same for every major scale. Once you have identified a scale as major, the first" +
            " and the last note are the base tone and give the scale it's complete name. In this case C major.");
        instantiateTooltip(n1.transform, new Vector3(-25, 35, 0), "C");
        km.showNameplate(Key.C4.ToString());
        yield return waitForContinue();
        yield return speakAndWait("As you may have noticed, the C major scale fits perfectly onto only the white keys due to how the keyboard is set up." +
            "If you want any other major scale however things get a little more complicated. Let's take a look at G major now.");
        yield return waitForContinue();
        yield return speakAndWait("First we start with the base tone: G");
        mc.resetAllKeys();
        sheet.clearAllNotes();
        mc.drawAsSharp = true;
        n1 = sheet.drawNote(Key.G4, 0, 0);
        instantiateTooltip(n1.transform, new Vector3(-25, 35, 0), "G");
        km.showNameplate(Key.G4.ToString());
        yield return hitKey(Key.G4, draw: false, wait: true);
        yield return speakAndWait("The next two steps are whole tones steps, so the fit with the white keys.");
        n2 = sheet.drawNote(Key.A4, 0, 1);        
        yield return hitKey(Key.A4, draw: false, wait: true);
        n3 = sheet.drawNote(Key.B4, 0, 2, Color.Red);
        yield return hitKey(Key.B4, Color.Red, draw: false, wait: true);
        yield return speakAndWait("Now comes the first semitone step. Since B to C is a semitone step anyway it fits the white keys again.");
        n4 = sheet.drawNote(Key.C5, 0, 3, Color.Red);
        yield return hitKey(Key.C5, Color.Red, draw: false, wait: true);
        yield return speakAndWait("The next three step are all whole tone steps. D and E fit the white keys aswell");
        n5 = sheet.drawNote(Key.D5, 0, 4);        
        yield return hitKey(Key.D5, draw: false, wait: true);
        n6 = sheet.drawNote(Key.E5, 0, 5);
        yield return hitKey(Key.E5, draw: false, wait: true);
        yield return speakAndWait("Now we run into a problem however. The next step in the scale is another whole tone step, " +
            "but E and F are only a semitone step apart. Think for a moment if you have an idea how this problem could be resolved.");
        yield return waitForContinue();
        yield return speakAndWait("If you thought about adding an accidental that is the correct answer. " +
            "Since we have semitone step but want a whole tone step, we increase the second note by a semitone through adding a sharp to the F.");
        n7 = sheet.drawNote(Key.F5, 1, 6);
        n7.changeColor(Color.Red);
        n7.changeColor(Color.Green, 1);
        yield return hitKey(Key.FS5, Color.Green, draw: false, wait: true);
        yield return speakAndWait("Now comes the second semitone step in the scale. But since a black key and a white key are only a semitone step apart," +
            "G fits perfectly fine");
        n8 = sheet.drawNote(Key.G5, 0, 7, Color.Red);
        yield return hitKey(Key.G5, Color.Red, draw: false, wait: true);
        yield return waitForContinue();
        yield return speakAndWait("Overall we now have the pattern of a major scale again.");
        instantiateTooltip(n3.transform, new Vector3(-25, 35, 0), "3");
        instantiateTooltip(n4.transform, new Vector3(25, 35, 0), "4");
        t1 = instantiateTooltip(n3.transform, new Vector3(-3, -20, 0), "semitone step", new Vector3(0.9f, 0.9f, 0.9f));
        t1.activateSecondLine(n4.gameObject);
        instantiateTooltip(n7.transform, new Vector3(-25, 35, 0), "7");
        instantiateTooltip(n8.transform, new Vector3(25, 35, 0), "8");
        t2 = instantiateTooltip(n7.transform, new Vector3(-3, -35, 0), "semitone step", new Vector3(0.9f, 0.9f, 0.9f));
        t2.activateSecondLine(n8.gameObject);
        yield return waitForContinue();*/

        yield return speakAndWait("Now moving on to minor scales things work very similarly. " +
            "The only difference is that they have their semitone steps between the second and third as well as the fifth and sixth note.");
        yield return waitForContinue();
        yield return speakAndWait("Let's take a look at the C minor scale we heard at the beginning. We again star with C as the base tone.");
        mc.resetAllKeys();
        sheet.clearAllNotes();
        n1 = sheet.drawNote(Key.C4, 0, 0);
        instantiateTooltip(n1.transform, new Vector3(-25, 20, 0), "C");
        km.showNameplate(Key.C4.ToString());
        yield return hitKey(Key.C4, draw: false, wait: true);
        yield return speakAndWait("D works fine again as it's one whole tone  step apart.");
        n2 = sheet.drawNote(Key.D4, 0, 1, Color.Red);
        yield return hitKey(Key.D4, Color.Red, draw: false, wait: true);
        yield return speakAndWait("Now however we've already reached the first semitone step in the scale and E is whole tone step away instead." +
            "This means we have to make use of accidentals again. Since E is to far away this time and not to close, " +
            "we have to use a flat instead of a sharp as we want lower E by one semitone step.");
        yield return waitForContinue();
        n3 = sheet.drawNote(Key.E4, -1, 2, Color.Red);
        yield return hitKey(Key.DS4, Color.Red, draw: false, wait: true);
        yield return speakAndWait("Since E flat to F is a whole tone step and F to G is as well, we don't have to adjust anything for the next two notes.");
        n4 = sheet.drawNote(Key.F4, 0, 3);
        yield return hitKey(Key.F4, draw: false, wait: true);
        n5 = sheet.drawNote(Key.G4, 0, 4, Color.Red);
        yield return hitKey(Key.G4, Color.Red, draw: false, wait: true);
        yield return speakAndWait("Now we have reached the next semitone step again, so we have to repeat the same procedure and reduce A to A flat.");
        n6 = sheet.drawNote(Key.A4, -1, 5, Color.Red);
        yield return hitKey(Key.GS4, Color.Red, draw: false, wait: true);
        yield return speakAndWait("As we need a whole tone step now but B would be one and a half whole tone steps away now, we have to make B flat too.");
        yield return waitForContinue();
        n7 = sheet.drawNote(Key.B4, -1, 6);
        n7.changeColor(Color.Green, -1);
        yield return hitKey(Key.AS4, Color.Green, draw: false, wait: true);
        yield return speakAndWait("Now B flat to C works out fine as a whole tone step.");
        n8 = sheet.drawNote(Key.C5, 0, 7);
        yield return hitKey(Key.C5, draw: false, wait: true);
        yield return speakAndWait("Which leaves us whith the full pattern for minor.");
        instantiateTooltip(n2.transform, new Vector3(-25, 35, 0), "2");
        instantiateTooltip(n3.transform, new Vector3(0, 35, 0), "3");
        t1 = instantiateTooltip(n2.transform, new Vector3(-3, -20, 0), "semitone step", new Vector3(0.9f, 0.9f, 0.9f));
        t1.activateSecondLine(n3.gameObject);
        instantiateTooltip(n5.transform, new Vector3(-20, 35, 0), "5");
        instantiateTooltip(n6.transform, new Vector3(25, 35, 0), "6");
        t2 = instantiateTooltip(n5.transform, new Vector3(-3, -35, 0), "semitone step", new Vector3(0.9f, 0.9f, 0.9f));
        t2.activateSecondLine(n6.gameObject);
        yield return waitForContinue();

        yield return speakAndWait("Ok, now some final things to remember before we move on to exercises. " +
            "If a scale has accidentals, it has either only sharps or only flats, never both. The accidentals however are not directly tied to minor and major." +
            "There are major scales with flats, minor scales with sharps and vice versa. " +
            "Only the location of the semitone steps decides wether a scale is minor or major");
        yield return waitForContinue();
        mc.resetAllKeys();
        sheet.clearAllNotes();
        yield return speakAndWait("If you have to write down a scale on paper it is the most easy to first write down all eight notes ascending from the base note.");
        n1 = sheet.drawNote(Key.C4, 0, 0);
        n2 = sheet.drawNote(Key.D4, 0, 1);
        n3 = sheet.drawNote(Key.E4, 0, 2);
        n4 = sheet.drawNote(Key.F4, 0, 3);
        n5 = sheet.drawNote(Key.G4, 0, 4);
        n6 = sheet.drawNote(Key.A4, 0, 5);
        n7 = sheet.drawNote(Key.B4, 0, 6);
        n8 = sheet.drawNote(Key.C5, 0, 7);
        yield return new WaitForSeconds(2);
        yield return speakAndWait("Then mark where the semitone steps are.");
        t1 = instantiateTooltip(n2.transform, new Vector3(-3, -20, 0), "semitone step", new Vector3(0.9f, 0.9f, 0.9f));
        t1.activateSecondLine(n3.gameObject);
        t2 = instantiateTooltip(n5.transform, new Vector3(-3, -35, 0), "semitone step", new Vector3(0.9f, 0.9f, 0.9f));
        t2.activateSecondLine(n6.gameObject);
        yield return new WaitForSeconds(2);
        yield return speakAndWait("And only at the very end make everything fit by adding accidentals.");
        n3.makeFlat();
        n6.makeFlat();
        n7.makeFlat();
        yield return waitForContinue();
    }
}
