using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tControls : Tutorial
{
    GameObject handMenue;
    GameObject keyboarPlacer;
    GameObject sheetMusicContainer;
    public tControls() : base()
    {
        handMenue = GameObject.Find("HandMenu");
        keyboarPlacer = GameObject.Find("KeyboardPlacer");
        sheetMusicContainer = GameObject.Find("SheetMusicContainer");
    }
    public override IEnumerator tutorial()
    {
        handMenue.SetActive(false);
        keyboarPlacer.SetActive(false);
        sheetMusicContainer.SetActive(false);
        yield return speakAndWait("Welcom to Music Vision. This is a tutorial which introduces you to all the important controlls within the app. " +
            "If you have already done it just say exit to quit the tutorial. In order to move on say the word continue out loud.");
        yield return waitForContinue();
        yield return speakAndWait("Although it might be a bit akward when starting out, you can get used to having to say continue a lot when using this app. " +
            "Otherwise I would just be talking with no end.");
        yield return waitForContinue();
        yield return speakAndWait("The good thing is: Everytime you have to say continue or have to do a task, " +
            "you can say repeat instead to hear the last text again.", false);
        yield return speakAndWait("Try it out now. I will repeat this text");
        runner.resetRepeat();
        runner.displayTextPrompt("Say repeat.");
        while (true)
        {
            if (runner.waitForRepeat())
            {
                yield return repeat();
                initRepeat();
                runner.hideTextPrompt();
                break;
            }
            yield return null;
        }
        yield return new WaitForSeconds(1);
        yield return speakAndWait("Ok, remember you can do this whenever you have to say continue or have to do a task.");
        yield return waitForContinue();

        yield return speakAndWait("Now pay attention to your hands. If you point them somwhere, you can see a cursor where you are pointing to.");
        yield return waitForContinue();
        yield return speakAndWait("If you pinch your tumb and index finger and curl your remaining fingers, you can see that the cursor changes. " +
            "If you release the pinch it goes back to normal. ");
        yield return waitForContinue();
        yield return speakAndWait("Pinch and releas make up a click. Let's use that now. Here is a keyboard");
        keyboarPlacer.SetActive(true);
        mc.drawUserInput = false;
        yield return new WaitForSeconds(1);
        yield return speakAndWait("Look at a wall and place it there by using the pinch gesture to press the check mark button. Say continue when you are done.");
        yield return waitForContinue();
        yield return speakAndWait("On the next menu, we could adjust the rotation and size of the keyboard just, press the check mark for now.");
        yield return waitForContinue();
        yield return speakAndWait("A keyboard on a wall isn't very helpful, so let's fix that.");
        handMenue.SetActive(true);
        yield return speakAndWait("Turn one of your hands palm up. As you can see a menu appears. Press the top most button by touching it with your other hand. " +
            "Then look at a flat surface close to you, like a table. Place the keyboard there but don't skip the second menu this time. ");
        yield return waitForContinue();
        yield return speakAndWait("You can now adjust the sliders by pinching them and then moving your hand. " +
            "You can either use the cursor or grab them directly. Before you confirm make sure that the keyboard has a size where " +
            "you can touch one key without hitting any others. When you are done hit the check mark again.");
        yield return waitForContinue();

        yield return speakAndWait("Ok, besides a keyboard we have a music sheet aswell.");
        sheetMusicContainer.SetActive(true);
        mc.drawUserInput = true;
        sheet.drawNote(Key.E4, 0, 0, interactive: true);
        sheet.drawNote(Key.C5, 0, 1, interactive: true);
        yield return new WaitForSeconds(1);
        yield return speakAndWait("If you can't see it look around until you find it.");
        yield return waitForContinue();
        yield return speakAndWait("You can grab the sheet by the dot beween the arrows to move it around. Place it behind the keyboard, so that you can see both. " +
            "Adjust the size by using the slider to your liking.");
        yield return waitForContinue();
        yield return speakAndWait("Now try using the cursor to grab one of the notes and see if you can move it up and down. " +
            "If the sheet is to close move it further away.");
        yield return waitForContinue();
        yield return speakAndWait("Now open the hand menu again and press the second button to toggle off the menu on the music sheet.");
        yield return waitForContinue();
        yield return speakAndWait("If you need to move the music sheet or replace the keyboard at any point you can alwas do that over the hand menu. " +
            "You can also press the third button to bring up a another menu. You can use that one to adjust how deep the keyboard sits in the table.");
        yield return waitForContinue();
        yield return speakAndWait("Finally you can use the last button on the hand menu to bring up the tutorial selection. That concludes this tutorial. " +
            "Say exit out loud to quit it.");
        runner.resetRepeat();
        runner.displayTextPrompt("Say exit to quit");
        while (true)
        {
            if (runner.waitForRepeat())
            {
                yield return repeat();
            }
            yield return null;
        }
    }

    public override void exitCleanup()
    {
        base.exitCleanup();
        handMenue.SetActive(true);
        keyboarPlacer.SetActive(true);
        sheetMusicContainer.SetActive(true);
        runner.hideTextPrompt();
        mc.drawUserInput = true;
    }
}
