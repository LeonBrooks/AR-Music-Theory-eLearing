using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tScales : Tutorial
{
    public override IEnumerator tutorial()
    {
        Note n1,n2,n3,n4,n5,n6,n7, n8;
        Tooltip t1, t2, t3;
        deacWaitTime = 1f;
        defaultTooltipScale = new Vector3(0.7f, 0.7f, 0.7f);
        yield return speakAndWait("Welcome to the fourth tutorial. As we covered all of the most important basics in the" +
            "last three tutorials, this time we can take a first look at simple concepts of harmony. " +
            "Harmony is the idea of analyzing how different tones sound together. Over time this has of course led to rules and guidelines being" +
            "set up to better formalize what one experiences when listening or making music. " +
            "But as with any other art it is always useful to keep in mind that there are no absolutes and styles, traditions and associations may differ" +
            "between cultures and just personal preference. Nevertheless it is always good to use these concepts to better understand why a certain things" +
            "might sound similar or different and perhaps even get an understanding of the composers intentions. " +
            "But to not blow things out of proportion, what we will be looking at here are just the most basic concepts " +
            "which will hopefully interst you enough to motivate you to find out morein the future.");
        yield return waitForContinue();

        yield return speakAndWait("More specifically, in this tutorial we are going to go into detail about two terms you might already be familiar with: " +
            "Minor and major. They are also known as keys. Although the same word, a key like minor or major is not anything you can press on the keyboard. " +
            "But if you hear someone talking about the key of a piece of music that is what they are refering to.");
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
        n1 = sheet.drawNote(Key.C4, 0, 0);
        n2 = sheet.drawNote(Key.D4, 0, 1);
        n3 = sheet.drawNote(Key.E4, 0, 2);
        n4 = sheet.drawNote(Key.F4, 0, 3);
        n5 = sheet.drawNote(Key.G4, 0, 4);
        n6 = sheet.drawNote(Key.A4, 0, 5);
        n7 = sheet.drawNote(Key.B4, 0, 6);
        n8 = sheet.drawNote(Key.C5, 0, 7);
        yield return waitForContinue();

        yield return speakAndWait("First, what even is a scale? A scale is a collection of notes in some way ordered by their pitch. " +
            "All of these notes are within one octave since anything more would just be repeating the scale.");
        yield return waitForContinue();
        yield return speakAndWait("All major and minor scales contain exactly eight notes. Although there are many other scales as well, " +
            "major and minor ones are what is generally used in classical music.");
        yield return waitForContinue();
        yield return speakAndWait("So how can you recognize a major scale just by the notes? The answer is fairly simple. All but two pairs of notes are " +
            "exactly one whole tone step apart. The outliers are a semitone step between the third and fourth as well as the seventh and the eighth note.");
        n3.changeColor(Color.Red);
        n4.changeColor(Color.Red);
        n7.changeColor(Color.Red);
        n8.changeColor(Color.Red);
        instantiateTooltip(n3.transform, new Vector3(-25,35,0), "3");
        instantiateTooltip(n4.transform, new Vector3(25, 35, 0), "4");
        t1 = instantiateTooltip(n3.transform, new Vector3(30,-20, 0), "semitone step", new Vector3(0.9f, 0.9f, 0.9f));
        t1.activateSecondLine(n4.gameObject);
        instantiateTooltip(n7.transform, new Vector3(-25, 35, 0), "7");
        instantiateTooltip(n8.transform, new Vector3(25, 35, 0), "8");
        t2 = instantiateTooltip(n7.transform, new Vector3(-3, -20, 0), "semitone step", new Vector3(0.9f, 0.9f, 0.9f));
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
        t3 =instantiateTooltip(sheet.gameObject.transform, new Vector3(-3, -0.2f, 0), "C major scale", new Vector3(0.03f, 0.03f, 0.03f));
        t3.GetComponentInChildren<LineRenderer>().enabled = false;
        yield return waitForContinue();
        yield return speakAndWait("As you may have noticed, the C major scale fits perfectly onto only the white keys due to how the keyboard is set up. " +
            "If you want any other major scale however things get a little more complicated. Let's take a look at G major now.");
        yield return waitForContinue();
        mc.resetAllKeys();
        sheet.clearAllNotes();
        clearTooltips();
        yield return speakAndWait("First we start with the base tone: G ");
        mc.drawAsSharp = true;
        n1 = sheet.drawNote(Key.G4, 0, 0);
        instantiateTooltip(n1.transform, new Vector3(-25, 35, 0), "G");
        km.showNameplate(Key.G4.ToString());
        yield return hitKey(Key.G4, draw: false, wait: true);
        yield return speakAndWait("The next two steps are whole tones steps, so they fit with the white keys.");
        n2 = sheet.drawNote(Key.A4, 0, 1);        
        yield return hitKey(Key.A4, draw: false, wait: true);
        n3 = sheet.drawNote(Key.B4, 0, 2, Color.Red);
        yield return hitKey(Key.B4, Color.Red, draw: false, wait: true);
        yield return speakAndWait("Now comes the first semitone step. Since B to C is a semitone step anyway it fits the white keys again.");
        n4 = sheet.drawNote(Key.C5, 0, 3, Color.Red);
        yield return hitKey(Key.C5, Color.Red, draw: false, wait: true);
        yield return speakAndWait("The next three steps are all whole tone steps. D and E fit the white keys as well.");
        n5 = sheet.drawNote(Key.D5, 0, 4);        
        yield return hitKey(Key.D5, draw: false, wait: true);
        n6 = sheet.drawNote(Key.E5, 0, 5);
        yield return hitKey(Key.E5, draw: false, wait: true);
        yield return speakAndWait("Now we run into a problem however. The next step in the scale is another whole tone step, " +
            "but E and F are only a semitone step apart. Think for a moment if you have an idea how this problem could be resolved.");
        yield return waitForContinue();
        yield return speakAndWait("If you thought about adding an accidental that is the correct answer. " +
            "Since we have a semitone step but want a whole tone step, we increase the second note by a semitone through adding a sharp to the F.");
        n7 = sheet.drawNote(Key.F5, 1, 6);
        n7.changeColor(Color.Red);
        n7.changeColor(Color.Green, 1);
        yield return hitKey(Key.FS5, Color.Green, draw: false, wait: true);
        yield return speakAndWait("Now comes the second semitone step in the scale. But since a black key and a white key are only a semitone step apart," +
            "G fits perfectly fine.");
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
        t3 = instantiateTooltip(sheet.gameObject.transform, new Vector3(0, -0.4f, 0), "G major scale", new Vector3(0.03f, 0.03f, 0.03f));
        t3.GetComponentInChildren<LineRenderer>().enabled = false;
        yield return waitForContinue();

        yield return speakAndWait("Now moving on to minor scales things work very similarly. " +
            "The only difference is that they have their semitone steps between the second and third, as well as the fifth and sixth note.");
        yield return waitForContinue();
        yield return speakAndWait("Let's take a look at the C minor scale we heard at the beginning. We again star with C as the base tone.");
        mc.resetAllKeys();
        sheet.clearAllNotes();
        clearTooltips();
        n1 = sheet.drawNote(Key.C4, 0, 0);
        instantiateTooltip(n1.transform, new Vector3(-25, 20, 0), "C");
        km.showNameplate(Key.C4.ToString());
        yield return hitKey(Key.C4, draw: false, wait: true);
        yield return speakAndWait("D works fine again as it's one whole tone  step apart.");
        n2 = sheet.drawNote(Key.D4, 0, 1, Color.Red);
        yield return hitKey(Key.D4, Color.Red, draw: false, wait: true);
        yield return speakAndWait("Now however we've already reached the first semitone step in the scale and E is a whole tone step away instead. " +
            "This means we have to make use of accidentals again. Since E is to far away this time and not to close, " +
            "we have to use a flat instead of a sharp as we want to lower E by one semitone step.");
        yield return waitForContinue();
        n3 = sheet.drawNote(Key.E4, -1, 2, Color.Red);
        yield return hitKey(Key.DS4, Color.Red, draw: false, wait: true);
        yield return speakAndWait("Since E flat to F is a whole tone step and F to G is one as well, we don't have to adjust anything for the next two notes.");
        n4 = sheet.drawNote(Key.F4, 0, 3);
        yield return hitKey(Key.F4, draw: false, wait: true);
        n5 = sheet.drawNote(Key.G4, 0, 4, Color.Red);
        yield return hitKey(Key.G4, Color.Red, draw: false, wait: true);
        yield return speakAndWait("Now we have reached the next semitone step again, so we have to repeat the same procedure and reduce A to A flat.");
        n6 = sheet.drawNote(Key.A4, -1, 5, Color.Red);
        yield return hitKey(Key.GS4, Color.Red, draw: false, wait: true);
        yield return speakAndWait("As we need a whole tone step now, but B would be one and a half whole tone steps away now, we have to make B flat too.");
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
        t3 = instantiateTooltip(sheet.gameObject.transform, new Vector3(3, -0.4f, 0), "C minor scale", new Vector3(0.03f, 0.03f, 0.03f));
        t3.GetComponentInChildren<LineRenderer>().enabled = false;
        yield return waitForContinue();

        yield return speakAndWait("Ok, now some final things to remember before we move on to exercises. " +
            "If a scale has accidentals, it has either only sharps or only flats, never both. The accidentals however are not directly tied to minor and major. " +
            "There are major scales with flats, minor scales with sharps and vice versa. " +
            "Only the location of the semitone steps decide wether a scale is minor or major.");
        yield return waitForContinue();
        mc.resetAllKeys();
        sheet.clearAllNotes();
        clearTooltips();
        yield return speakAndWait("If you have to write down a scale on paper, it is the most easy to first write down all eight notes ascending from the base note.");
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

        mc.resetAllKeys();
        sheet.clearAllNotes();
        yield return speakAndWait("Now for the first exercise, look at this scale.");
        sheet.drawNote(Key.A3, 0, 0);
        sheet.drawNote(Key.B3, 0, 1);
        sheet.drawNote(Key.C4, 0, 2);
        sheet.drawNote(Key.D4, 0, 3);
        sheet.drawNote(Key.E4, 0, 4);
        sheet.drawNote(Key.F4, 0, 5);
        sheet.drawNote(Key.G4, 0, 6);
        sheet.drawNote(Key.A4, 0, 7);
        km.changeColor(Color.Blue, Key.A3.ToString());
        km.changeColor(Color.Blue, Key.B3.ToString());
        km.changeColor(Color.Blue, Key.C4.ToString());
        km.changeColor(Color.Blue, Key.D4.ToString());
        km.changeColor(Color.Blue, Key.E4.ToString());
        km.changeColor(Color.Blue, Key.F4.ToString());
        km.changeColor(Color.Blue, Key.G4.ToString());
        km.changeColor(Color.Blue, Key.A4.ToString());
        yield return new WaitForSeconds(1);
        yield return speakAndWait("Is it major or minor? Say the answer out loud.");
        yield return waitForMajorMinorInput(false, "Is the scale major or minor. Say the answer out loud.");
        if (correctAnswer) { yield return speakAndWait("Correct, that is a minor scale"); }
        else { yield return speakAndWait("No, this is a minor scale. It has the semitone steps between" +
            " the second and third as well as the fifth an sixth note."); }
        yield return waitForContinue();
        mc.resetAllKeys();
        sheet.clearAllNotes();
        yield return speakAndWait("Ok for this exercise, look at this E minor scale.");
        mc.linger = true;
        yield return hitKey(Key.E3, fix: true, wait: true);
        yield return hitKey(Key.G3, fix: true, wait: true);
        yield return hitKey(Key.A3, fix: true, wait: true);
        yield return hitKey(Key.B3, fix: true, wait: true);
        yield return hitKey(Key.D4, fix: true, wait: true);
        yield return hitKey(Key.E4, fix: true, wait: true);
        mc.linger = false;
        yield return speakAndWait("It has two notes missing. Press and hold both of the missing keys simultaneously.");
        yield return waitForKey(Key.FS3, "Press and hold both missing keys. (E minor)", otherKeys: Key.C4);
        if (correctAnswer) { yield return speakAndWait("Yes, those are the correct Keys."); }
        else 
        { 

            yield return speakAndWait("The correct keys would have been F sharp and C.");
            mc.linger = true;
            yield return hitKey(Key.E3, fix: true, wait: true);
            yield return hitKey(Key.FS3, Color.Green, wait: true);
            yield return hitKey(Key.G3, fix: true, wait: true);
            yield return hitKey(Key.A3, fix: true, wait: true);
            yield return hitKey(Key.B3, fix: true, wait: true);
            yield return hitKey(Key.C4, Color.Green, wait: true);
            yield return hitKey(Key.D4, fix: true, wait: true);
            yield return hitKey(Key.E4, fix: true, wait: true);
            mc.linger = false;
            yield return waitForContinue();
        }
        mc.resetAllKeys();
        sheet.clearAllNotes();
        yield return speakAndWait("Let's take a look at a major example now");
        mc.linger = true;
        yield return hitKey(Key.A3, fix: true, wait: true);
        yield return hitKey(Key.B3, fix: true, wait: true);
        yield return hitKey(Key.D4, fix: true, wait: true);
        yield return hitKey(Key.E4, fix: true, wait: true);
        yield return hitKey(Key.A4, fix: true, wait: true);
        mc.linger = false;
        yield return speakAndWait("This time there are three notes missing instead. Can you find out which ones fit this a major scale");
        yield return waitForKey(Key.CS4, "Press and hold all three missing keys. (A major)", otherKeys: new Key[] { Key.FS4, Key.GS4 });
        if (correctAnswer) { yield return speakAndWait("Yes, those are the correct Keys."); }
        else
        {
            mc.linger = true;
            yield return speakAndWait("The correct keys would have been C shsrp, F sharp and G sharp.");
            yield return hitKey(Key.A3, fix: true, wait: true);
            yield return hitKey(Key.B3, fix: true, wait: true);
            yield return hitKey(Key.CS4, Color.Green, wait: true);
            yield return hitKey(Key.D4, fix: true, wait: true);
            yield return hitKey(Key.E4, fix: true, wait: true);
            yield return hitKey(Key.FS4, Color.Green, wait: true);
            yield return hitKey(Key.GS4, Color.Green, wait: true);
            yield return hitKey(Key.A4, fix: true, wait: true);
            mc.linger = false;
        }
        yield return waitForContinue();
        mc.resetAllKeys();
        sheet.clearAllNotes();
        yield return speakAndWait("Ok, for the final exercise we will use this E flat major scale.");
        n1 = sheet.drawNote(Key.E4, -1, 0);
        yield return hitKey(Key.DS4, draw: false, wait: true);
        n2 = sheet.drawNote(Key.F4, 0, 1, interactive: true);
        yield return hitKey(Key.F4, draw: false, wait: true);
        n3 = sheet.drawNote(Key.G4, 0, 2, interactive: true);
        yield return hitKey(Key.G4, draw: false, wait: true);
        n4 = sheet.drawNote(Key.A4, -1, 3, interactive: true);
        yield return hitKey(Key.GS4, draw: false, wait: true);
        n5 = sheet.drawNote(Key.B4, -1, 4, interactive: true);
        yield return hitKey(Key.AS4, draw: false, wait: true);
        n6 = sheet.drawNote(Key.C5, 0, 5, interactive: true);
        yield return hitKey(Key.C5, draw: false, wait: true);
        n7 = sheet.drawNote(Key.D5, 0, 6, interactive: true);
        yield return hitKey(Key.D5, draw: false, wait: true);
        n8 = sheet.drawNote(Key.E5, -1, 7);
        yield return hitKey(Key.DS5, draw: false, wait: true);
        yield return speakAndWait("Can you turn it into an E flat minor scale by adjusting the notes?" +
            "This one is really tricky so dont worrry if you get it wrong.");
        yield return waitForNoteInput(new Note[] { n1, n2, n3, n4, n5, n6, n7, n8 }, 
            new Key[] {Key.E4, Key.F4, Key.G4, Key.A4, Key.B4, Key.C5, Key.D5, Key.E5}, new int[] {-1,0,-1,-1,-1,-1,-1,-1},
            "Adjust the notes to get an E flat minor scale. Say confirm when you are done.");
        if (correctAnswer) { yield return speakAndWait("Good job, you got everything right."); }
        else
        {

            yield return speakAndWait("That wasn't easy. The correct answer would have looked like this:");
            mc.resetAllKeys();
            sheet.clearAllNotes();

            sheet.drawNote(Key.E4, -1, 0);
            yield return hitKey(Key.DS4, draw: false, wait: true);
            sheet.drawNote(Key.F4, 0, 1);
            yield return hitKey(Key.F4, draw: false, wait: true);
            sheet.drawNote(Key.G4, -1, 2);
            yield return hitKey(Key.FS4, draw: false, wait: true);
            sheet.drawNote(Key.A4, -1, 3);
            yield return hitKey(Key.GS4, draw: false, wait: true);
            sheet.drawNote(Key.B4, -1, 4);
            yield return hitKey(Key.AS4, draw: false, wait: true);
            sheet.drawNote(Key.C5, -1, 5);
            yield return hitKey(Key.B4, draw: false, wait: true);
            sheet.drawNote(Key.D5, -1, 6);
            yield return hitKey(Key.CS5, draw: false, wait: true);
            sheet.drawNote(Key.E5, -1, 7);
            yield return hitKey(Key.DS5, draw: false, wait: true);
        }
        yield return waitForContinue();

        mc.resetAllKeys();
        sheet.clearAllNotes();
        yield return speakAndWait("Ok, before we finish this tutorial there are still a few important side notes you should know about. " +
            "As mentioned earlier it is important to keep in mind that a piece of music can be written in a certain key. " +
            "For example if someone were to say this piece is in G major it would mean that generally the piece almost exclusively uses notes from that scale.");
        yield return waitForContinue();
        yield return speakAndWait("Another good thing to know is that the minor key has two variations known as melodic minor and harmonic minor, " +
            "that have additional half tone steps besides the ones we looked at. " +
            "Therefore the base version of the minor key we discussed is also known as natural minor.");
        yield return waitForContinue();
        yield return speakAndWait("Do you remember when we discussed intervals a few tutorials ago. " +
            "Those were the names given to different distances between two notes. " +
            "Some of the intervals also have minor versions and for that reason the basic ones we looked at are also known as major intervals. " +
            "For example if we look at a major third:");
        n1 = sheet.drawNote(Key.C4, 0, 0);
        n2 = sheet.drawNote(Key.E4, 0, 1, Color.Blue);
        t1 = instantiateTooltip(n1.transform, new Vector3(35,- 25,0), "major third", new Vector3(1, 1, 1));
        t1.activateSecondLine(n2.gameObject);
        hitKey(Key.C4, draw: false);
        yield return hitKey(Key.E4, draw: false, wait: true);
        yield return speakAndWait("A minor interval is always reduced by one semitone. So we would get a minor third by turning E into E flat.");
        n3 = sheet.drawNote(Key.C4, 0, 2);
        n4 = sheet.drawNote(Key.E4, -1, 3, Color.Red);
        t2 = instantiateTooltip(n3.transform, new Vector3(37, -25, 0), "minor third", new Vector3(1,1,1));
        t2.activateSecondLine(n4.gameObject);
        hitKey(Key.C4, draw: false);
        yield return hitKey(Key.DS4, Color.Red, draw: false, wait: true);
        yield return waitForContinue();
        yield return speakAndWait("Major and minor thirds will be especially important for the next tutorial. " +
            "Ok finally, the last bit of information which might come in handy is that a minor scale which uses the same accidentals as a major scale," +
            " is alwys a minor third below the major one. For example if we look at the scales with no accidentals, the minor version is A minor.");
        mc.resetAllKeys();
        sheet.clearAllNotes();
        mc.drawAsSharp = false;
        mc.linger = true;
        km.showNameplate(Key.A3.ToString());
        yield return hitKey(Key.A3, Color.Green, wait: true);
        yield return hitKey(Key.B3, Color.Green, wait: true);
        yield return hitKey(Key.C4, Color.Green, wait: true);
        yield return hitKey(Key.D4, Color.Green, wait: true);
        yield return hitKey(Key.E4, Color.Green, wait: true);
        yield return hitKey(Key.F4, Color.Green, wait: true);
        yield return hitKey(Key.G4, Color.Green, wait: true);
        yield return hitKey(Key.A4, Color.Green, wait: true);
        yield return waitForContinue();
        yield return speakAndWait("If we now look at C major as well:");
        mc.resetAllKeys();
        km.changeColor(Color.Green, Key.A3.ToString());
        km.showNameplate(Key.A3.ToString());
        km.showNameplate(Key.C4.ToString());
        yield return hitKey(Key.C4, wait: true);
        yield return hitKey(Key.D4, wait: true);
        yield return hitKey(Key.E4, wait: true);
        yield return hitKey(Key.F4, wait: true);
        yield return hitKey(Key.G4, wait: true);
        yield return hitKey(Key.A4, wait: true);
        yield return hitKey(Key.B4, wait: true);
        yield return hitKey(Key.C5, wait: true);
        yield return speakAndWait("You can see that A minor is a minor third below C major. This rule applies to each major" +
            " and minor scale that use the same accidentals. These pairs of scales are also known as relative keys.");
        yield return waitForContinue();
        yield return speakAndWait("Ok, now this finally wraps up the fourth tutorial. In the next one we will take a look at chords");
        yield return nextTutorialOrExit(4);
    }
}
