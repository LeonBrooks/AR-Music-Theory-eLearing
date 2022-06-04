using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tChords : Tutorial
{
    public override IEnumerator tutorial()
    {
        List<Note> c1, c2;
        Tooltip t1, t2;
        yield return speakAndWait("Welcome to the fifth tutorial. Last time we took a look at what scales are and how they differ in major and minor key." +
            "In the beginning we talked about harmony and that it is a concept focused on analayzing the relationship between tones. " +
            "Besideds scales and keys, chords are another foundation of how harmony appears in music. A chord is a group of notes which is played simultainously." +
            "In sheet music the are usually written as a note large note with multiple heads like this:");
        c1 = sheet.drawChord(0, notes: new (Key,int)[]{ (Key.C4, 0), (Key.E4, 0), (Key.G4, 0)} );
        hitKey(Key.C4, draw: false);
        hitKey(Key.E4, draw: false);
        yield return hitKey(Key.G4, draw: false, wait: true);
        yield return waitForContinue();
        yield return speakAndWait("Basic chords usually have three notes but chords with more or less notes are common aswell. " +
            "They are often used as accompaniment where they usally build a harmonic baseline which supports the melody.");
        yield return waitForContinue();
        yield return speakAndWait("So let's take a look at how basic chords are set up and what variations there are. " +
            "The most basic chord has three notes which are each seperated by a third.");
        t1 = instantiateTooltip(c1[0].transform, new Vector3(40, -3, 0), "third", new Vector3(0.9f,0.9f,0.9f));
        t1.activateSecondLine(c1[1].gameObject);
        t2 = instantiateTooltip(c1[1].transform, new Vector3(42, 12, 0), "third", new Vector3(0.95f, 0.95f, 0.95f));
        t2.activateSecondLine(c1[2].gameObject);
        yield return waitForContinue();
        yield return speakAndWait("Similarly to scales chord can also be in maor or minor key." +
            "As you may remember we talked about major and minor intervals at the end of the last tutorial." +
            "These are important in determining the key of a chord. A major chord has a major third separating the first two notes " +
            "while a minor third separates the top two notes. As you can see this chord is a major chord.");
        t1.changeText("major third");
        t2.changeText("minor third");
        yield return waitForContinue();
        yield return speakAndWait("If you weren't quite sure anymore what the difference between a ajor and a minor third is, here a quick refresher:" +
            " A major third covers four semitones while a minor one only covers three. Or speaking in a more visual way, if there are three semitones " +
            "in between the two notes in question, it is a major third, if there are only two semitones in between, it is a minor third.");
        km.changeColor(Color.Red, Key.CS4.ToString());
        km.changeColor(Color.Red, Key.D4.ToString());
        km.changeColor(Color.Red, Key.DS4.ToString());
        km.changeColor(Color.Red, Key.F4.ToString());
        km.changeColor(Color.Red, Key.FS4.ToString());
        yield return waitForContinue();
        yield return speakAndWait("As the base note of this chord is a C, this is a C major chord.");
        km.showNameplate(Key.C4.ToString());
        yield return waitForContinue();
        mc.resetAllKeys();
        yield return speakAndWait("For a minor chord this is exactly reversed. The lower two notes are sepatated by a minor third " +
            "while the top two notes are separated by a major third. This would be a C minor chord in comparisson.");
        c2 = sheet.drawChord(3, notes: new (Key, int)[] { (Key.C4, 0), (Key.E4, -1), (Key.G4, 0) });
        t1 = instantiateTooltip(c2[0].transform, new Vector3(40, -3, 0), "minor third", new Vector3(0.9f, 0.9f, 0.9f));
        t1.activateSecondLine(c2[1].gameObject);
        t2 = instantiateTooltip(c2[1].transform, new Vector3(42, 12, 0), "major third", new Vector3(0.95f, 0.95f, 0.95f));
        t2.activateSecondLine(c2[2].gameObject);
        km.changeColor(Color.Red, Key.CS4.ToString());
        km.changeColor(Color.Red, Key.D4.ToString());
        km.changeColor(Color.Red, Key.E4.ToString());
        km.changeColor(Color.Red, Key.F4.ToString());
        km.changeColor(Color.Red, Key.FS4.ToString());
        hitKey(Key.C4, draw: false);
        hitKey(Key.DS4, draw: false);
        yield return hitKey(Key.G4, draw: false, wait: true);
        yield return waitForContinue();

        yield return speakAndWait("There are many more different and complexer type of chrods which we will not cover here. Although there one more concept" +
            "know as inversion which we will talk about. If we have a based chord, for example E minor:");
        mc.resetAllKeys();
        sheet.clearAllNotes();
        c1 = sheet.drawChord(0, notes: new (Key, int)[] { (Key.E4, 0), (Key.G4, 0), (Key.B4, 0) });
        instantiateTooltip(c1[0].transform, new Vector3(30, -20, 0), "E");
        hitKey(Key.E4, draw: false);
        hitKey(Key.G4, draw: false);
        yield return hitKey(Key.B4, draw: false, wait: true);
        yield return speakAndWait("We can take the base note and make it the top note instead by moving it up an octave.");
        c2 = sheet.drawChord(3, notes: new (Key, int)[] { (Key.G4, 0), (Key.B4, 0), (Key.E5, 0) });
        instantiateTooltip(c2[2].transform, new Vector3(30, 20, 0), "E");
        mc.resetAllKeys();
        km.showNameplate(Key.G4.ToString());
        km.showNameplate(Key.B4.ToString());
        km.showNameplate(Key.E5.ToString());
        hitKey(Key.G4, draw: false);
        hitKey(Key.B4, draw: false);
        yield return hitKey(Key.E5, draw: false, wait: true);  
        yield return speakAndWait("This is called the first inversion of a chord.");
        t1 = instantiateTooltip(sheet.gameObject.transform, new Vector3(-0.49f, 0.3f, 0), "first inversion", new Vector3(0.03f,0.03f,0.03f));
        t1.GetComponentInChildren<LineRenderer>().enabled = false;
        yield return waitForContinue();
        yield return speakAndWait("If you move the second note up aswell that is called the second inversion");
        sheet.drawChord(6, notes: new (Key, int)[] { (Key.B4, 0), (Key.E5, 0), (Key.G5, 0) });
        t2 = instantiateTooltip(sheet.gameObject.transform, new Vector3(2.36f, 0.3f, 0), "second inversion", new Vector3(0.03f, 0.03f, 0.03f));
        t2.GetComponentInChildren<LineRenderer>().enabled = false;
        mc.resetAllKeys();
        km.showNameplate(Key.G5.ToString());
        km.showNameplate(Key.B4.ToString());
        km.showNameplate(Key.E5.ToString());
        hitKey(Key.B4, draw: false);
        hitKey(Key.E5, draw: false);
        yield return hitKey(Key.G5, draw: false, wait: true);       
        yield return waitForContinue();
        mc.resetAllKeys();
        sheet.clearAllNotes();
        clearTooltips();


        yield return speakAndWait("Ok, now let's do some exercises. Look at this chord with the base note D.");
        c1 = sheet.drawChord(0, interactive: true, notes: new (Key, int)[] { (Key.D4, 0), (Key.F4, 0), (Key.A4, 0) });
        km.showNameplate(Key.D4.ToString());
        yield return hitKey(Key.D4, draw: false, fix: true, wait: true);
        yield return speakAndWait("Can you press the remaining keys on the keyboard?");
        yield return waitForKey(Key.F4, "Press and hold the remaining keys", otherKeys: Key.A4);
        if(correctAnswer) { yield return speakAndWait("Right, those are the remaining keys."); }
        else
        {
            yield return speakAndWait("The right keys would have been F and A.");
            hitKey(Key.F4, draw: false);
            yield return hitKey(Key.A4, draw: false, wait: true);
        }
        yield return waitForContinue();
        yield return speakAndWait("Now listen to and look at the whole chord again.");
        hitKey(Key.D4, draw: false);
        hitKey(Key.F4, draw: false);
        yield return hitKey(Key.A4, draw: false, wait: true);
        yield return speakAndWait("Is it a major or a minor chord? Say the answer out loud.");
        yield return waitForMajorMinorInput(false, "Major or minor? Say the answer out loud.");
        if (correctAnswer) { yield return speakAndWait("Correct this is a minor chord."); }
        else
        {
            yield return speakAndWait("No, this is a minor chord. The bottom two notes are separated by a minor third " +
                "while the top two are separated by a major one.");
            km.changeColor(Color.Red, Key.DS4.ToString());
            km.changeColor(Color.Red, Key.E4.ToString());
            km.changeColor(Color.Red, Key.FS4.ToString());
            km.changeColor(Color.Red, Key.G4.ToString());
            km.changeColor(Color.Red, Key.GS4.ToString());
        }
        yield return waitForContinue();
        km.resetAllKeys();
        km.changeColor(Color.Blue, Key.D4.ToString());
        km.changeColor(Color.Blue, Key.F4.ToString());
        km.changeColor(Color.Blue, Key.A4.ToString());
        yield return speakAndWait("How about changing into a D major chord instead. Can you do that by dragging the notes to the correct positions?");
        yield return waitForNoteInput(c1.ToArray(), new Key[] {Key.D4, Key.F4, Key.A4}, new int[] {0,1,0}, "Drag the notes to make the chord D major");
        if (correctAnswer) { yield return speakAndWait("Yes, the F has to be turned into F sharp"); }
        else
        {
            yield return speakAndWait("This is what the correct answer would have looked like.");
            sheet.removeNotes(c1);
            c1 = sheet.drawChord(0, interactive: true, notes: new (Key, int)[] { (Key.D4, 0), (Key.F4, 1), (Key.A4, 0) });
        }
        mc.resetAllKeys();
        hitKey(Key.D4, draw: false);
        hitKey(Key.FS4, draw: false);
        yield return hitKey(Key.A4, draw: false, wait: true);
        yield return waitForContinue();
        yield return speakAndWait("Ok, now can you invert the chord once by dragging the notes?");
        yield return waitForNoteInput(c1.ToArray(), new Key[] { Key.F4, Key.A4, Key.D5 }, new int[] { 1, 0, 0 }, "Drag the notes to invert the chord once");
        if (correctAnswer) { yield return speakAndWait("Perfect, that is the first inversion"); }
        else
        {
            yield return speakAndWait("To invert a chord once you have to move the first note up an octave.");
            sheet.removeNotes(c1);
            c1 = sheet.drawChord(0, interactive: true, notes: new (Key, int)[] { (Key.F4, 1), (Key.A4, 0), (Key.D5, 0) });
        }
        mc.resetAllKeys();
        hitKey(Key.FS4, draw: false);
        hitKey(Key.A4, draw: false);
        yield return hitKey(Key.D5, draw: false, wait: true);
        yield return waitForContinue();

        mc.resetAllKeys();
        sheet.clearAllNotes();
        yield return speakAndWait("Let's try a more difficult example. Given is this G flat.");
        mc.drawAsSharp = false;
        yield return hitKey(Key.FS2, fix: true, wait: true);
        yield return speakAndWait("Can you build a G flat major chord around it? Press the remaining keys to do so.");
        yield return waitForKey(Key.AS2, "Press and hold the remaining keys (G flat major)", otherKeys: Key.CS3);
        c1 = sheet.drawChord(0, interactive: true, notes: new (Key, int)[] { (Key.G2, -1), (Key.B2, -1), (Key.D3, -1) });
        if (correctAnswer) { yield return speakAndWait("Correct, all the keys are black."); }
        else
        {
            yield return speakAndWait("The right keys would have been B flat and D flat.");
            hitKey(Key.AS2, draw: false);
            yield return hitKey(Key.DS3, draw: false, wait: true);
        }
        yield return waitForContinue();
        mc.resetAllKeys();
        km.changeColor(Color.Blue, Key.FS2.ToString());
        km.changeColor(Color.Blue, Key.AS2.ToString());
        km.changeColor(Color.Blue, Key.CS3.ToString());
        yield return speakAndWait("Ok now for the final exercise, drag the notes to invert it twice");
        yield return waitForNoteInput(c1.ToArray(), new Key[] { Key.D3, Key.G3, Key.B3 }, new int[] { -1, -1, -1}, 
            "Drag the notes to invert the chord twice (G flat major)");
        if (correctAnswer) { yield return speakAndWait("Good job, that is the second inversion"); }
        else
        {
            yield return speakAndWait("To invert a chord twice you have to move the first and the second note up an octave.");
            sheet.removeNotes(c1);
            c1 = sheet.drawChord(0, interactive: true, notes: new (Key, int)[] { (Key.D3, -1), (Key.G3, -1), (Key.B3, -1) });
        }
        mc.resetAllKeys();
        hitKey(Key.CS3, draw: false);
        hitKey(Key.FS3, draw: false);
        yield return hitKey(Key.AS3, draw: false, wait: true);
        yield return waitForContinue();
        mc.resetAllKeys();
        sheet.clearAllNotes();
        yield return speakAndWait("That concludes this tutorial. It is the last one for now. You can say skip to repeat it or exit to leave.");
        yield return nextTutorialOrExit(4);
    }
}
