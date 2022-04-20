using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(menuName = "PianoVariant")]
public class PianoVariant : ScriptableObject
{
    public AudioClip[] keySounds = new AudioClip[48];
}
