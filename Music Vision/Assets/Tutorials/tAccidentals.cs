using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tAccidentals : Tutorial
{
    public override IEnumerator tutorial()
    {
        yield return speakAndWait("Welcome to the third tutorial. In the last tutorial we had a look at how sheet music is set up," +
            " how notes are named and written down, and how different intervals are called. " +
            "This time we are going to take a closer look at the black keys and how they fit into everything we have learned so far.");
        yield return waitForContinue();
        yield return speakAndWait("As you might remember only the white keys have names and can be directly represented in sheet music by notes");
        sheet.drawNote(Key.C4, 0, 0);
        sheet.drawNote(Key.D4, 0, 1);
        sheet.drawNote(Key.E4, 0, 2);
        sheet.drawNote(Key.F4, 0, 3);
        sheet.drawNote(Key.G4, 0, 4);
        sheet.drawNote(Key.A4, 0, 5);
        sheet.drawNote(Key.B4, 0, 6);
        km.showNameplate(Key.C4.ToString());
        km.showNameplate(Key.D4.ToString());
        km.showNameplate(Key.E4.ToString());
        km.showNameplate(Key.F4.ToString());
        km.showNameplate(Key.G4.ToString());
        km.showNameplate(Key.A4.ToString());
        km.showNameplate(Key.B4.ToString());
        yield return waitForContinue();

        yield return speakAndWait("So to tie in the black keys, we first have to look at the concept of accidentals. Let's start simple with this D.");
        mc.resetAllKeys();
        sheet.clearAllNotes();
        Note n1 = sheet.drawNote(Key.D4, 0, 1);
        instantiateTooltip(n1.transform, new Vector3(30,20,0), "D");
        yield return hitKey(Key.D4, draw: false, wait: true);
        yield return speakAndWait("An accidental changes the pitch of a note by exactly one semitone. " +
            "The sharp accidental increases the pitch by one semitone.");
        n1.makeSharp();
        tooltips[0].changeText("D sharp");
        mc.resetAllKeys();
        yield return hitKey(Key.DS4, draw: false, wait: true);
        yield return waitForContinue();
        yield return speakAndWait("As every key on the keyboard is one semitone apart, this ends up being a black key.");
        yield return waitForContinue();
        yield return speakAndWait("The second accidental we are going to cover is the flat. It does the exact opposite of a sharp. " +
            "It decreases the pitch of a note by one semitone.");
        mc.resetAllKeys();
        n1.makeFlat();
        tooltips[0].changeText("D flat");
        yield return hitKey(Key.CS4, draw: false, wait: true);
        yield return waitForContinue();
        yield return speakAndWait("As you might have noticed a D flat is the same key and tone as a C sharp. ");
        Note n2 = sheet.drawNote(Key.C4, 1, 0);
        instantiateTooltip(n2.transform, new Vector3(-30, 20, 0), "C sharp");
        n1.changeColor(Color.Green);
        n2.changeColor(Color.Red);
        n1.changeColor(Color.Blue, -1);
        n2.changeColor(Color.Blue, 1);
        km.changeColor(Color.Red, Key.C4.ToString());
        km.changeColor(Color.Green, Key.D4.ToString());
        yield return waitForContinue();
        yield return speakAndWait("That is also the reason why black keys don't have names, as they are always two notes at once. " +
            "Therefore the correct way to read a note and find the corresponding key is always by identifying the base note and then " +
            "looking at the offset given by an accidental.");
        yield return waitForContinue();
        mc.resetAllKeys();
        sheet.clearAllNotes();
        yield return speakAndWait("Something similar happens when looking at two white keys that are only a semitone apart. " +
            "If we look at the C again. ");
        n1 = sheet.drawNote(Key.C4, 0, 1);
        instantiateTooltip(n1.transform, new Vector3(30, 20, 0), "C");
        yield return hitKey(Key.C4, draw: false, wait: true);
        yield return speakAndWait("A C flat is the same key and tone as a B.");
        n1.makeFlat();
        tooltips[0].changeText("C flat");
        n1.changeColor(Color.Green, -1);
        n2 = sheet.drawNote(Key.B3, 0, 0,Color.Green);
        instantiateTooltip(n2.transform, new Vector3(-30, 15, 0), "B");
        yield return hitKey(Key.B3, Color.Green,draw: false, wait: true);
        yield return waitForContinue();
        yield return speakAndWait("At this point this might sound a bit confusing, as there is no apparent reason why one would make a system so complex. " +
            "The idea is that although a B and a C flat may sound the same individualy, " +
            "they are different when looking at them in a music theory context together with other notes they are interacting with. " +
            "This will become more clear over the next few tutorials.");
        yield return waitForContinue();

        mc.resetAllKeys();
        sheet.clearAllNotes();
        yield return speakAndWait("For now let's move on to some exercises to practice what we have learned so far.");
        yield return waitForContinue();
        yield return speakAndWait("Do you still remember from the last tutorial what this note is?");
        n1 = sheet.drawNote(Key.F4, 0, 0);
        yield return waitForName(Key.F4, 0, "Say the notes name out loud.");
        if (correctAnswer) { yield return speakAndWait("Right, this is a F."); }
        else { yield return speakAndWait("That wasn't right, this is a F."); }
        instantiateTooltip(n1.transform, new Vector3(30, 20, 0), "F");
        yield return waitForContinue();
        yield return speakAndWait("Can you also find the corresponding key?");
        yield return waitForKey(Key.F4, "Press and hold the corresponding key");
        if (correctAnswer) { yield return speakAndWait("Correct."); }
        else 
        { 
            yield return speakAndWait("The correct key would have been this one.");
            yield return hitKey(Key.F4, draw: false, wait: true);
            yield return waitForContinue();
        }
        mc.resetAllKeys();
        yield return speakAndWait("Ok, now what would this note be called?");
        n1.makeSharp();
        tooltips[0].changeText("?");
        yield return waitForName(Key.F4, 1, "Say the notes name out loud.");
        if (correctAnswer) { yield return speakAndWait("Yes, it is now a F sharp"); }
        else { yield return speakAndWait("No, it is now a F sharp"); }
        tooltips[0].changeText("F sharp");
        yield return speakAndWait("And which key would that be?");
        yield return waitForKey(Key.FS4, "Press and hold the corresponding key");
        if (correctAnswer) { yield return speakAndWait("Right, this is the first time to press a black key."); }
        else 
        { 
            yield return speakAndWait("The correct key is one semitone above, so the direct neighbour.");
            yield return hitKey(Key.FS4, draw: false, wait: true);
            yield return waitForContinue();
        }
        mc.resetAllKeys();
        yield return speakAndWait("and now the reverse. What would this note be called?");
        n1.makeFlat();
        tooltips[0].changeText("?");
        yield return waitForName(Key.F4, -1, "Say the notes name out loud.");
        if (correctAnswer) { yield return speakAndWait("Correct, it is now a F flat instead"); }
        else { yield return speakAndWait("Incorrect, it is now a F flat instead"); }
        tooltips[0].changeText("F flat");
        yield return speakAndWait("And what key would that correspond to?");
        yield return waitForKey(Key.E4, "Press and hold the corresponding key");
        if (correctAnswer) { yield return speakAndWait("Yes, it is the same key as an E"); }
        else
        {
            yield return speakAndWait("As there is no black key below a F, the key one semitone below is the same as an E.");
            yield return hitKey(Key.E4, draw: false, wait: true);
        }
        yield return waitForContinue();

        mc.resetAllKeys();
        sheet.clearAllNotes();
        yield return speakAndWait("Ok, let's do something slightly different now. This time we have this note.", addToRepeat: false);
        n1 = sheet.drawNote(Key.B4, 1, 0, interactive: true);
        yield return speakAndWait("First name it again?");
        yield return waitForName(Key.B4, 1, "Say the notes name out loud.");
        if (correctAnswer) { yield return speakAndWait("Right, this is a B sharp"); }
        else { yield return speakAndWait("No, this is a B sharp"); }
        instantiateTooltip(n1.transform, new Vector3(30, 20, 0), "B sharp");
        yield return speakAndWait("Ok, now we want to make this note the first G flat below it instead. To do that, point at the note, " +
            "then pinch your thumb and index finger to grab it. You can then drag it to where you want it by moving your hand up and down. " +
            "To add a sharp of flat move your hand to the right or left. When you are done release your fingers and say confirm.");
        tooltips[0].changeText("G(4) flat");
        yield return waitForNoteInput(new Note[] { n1 }, new Key[] { Key.G4 }, new int[] { -1 }, "Make the note the next lower G flat (G4)");
        if (correctAnswer) { yield return speakAndWait("Yes, that is exactly where we want it"); }
        else
        {
            mc.resetAllKeys();
            yield return speakAndWait("The correct place would have been here.");
            sheet.removeNote(n1);
            n1 = sheet.drawNote(Key.G4, -1, 0, interactive: true);
            instantiateTooltip(n1.transform, new Vector3(30, 20, 0), "G(4) flat");
            yield return hitKey(Key.FS4, draw: false, wait: true);
            yield return waitForContinue();
        }

        yield return speakAndWait("Now for the final exercise, make this note the closest E sharp");
        tooltips[0].changeText("E sharp");
        yield return waitForNoteInput(new Note[] { n1 }, new Key[] { Key.E4 }, new int[] { 1 }, "Make the note the closest E sharp");
        if (correctAnswer) { yield return speakAndWait("Yes, that would also be the same key as a F"); }
        else
        {
            yield return speakAndWait("No, it would be here. Which is the same key as a F on the keyboard");
            mc.resetAllKeys();
            sheet.removeNote(n1);
            n1 = sheet.drawNote(Key.E4, 1, 0, interactive: true);
            instantiateTooltip(n1.transform, new Vector3(30, 20, 0), "E sharp");
            yield return hitKey(Key.E4, draw: false, wait: true);
        }
        yield return waitForContinue();

        yield return speakAndWait("And we have reached the end of yet another tutorial. The next one will be the first more advanced music theory concept.");
        yield return nextTutorialOrExit(4);
    }
}
