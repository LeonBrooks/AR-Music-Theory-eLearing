using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public enum Key
{
    C2, CS2, D2, DS2, E2, F2, FS2, G2, GS2, A2, AS2, B2,
    C3, CS3, D3, DS3, E3, F3, FS3, G3, GS3, A3, AS3, B3,
    C4, CS4, D4, DS4, E4, F4, FS4, G4, GS4, A4, AS4, B4,
    C5, CS5, D5, DS5, E5, F5, FS5, G5, GS5, A5, AS5, B5
}

public class MusicController : MonoBehaviour
{
    public static MusicController instance { get; private set; }
    public PianoVariant defautPiano;
    public Color defaultPlayColor;
    public KeyManager keyManager;

    private AudioSource[] audioPlayers;
    private bool[] keyActive;
    private Coroutine[] stoppers;
    private float baseVolume = 1;

    private void Awake()
    {
        //https://gamedevbeginner.com/singletons-in-unity-the-right-way/#unity_singleton
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioPlayers = new AudioSource[48];
        for (int i = 0; i < audioPlayers.Length; i++)
        {
            AudioSource s = gameObject.AddComponent<AudioSource>();
            s.playOnAwake = false;
            s.clip = defautPiano.keySounds[i];
            audioPlayers[i] = s;
        }

        keyActive = new bool[48];
        stoppers = new Coroutine[48];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool noteActivated(string key, Color color = Color.Black)
    {
        Key k;
        if (Enum.TryParse<Key>(key, true, out k))
        {
            noteActivated(k, color);
            return true;
        } else 
        {
            Debug.Log("MusicController.noteActivated: Key not found");
            return false;
        }
        
    }

    public void noteActivated(Key key, Color color = Color.Black)
    {
        keyActive[(int)key] = true;
        if (stoppers[(int)key] != null)
        {
            StopCoroutine(stoppers[(int)key]);
        }

        AudioSource s = audioPlayers[(int)key];
        s.Stop();
        s.volume = baseVolume;
        s.Play();

        if (color == Color.Black) { color = defaultPlayColor; }
        if (!(color == Color.Black || color == Color.White)) { keyManager.changeColor(color, key.ToString()); }
    }


    public bool noteDeactivated(string key, bool resetColor = true)
    {
        Key k;
        if (Enum.TryParse<Key>(key, true, out k))
        {
            noteDeactivated(k, resetColor);
            return true;
        }
        else
        {
            Debug.Log("MusicController.noteDeactivated: Key not found");
            return false;
        }
    }

    public void noteDeactivated(Key key, bool resetColor = true)
    {
        keyActive[(int)key] = false;
        stoppers[(int) key] = StartCoroutine(stopKey(key));

        if (resetColor) { keyManager.resetKey(key.ToString()); }
    }

    public void resetAllColors()
    {
        keyManager.resetColors();
    }

    //https://forum.unity.com/threads/fade-out-audio-source.335031/
    public IEnumerator stopKey(Key key)
    {
        AudioSource audioSource = audioPlayers[(int) key];
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / 0.5f;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = baseVolume;
    }
}
