using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tBlackKeys : Tutorial
{
    public override IEnumerator tutorial()
    {
        yield return speakAndWait("Welcome to the third tutorial. In the last tutorial we had a look at how sheet music is set up," +
            " how notes are named and written down, and how different interval are called. " +
            "This time we are going to take a closer look at the black keys and how they fit into everything we have learned so far.");
        yield return waitForContinue();

        Note[] notes = {sheet.drawNote(Key.C4,0,0), sheet.drawNote(Key.E4, 0, 0, interactive:true), sheet.drawNote(Key.G4, 0, 0, interactive: true) };
        yield return waitForNoteInput(notes, new Key[]{Key.C4, Key.E4, Key.G4 }, new int[] {0,-1,0}, "adsf");
        if (correctAnswer) { yield return speakAndWait("Yes"); }
        else { yield return speakAndWait("No"); }
    }
}
