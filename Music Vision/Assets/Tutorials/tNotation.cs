using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tNotation : Tutorial
{
    private KeyManager km;

    public tNotation() :base()
    {
        km = GameObject.Find("KeyboardPlacer/RotationOffsetContainer/Keyboard").GetComponent<KeyManager>();
    }

    public override IEnumerator tutorial()
    {
        /*yield return speakAndWait("Welcome to the second tutorial." +
            "In this  tutorial we will take a look at how the notes on the keyboard are named and how they are written down in sheet music." +
            "So make sure that you have the music sheet and the keybaord positioned in a way that you can easily look at both." +
            "If you are ready to move on, say continue.");
        yield return waitForContinue();

        yield return speakAndWait("Let's discuss what you can see on the sheet music first. As you can see there are two similar sections of lines." +
            "Each one is called a staff.");

        instantiateTooltip(sheet.topStaffAnchor, new Vector3(2, -1, 0), "top staff", new Vector3(0.03f, 0.03f, 0.03f));
        instantiateTooltip(sheet.bottomStaffAnchor, new Vector3(-2, 1, 0), "bottom staff", new Vector3(0.03f, 0.03f, 0.03f));
        yield return waitForContinue();


        yield return speakAndWait("Notes are drawn in these staves. A note can either be on a line or between two lines");
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

        yield return speakAndWait("The step of a note being on a line and the note being above that line always is the distance between" +
            "one white key on the keyboard. If that sounds confusig don't worry, I'll show you.");
        sheet.clearAllNotes();
        yield return speakAndWait("If we look at this note");
        mc.linger = true;
        yield return hitKey(Key.C4, Color.Blue, wait: true);
        yield return speakAndWait("The note on step above on the sheet would be this.");
        yield return hitKey(Key.D4, Color.Green, wait: true);
        yield return speakAndWait("As you can see they are one white key apart on the keyboard.");
        yield return waitForContinue();
        yield return speakAndWait("One step more would be this note.");
        yield return hitKey(Key.E4, Color.Red, wait: true);
        yield return waitForContinue();

        yield return speakAndWait("Take a close look at this example. Here it might seem that the sheet music steps are equivalent to one whole tone step.");
        yield return waitForContinue();
        yield return speakAndWait("But this is not true.");
        mc.resetAllKeys();
        yield return speakAndWait("If you look at these two notes:");
        hitKey(Key.E4, Color.Blue);
        yield return hitKey(Key.F4, Color.Red, wait: true);
        yield return speakAndWait("You can see that they are one sheet music step apart but only on semitone step apart on the keyboard");
        yield return waitForContinue();
        yield return speakAndWait("The sheet music steps are always one white key on the keyboard. This example shows that very clearly.");
        mc.resetAllKeys();
        hitKey(Key.C4);
        hitKey(Key.D4);
        hitKey(Key.E4);
        hitKey(Key.F4);
        hitKey(Key.G4);
        hitKey(Key.A4);
        yield return hitKey(Key.B4, wait: true);
        yield return waitForContinue();

        mc.resetAllKeys();
        yield return speakAndWait("Ok, now let's take a look at how the different notes are named." +
            "The first thing to know is that only the white keys have individual names. Don't worry about the black keys for now, we will talk about them later." +
            "The first note we are going to look at is the C.");

        Note nC = sheet.drawNote(Key.C4,0,0);
        km.showNameplate(Key.C4.ToString());
        instantiateTooltip(nC.gameObject.transform, new Vector3(-20, -20, 0), "C");
        yield return hitKey(Key.C4, draw:false, wait: true);
        yield return waitForContinue();
        
        yield return speakAndWait("The next four notes above the C are named in alphabetical order.");
        Note nD = sheet.drawNote(Key.D4, 0, 1);
        km.showNameplate(Key.D4.ToString());
        instantiateTooltip(nD.gameObject.transform, new Vector3(-30, 41, 0), "D");
        yield return hitKey(Key.D4, draw: false, wait: true);

        Note nE = sheet.drawNote(Key.E4, 0, 2);
        km.showNameplate(Key.E4.ToString());
        instantiateTooltip(nE.gameObject.transform, new Vector3(-20, -28, 0), "E");
        yield return hitKey(Key.E4, draw: false, addToRepeat: true, wait: true);

        Note nF = sheet.drawNote(Key.F4, 0, 3);
        km.showNameplate(Key.F4.ToString());
        instantiateTooltip(nF.gameObject.transform, new Vector3(-25, 34, 0), "F");
        yield return hitKey(Key.F4, draw: false, wait: true);

        Note nG = sheet.drawNote(Key.G4, 0, 4);
        km.showNameplate(Key.G4.ToString());
        instantiateTooltip(nG.gameObject.transform, new Vector3(-20, -35, 0), "G");
        yield return hitKey(Key.G4, draw: false, wait: true);
        yield return waitForContinue();

        yield return speakAndWait("The next two notes are what was missing at the start: A and B.");
        Note nA = sheet.drawNote(Key.A4, 0, 5);
        km.showNameplate(Key.A4.ToString());
        instantiateTooltip(nA.gameObject.transform, new Vector3(-25, 26.5f, 0), "A ");
        yield return hitKey(Key.A4, draw: false, wait: true);

        Note nB = sheet.drawNote(Key.B4, 0, 6);
        km.showNameplate(Key.B4.ToString());
        instantiateTooltip(nB.gameObject.transform, new Vector3(-20, -42, 0), "B");
        yield return hitKey(Key.B4, draw: false, wait: true);
        yield return waitForContinue();

        yield return speakAndWait("After the B the pattern repeats and we start back at C again");
        Note nC2 = sheet.drawNote(Key.C5, 0, 7);
        km.showNameplate(Key.C5.ToString());
        instantiateTooltip(nC2.gameObject.transform, new Vector3(0, 19, 0), "C");
        yield return hitKey(Key.C5, draw: false, wait: true);
        yield return waitForContinue();
        yield return speakAndWait("As you can see this note is flipped upside down. This is because it is on the upper half of the staff." +
            "There is no special reason for this. It is simply done because it looks nicer and is more compact.");
        yield return waitForContinue();

        yield return speakAndWait("It is important to keep in mind that this is the English way of naming notes." +
            "In some other countries and languages the namings are sometimes different, so make sure to check how they are named in your country.");
        yield return waitForContinue();
        yield return speakAndWait("Together these eight notes make up an octave.");
        clearTooltips();
        instantiateTooltip(nC.gameObject.transform, new Vector3(80, -20, 0), "Octave");
        tooltips[0].activateSecondLine(nC2.gameObject);
        yield return waitForContinue();
        yield return speakAndWait("The word Octave simply describes a step of eight notes." +
            "If you take a close look at the keyboard you can see that if two notes are an octave apart they are the same note.");
        mc.resetAllKeys();
        km.showNameplate(Key.C4.ToString());
        km.showNameplate(Key.C5.ToString());
        hitKey(Key.C4, Color.Blue, draw: false);
        yield return hitKey(Key.C5, Color.Blue, draw: false, wait: true);
        km.showNameplate(Key.D4.ToString());
        km.showNameplate(Key.D5.ToString());
        hitKey(Key.D4, Color.Green, draw: false);
        yield return hitKey(Key.D5, Color.Green, draw: false, wait: true);
        km.showNameplate(Key.E4.ToString());
        km.showNameplate(Key.E5.ToString());
        hitKey(Key.E4, Color.Red, draw: false);
        yield return hitKey(Key.E5, Color.Red, draw: false, wait: true);
        yield return waitForContinue();


        yield return speakAndWait("Other distances have names aswell. The interval between two notes is a second.");
        clearTooltips();
        mc.resetAllKeys();
        instantiateTooltip(nC.gameObject.transform, new Vector3(80, -20, 0), "Second");
        tooltips[0].activateSecondLine(nD.gameObject);
        hitKey(Key.C4, draw: false);
        yield return hitKey(Key.D4, draw: false, wait: true);
        yield return waitForContinue();

        yield return speakAndWait("Three notes apart is a third.");
        mc.resetAllKeys();
        tooltips[0].changeText("Third");
        tooltips[0].activateSecondLine(nE.gameObject);
        hitKey(Key.C4, draw: false);
        yield return hitKey(Key.E4, draw: false, wait: true);
        yield return waitForContinue();

        yield return speakAndWait("The other interval are also just named numerically");
        mc.resetAllKeys();
        tooltips[0].changeText("Fourth");
        tooltips[0].activateSecondLine(nF.gameObject);
        hitKey(Key.C4, draw: false);
        yield return hitKey(Key.F4, draw: false, wait: true);

        mc.resetAllKeys();
        tooltips[0].changeText("Fifth");
        tooltips[0].activateSecondLine(nG.gameObject);
        hitKey(Key.C4, draw: false);
        yield return hitKey(Key.G4, draw: false, wait: true);

        mc.resetAllKeys();
        tooltips[0].changeText("Sixth");
        tooltips[0].activateSecondLine(nA.gameObject);
        hitKey(Key.C4, draw: false);
        yield return hitKey(Key.A4, draw: false, wait: true);

        mc.resetAllKeys();
        tooltips[0].changeText("Seventh");
        tooltips[0].activateSecondLine(nB.gameObject);
        hitKey(Key.C4, draw: false);
        yield return hitKey(Key.B4, draw: false, wait: true);

        yield return speakAndWait("And then again the octave", false);
        mc.resetAllKeys();
        tooltips[0].changeText("Octave");
        tooltips[0].activateSecondLine(nC2.gameObject);
        hitKey(Key.C4, draw: false);
        yield return hitKey(Key.C5, draw: false, wait: true);
        yield return waitForContinue();

        clearTooltips();
        mc.resetAllKeys();
        yield return speakAndWait("Ok, that was already quite a bit of information. So let's recap.");
        yield return waitForContinue();
        yield return speakAndWait("Notes in sheet music are based on the white keys of the keyboard. The can be either a semitone or a whole tone apart");
        km.showNameplate(Key.C4.ToString());
        km.showNameplate(Key.D4.ToString());
        km.showNameplate(Key.E4.ToString());
        km.showNameplate(Key.F4.ToString());
        km.showNameplate(Key.G4.ToString());
        km.showNameplate(Key.A4.ToString());
        km.showNameplate(Key.B4.ToString());
        km.showNameplate(Key.C5.ToString());
        hitKey(Key.C4, draw: false);
        hitKey(Key.D4, draw: false);
        hitKey(Key.E4, draw: false);
        hitKey(Key.F4, draw: false);
        hitKey(Key.G4, draw: false);
        hitKey(Key.A4, draw: false);
        hitKey(Key.B4, draw: false);
        yield return hitKey(Key.C5, draw: false, wait: true);
        yield return waitForContinue();
        yield return speakAndWait("They are named from C to G and then from A to B. After that the pattern repeats.");
        instantiateTooltip(nC.gameObject.transform, new Vector3(-20, -20, 0), "C");
        instantiateTooltip(nD.gameObject.transform, new Vector3(-30, 41, 0), "D");
        instantiateTooltip(nE.gameObject.transform, new Vector3(-20, -28, 0), "E");
        instantiateTooltip(nF.gameObject.transform, new Vector3(-25, 34, 0), "F");
        instantiateTooltip(nG.gameObject.transform, new Vector3(-20, -35, 0), "G");
        instantiateTooltip(nA.gameObject.transform, new Vector3(-25, 26.5f, 0), "A ");
        instantiateTooltip(nB.gameObject.transform, new Vector3(-20, -42, 0), "B");
        instantiateTooltip(nC2.gameObject.transform, new Vector3(0, 19, 0), "C");
        yield return waitForContinue();
        clearTooltips();
        yield return speakAndWait("The intervals between notes are named numerically, except for an octave which is eight notes.");
        instantiateTooltip(nC.gameObject.transform, new Vector3(74, -12, 0), "Second");
        tooltips[0].activateSecondLine(nD.gameObject);
        instantiateTooltip(nC.gameObject.transform, new Vector3(40, 30, 0), "Third");
        tooltips[1].activateSecondLine(nE.gameObject);
        instantiateTooltip(nC.gameObject.transform, new Vector3(40, 50, 0), "Fourth");
        tooltips[2].activateSecondLine(nF.gameObject);
        instantiateTooltip(nC.gameObject.transform, new Vector3(75, -31, 0), "Fifth");
        tooltips[3].activateSecondLine(nG.gameObject);
        instantiateTooltip(nC.gameObject.transform, new Vector3(75, -50, 0), "Sixth");
        tooltips[4].activateSecondLine(nA.gameObject);
        instantiateTooltip(nC.gameObject.transform, new Vector3(75, -70, 0), "Seventh");
        tooltips[5].activateSecondLine(nB.gameObject);
        instantiateTooltip(nC.gameObject.transform, new Vector3(75, -90, 0), "Octave");
        tooltips[6].activateSecondLine(nC2.gameObject);
        yield return waitForContinue();

        clearTooltips();
        sheet.clearAllNotes();
        mc.resetAllKeys();
        yield return speakAndWait("Ok now let's move on to some exercises.", false);
        yield return speakAndWait("Look at this note:");
        Note nC = sheet.drawNote(Key.C4, 0, 0);
        yield return hitKey(Key.C4, fix: true, wait: true, draw: false);
        yield return speakAndWait("What is it's name? Say it out loud.");
        yield return waitForName(Key.C4, 0, "Say out the notes name loud");
        km.showNameplate(Key.C4.ToString());
        instantiateTooltip(nC.gameObject.transform, new Vector3(30, 15, 0), "C");
        if (correctAnswer) { yield return speakAndWait("Yes, this is a C"); }
        else { yield return speakAndWait("Not quite right. This is a C"); }
        yield return waitForContinue();

        sheet.removeNote(nC);
        mc.resetAllKeys();
        yield return speakAndWait("Now let's do it the other way around. Press an E on the keyboard.");
        yield return waitForKey(Key.E4, "Press and hold an E on the keyboard.", alternative: true, otherKeys: new Key[] { Key.E2, Key.E3, Key.E5 });
        if (correctAnswer) { yield return speakAndWait("Yes, this is an E. Other options would have been:"); }
        else { yield return speakAndWait("No, that was not an E. This are all Es on the keyboard."); }
        mc.linger = true;
        hitKey(Key.E2);
        hitKey(Key.E3);
        hitKey(Key.E4);
        yield return hitKey(Key.E5, wait: true);
        mc.linger = false;
        yield return waitForContinue();

        clearTooltips();
        sheet.clearAllNotes();
        mc.resetAllKeys();*/
        yield return speakAndWait("Now one last thing before we wrap up this tutorial." +
            "As you may have already noticed the top and bottom staff don't work in the exact same way." +
            "Where a note is drawn into a staff is determined by the sign at the beginning. Those signs are called clefs.");
        instantiateTooltip(sheet.trebleClefAnchor, new Vector3(2, 0.5f, 0), "clef", new Vector3(0.03f, 0.03f, 0.03f)) ;
        instantiateTooltip(sheet.bassClefAnchor, new Vector3(2,0.5f,0), "clef", new Vector3(0.03f, 0.03f, 0.03f));
        yield return waitForContinue();
        yield return speakAndWait("The two clefs here are the treble clef and the bass clef");
        tooltips[0].changeText("treble clef");
        tooltips[1].changeText("base clef");
        yield return waitForContinue();

        yield return speakAndWait("These are the clefs typially used in piano sheet music. Although other instruments may use different clefs." +
            "To explain how the treble and base clef work with a piano we have to take a closer look at how the keyboard is set up.");
        yield return waitForContinue();
        clearTooltips();
        yield return speakAndWait("As you may have noticed our keyboard only has four octaves.");
        Note nC = sheet.drawNote(Key.C2, 0, 0);
        Note nD = sheet.drawNote(Key.C3, 0, 1);
        Note nE = sheet.drawNote(Key.C4, 0, 2);
        Note nF = sheet.drawNote(Key.C5, 0, 3);
        instantiateTooltip(nC.transform, new Vector3(25, 12,0), "C2");
        instantiateTooltip(nD.transform, new Vector3(30, 20, 0), "C3");
        instantiateTooltip(nE.transform, new Vector3(-30, 20, 0), "C4");
        instantiateTooltip(nF.transform, new Vector3(30, 20, 0), "C5");
        hitKey(Key.C2, draw: false, addToRepeat: false);
        hitKey(Key.C3, draw: false, addToRepeat: false);
        hitKey(Key.C4, draw: false, addToRepeat: false);
        yield return hitKey(Key.C5, draw: false, wait: true, addToRepeat: false);
        yield return waitForContinue();
        yield return speakAndWait("A normal piano has one more octave below our keyboard and two more octaves above, as well as some extra keys on each end." +
            "That is why our lowest octave is the C2 octave. For our purposes however this is more than sufficient.");
        yield return waitForContinue();

        clearTooltips();
        sheet.clearAllNotes();
        mc.resetAllKeys();
        yield return speakAndWait("The C4 is also know as the middle C");
        nC = sheet.drawNote(Key.C4, 0, 1);
        instantiateTooltip(nC.transform, new Vector3(30, -15, 0), "middle C");
        yield return hitKey(Key.C4, draw: false, wait: true);
        yield return waitForContinue();
        yield return speakAndWait("It is the connection point between the treble clef and the bass clef." +
            "Notes below it naturally continue downwards in the base clef,whiles notes above it naturally continue upwards in the treble clef.");
        nE = sheet.drawNote(Key.B3, 0, 0);
        nE.changeColor(Color.Green);
        yield return hitKey(Key.B3, Color.Green, draw: false, wait: true);
        nF = sheet.drawNote(Key.D4, 0, 2);
        nF.changeColor(Color.Red);
        yield return hitKey(Key.D4, Color.Red, draw: false, wait: true);
        yield return waitForContinue();
        clearTooltips();
        sheet.clearAllNotes();
        mc.resetAllKeys();
        yield return speakAndWait("More formally the treble clef is defined as having the inner spiral crossing the G4 line");
        nC = sheet.drawNote(Key.G4, 0, 0);
        instantiateTooltip(nC.transform, new Vector3(30, 20, 0), "G4");
        yield return hitKey(Key.G4, draw: false, wait: true);
        yield return speakAndWait("And the bass clef is defined as having the dot on the F3 line.");
        nD = sheet.drawNote(Key.F3, 0, 0);
        instantiateTooltip(nD.transform, new Vector3(30, 20, 0), "F3");
        yield return hitKey(Key.F3, draw: false, wait: true);
        yield return waitForContinue();
        yield return speakAndWait("Although we won't be doing that, theoretically any note can be written in any clef by adding enough ledger lines.");
        yield return waitForContinue();
        yield return speakAndWait("For piano generally the top saff is written in the treble clef and contains the notes for the right hand," +
            "while the bottom staff is written in the bass cleff with notes for the left hand.");
        yield return waitForContinue();
        yield return speakAndWait("That concludes the second tutorial.");
        yield return nextTutorialOrExit(2);
    }
}
