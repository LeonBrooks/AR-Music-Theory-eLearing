using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class MusicController : MonoBehaviour
{
    public static MusicController instance { get; private set; }
    public PianoVariant defautPiano;
    private AudioSource[] audioPlayers;
    private bool[] keyActive;
    private Coroutine[] stoppers;
    private float baseVolume = 1;

    public enum Key
    {
        C2, CS2, D2, DS2, E2, F2, FS2, G2, GS2, A2, AS2, B2,
        C3, CS3, D3, DS3, E3, F3, FS3, G3, GS3, A3, AS3, B3,
        C4, CS4, D4, DS4, E4, F4, FS4, G4, GS4, A4, AS4, B4,
        C5, CS5, D5, DS5, E5, F5, FS5, G5, GS5, A5, AS5, B5
    }

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

    public bool noteActivated(string key)
    {
        Key k;
        if (Enum.TryParse<Key>(key, true, out k))
        {
            noteActivated(k);
            return true;
        } else 
        {
            Debug.Log("MusicController.noteActivated: Key not found");
            return false;
        }
        
    }

    public void noteActivated(Key key)
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
    }


    public bool noteDeactivated(string key)
    {
        Key k;
        if (Enum.TryParse<Key>(key, true, out k))
        {
            noteDeactivated(k);
            return true;
        }
        else
        {
            Debug.Log("MusicController.noteDeactivated: Key not found");
            return false;
        }
    }

    public void noteDeactivated(Key key)
    {
        keyActive[(int)key] = false;
        stoppers[(int) key] = StartCoroutine(stopKey(key));
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
