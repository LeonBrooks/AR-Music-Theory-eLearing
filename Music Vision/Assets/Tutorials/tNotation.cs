using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tNotation : Tutorial
{
    public override IEnumerator tutorial()
    {
        TTS.speakText(@"Welcome to the second tutorial. In this  tutorial we will take a look at how the notes on the keyboard are named and how they are 
                        written down in sheet music. So make sure that you have the music sheet and the keybaord positioned in a way
                        that you can easily look at both. If you are ready to move on, say continue.");
        yield return new WaitWhile(() => TTS.isSpeaking());
        yield return runner.StartCoroutine(waitForContinue());

        TTS.speakText(@"Let's dicuss what you can see on the sheet music first. As you can see there are two similar sections of lines.
                        Each one is called a staff.");
        yield return new WaitWhile(() => TTS.isSpeaking());

        tooltips.Add(runner.instantiateTooltip(sheet.topStaffAnchor, new Vector3(2, -1, 0), "top staff"));
        tooltips.Add(runner.instantiateTooltip(sheet.bottomStaffAnchor, new Vector3(-2, 1, 0), "top staff"));
    }
}
