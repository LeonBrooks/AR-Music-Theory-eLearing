using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MusicController : MonoBehaviour
{
    public static MusicController instance;

    public enum Key
    {
        C2, C3, C4, C5,
        CS2, CS3, CS4, CS5,
        D2, D3, D4, D5,
        DS2, DS3, DS4, DS5,
        E2, E3, E4, E5,
        F2, F3, F4, F5,
        FS2, FS3, FS4, FS5,
        G2, G3, G4, G5,
        GS2, GS3, GS4, GS5,
        A2, A3, A4, A5,
        AS2, AS3, AS4, AS5,
        B2, B3, B4, B5

    };


    // Start is called before the first frame update
    void Start()
    {

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
        Debug.Log("MusicController: playing " + key.ToString());
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
        Debug.Log("MusicController: stopped playing " + key.ToString());
    }
}
