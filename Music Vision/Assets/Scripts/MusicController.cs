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
    [SerializeField]
    private PianoVariant defautPiano;
    [SerializeField]
    private Color defaultPlayColor;
    private KeyManager keyManager;
    private SheetMusic sheet;

    public bool inputEnabled;
    public bool drawUserInput;
    public bool linger;
    public bool drawAsSharp;
    public int offset;

    private AudioSource[] audioPlayers;
    private bool[] keyActive;
    private List<Note> activeNotes;
    private HashSet<Key> fixedKeys;
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

            audioPlayers = new AudioSource[48];
            for (int i = 0; i < audioPlayers.Length; i++)
            {
                AudioSource s = gameObject.AddComponent<AudioSource>();
                s.playOnAwake = false;
                s.clip = defautPiano.keySounds[i];
                audioPlayers[i] = s;
            }

            keyManager = GameObject.Find("KeyboardPlacer/RotationOffsetContainer/Keyboard").GetComponent<KeyManager>();
            sheet = GameObject.Find("SheetMusicContainer/SheetMusic").GetComponent<SheetMusic>();

            keyActive = new bool[48];
            stoppers = new Coroutine[48];
            activeNotes = new List<Note>(new Note[49]);
            fixedKeys = new HashSet<Key>();
            initializeFreeMode();
        }
    }

    public bool keyPressed(string key)
    {
        Key k;
        if (Enum.TryParse<Key>(key, true, out k))
        {
            if (inputEnabled && !fixedKeys.Contains(k))
            {
                noteActivated(k);
            }
            return true;
        } else 
        {
            Debug.Log("MusicController.noteActivated: Key not found");
            return false;
        }
        
    }

    public void noteActivated(Key key, Color color = Color.Black, bool fix = false, bool draw = true)
    {
        if (fix) { fixedKeys.Add(key); }
        keyActive[(int)key] = true;        

        playSound(key);

        bool defaultColor = false;
        if (color == Color.Black) { color = defaultPlayColor;  defaultColor = true; }
        if (!(color == Color.Black || color == Color.White)) { keyManager.changeColor(color, key.ToString()); }

        if (draw && drawUserInput)
        {
            int flatOrSharp = 0;
            Key insertKey = key;
            if (drawAsSharp)
            {
                if (key.ToString().Length == 3) { insertKey--; flatOrSharp = 1; }
            }
            else if (key.ToString().Length == 3) { insertKey++; flatOrSharp = -1; }


            Note n = sheet.drawNote(insertKey, flatOrSharp, offset, linger);
            if(!defaultColor) { n.changeColor(color); }
            if (linger) { activeNotes.Insert(48, n); offset++; }
            else { activeNotes[(int)key] = n; }
        }
    }

    public void playSound(Key key)
    {
        if (stoppers[(int)key] != null)
        {
            StopCoroutine(stoppers[(int)key]);
        }

        AudioSource s = audioPlayers[(int)key];
        s.Stop();
        s.volume = baseVolume;
        s.Play();
    }

    


    public bool keyReleased(string key)
    {
        Key k;
        if (Enum.TryParse<Key>(key, true, out k))
        {
            if (inputEnabled && !fixedKeys.Contains(k))
            {
                noteDeactivated(k, !linger);
            }
            return true;
        }
        else
        {
            Debug.Log("MusicController.noteDeactivated: Key not found");
            return false;
        }
    }

    public void noteDeactivated(Key key, bool resetColor = true, bool draw = true)
    {
        keyActive[(int)key] = false;
        stopSound(key);
        if (fixedKeys.Contains(key)) { return; }

        if (resetColor) { keyManager.resetKey(key.ToString()); }

        if(!linger && draw && drawUserInput) 
        { 
            if(activeNotes[(int) key] != null)
            {
                sheet.removeNote(activeNotes[(int)key]);
                
            }
        }
    }

    public void stopSound(Key key)
    {
        stoppers[(int)key] = StartCoroutine(stopKey(key));
    }
    
    public void resetAllKeys()
    {
        fixedKeys.Clear();
        keyActive = new bool[48];
        for(int i = 0; i < keyActive.Length; i++)
        {
            if (keyActive[i]) { stopSound((Key) i); }
        }
        keyManager.resetAllKeys();
        sheet.removeNotes(activeNotes);
        activeNotes = new List<Note>(new Note[49]);
        offset = 0;
    }

    public void initializeTutorialMode ()
    {
        resetAllKeys();
        inputEnabled = false;
        drawUserInput = true;
        linger = false;
        drawAsSharp = true;
        offset = 0;
        sheet.clearAllNotes();
    }

    public void initializeFreeMode()
    {
        resetAllKeys();
        inputEnabled = true;
        drawUserInput = true;
        linger = false;
        drawAsSharp = true;
        offset = 0;
        sheet.clearAllNotes();
    }


    //https://forum.unity.com/threads/fade-out-audio-source.335031/
    private IEnumerator stopKey(Key key)
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

    public bool areActive(Key key, bool alternative = false, params Key[] otherKeys)
    {
        if (alternative && keyActive[(int) key]) { return true; }
        if (!alternative && !keyActive[(int)key]) { return false; }

        foreach (Key oKey in otherKeys)
        {
            if (alternative && keyActive[(int)oKey]) { return true; }
            if (!alternative && !keyActive[(int)oKey]) { return false; }  
        }

        if(alternative) { return false; } else { return true; }
    }
}
