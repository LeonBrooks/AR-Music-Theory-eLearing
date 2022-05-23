using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tNotation : Tutorial
{
    public override IEnumerator tutorial()
    {
        yield return speakAndWait(@"
            Welcome to the second tutorial. In this  tutorial we will take a look at how the notes on the keyboard are named and how they are 
            written down in sheet music. So make sure that you have the music sheet and the keybaord positioned in a way
            that you can easily look at both. If you are ready to move on, say continue.");
        yield return waitForContinue();

        yield return speakAndWait(@"Let's dicuss what you can see on the sheet music first. As you can see there are two similar sections of lines.
                        Each one is called a staff.");

        tooltips.Add(runner.instantiateTooltip(sheet.topStaffAnchor, new Vector3(2, -1, 0), "top staff"));
        tooltips.Add(runner.instantiateTooltip(sheet.bottomStaffAnchor, new Vector3(-2, 1, 0), "bottom staff"));
        yield return waitForContinue();


        yield return speakAndWait("In these staves is where notes are drawn. A note can either be on a line or between two lines");
        clearTooltips();
        sheet.drawNote(Key.E4, 0, 0);
        sheet.drawNote(Key.A4, 0, 1);
        yield return waitForContinue();

        yield return speakAndWait("If a note would be above or below a staff, ledger lines are added to the note to clearly define it's position");
        sheet.clearAllNotes();
        sheet.drawNote(Key.C2, 0, 0);
        sheet.drawNote(Key.D2, 0, 1);
        sheet.drawNote(Key.E2, 0, 2);
        sheet.drawNote(Key.C4, 0, 3);
        sheet.drawNote(Key.A5, 0, 4);
        sheet.drawNote(Key.B5, 0, 5);
        yield return waitForContinue();

        yield return speakAndWait(@"The step of a note being on a line and the note being above that line always is the distance between
                                    one white key on the keyboard. If that sounds confusig don't worry, I'll show you.");
        sheet.clearAllNotes();
        yield return speakAndWait("If we look at this note");
        mc.linger = true;
        yield return hitKey(Key.C4, Color.Blue);
        yield return speakAndWait("The note on step above on the sheet would be this.");
        yield return hitKey(Key.D4, Color.Green);
        yield return speakAndWait("As you can see they are one white key apart on the keyboard.");
        yield return waitForContinue();
        yield return speakAndWait("One step more would be this note.");
        yield return hitKey(Key.E4, Color.Red);
        yield return waitForContinue();

        yield return speakAndWait("If you look closely at this example, it might seem that the sheet music steps are always one whole tone step.");
        yield return waitForContinue();
        yield return speakAndWait("But this is not true.");
        mc.resetAllKeys();
        yield return speakAndWait("If you look at these two notes:");
        hitKey(Key.E4, Color.Blue);
        yield return hitKey(Key.F4, Color.Red);
        yield return speakAndWait("You can see that they are one sheet music step apart as well but only on semitone step apart on the keyboard");
        yield return waitForContinue();
        yield return speakAndWait("The sheet music steps are always one white key on the keyboard. This example shows that very clearly.");
        mc.resetAllKeys();
        hitKey(Key.C4);
        hitKey(Key.D4);
        hitKey(Key.E4);
        hitKey(Key.F4);
        hitKey(Key.G4);
        hitKey(Key.A4);
        yield return hitKey(Key.B4);
        yield return waitForContinue();

        mc.resetAllKeys();
        yield return speakAndWait(@"Ok, now let's take a look at how the different notes are named.
            The first thing to know is that only the white keys have individual names. Don't worry about the black keys for now, we will talk about them later.
            ");
    }
}
