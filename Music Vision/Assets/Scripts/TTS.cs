using Microsoft.MixedReality.Toolkit.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTS : MonoBehaviour
{
    private static TextToSpeech tts;

    void Awake()
    {
        tts = gameObject.GetComponent<TextToSpeech>();
    }

    public static bool isSpeaking()
    {
        return tts.IsSpeaking() || tts.SpeechTextInQueue();

    }

    public static void stopTTS()
    {
        tts.StopSpeaking();
    }

    public static void speakText(string text)
    {
        tts.StartSpeaking(text);
    }
}
