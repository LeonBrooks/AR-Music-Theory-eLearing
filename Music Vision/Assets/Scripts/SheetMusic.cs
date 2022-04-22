using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetMusic : MonoBehaviour
{
    public static Camera mainCam { get; private set; }
    public float noteHight;
    public float noteDistY;
    public float noteDistX;
    public float basePosY;
    public float basePosX;
    public GameObject defaultNote;

    private List<Note> activeNotes;
    // Start is called before the first frame update
    void Start()
    {
        activeNotes = new List<Note>();
        noteDistY = 0.118f;
        noteDistX = 0.8f;
        mainCam = Camera.main;
        basePosY = -1.856f;
        basePosX = -3.5f;

        drawNote(Key.C2, 0, 0);
        drawNote(Key.B2, -1, 1);
        drawNote(Key.C3, 1, 2);
        drawNote(Key.FS3, 0, 0);
        drawNote(Key.E3, 1, 3);
    }

    private void LateUpdate()
    {
        transform.LookAt(mainCam.transform);
        transform.Rotate(new Vector3(0,180,0), Space.Self);
    }

    // -1 = flat, 0 = neutral, +1 = shap
    public Note drawNote(Key key, int flatOrSharp, int offset)
    {
        string noteString = key.ToString();
        if (noteString.Length != 2) { Debug.Log("SheetMusic.drawNote: only neutral keys allowd as input. Use flatOrSharap to set accidental"); return null; }

        string pitch = "" + noteString[0];
        string octave = "" + noteString[1];

        float pos = 0;
        switch (octave)
        {
            case ("3"):
                pos = 7;
                break;

            case ("4"):
                pos = 15;
                break;

            case("5"):
                pos = 23;
                break;
        }

        switch (pitch)
        {
            case ("D"):
                pos += 1;
                break;

            case ("E"):
                pos += 2;
                break;

            case ("F"):
                pos += 3;
                break;

            case ("G"):
                pos += 4;
                break;

            case ("A"):
                pos += 5;
                break;

            case ("B"):
                pos += 6;
                break;
        }
        pos = basePosY + noteDistY * pos;

        GameObject note = ((GameObject)Instantiate(defaultNote, gameObject.transform));
        note.transform.localPosition = new Vector3(basePosX + offset * noteDistX, pos, 0);

        Note n = note.GetComponent<Note>();
        if (flatOrSharp == -1) { n.makeFlat(); }
        if (flatOrSharp == 1) { n.makeSharp(); }
        return n;
    }
}
