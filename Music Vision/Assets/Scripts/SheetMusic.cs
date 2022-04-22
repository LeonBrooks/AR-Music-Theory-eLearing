using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetMusic : MonoBehaviour
{
    public static Camera mainCam { get; private set; }
    public GameObject defaultNote;
    public GameObject ledgerLine;

    private float noteDistY;
    private float noteDistX;
    private float basePosY;
    private float basePosX;
    private float staffOffset;
    
    private List<Note> activeNotes;
    // Start is called before the first frame update
    void Start()
    {
        activeNotes = new List<Note>();
        noteDistY = 0.117f;
        noteDistX = 0.8f;
        mainCam = Camera.main;
        basePosY = -2.165f;
        basePosX = -3.5f;
        staffOffset = 0.957f;

        drawNote(Key.D3, 0, 0);
        drawNote(Key.E3, -1, 1);
        drawNote(Key.C4, 0, 0);
        drawNote(Key.B4, 0, 1);
        drawNote(Key.C5, 0, 2);

        
    }

    private void LateUpdate()
    {
        transform.LookAt(mainCam.transform);
        transform.Rotate(new Vector3(0,180,0), Space.Self);
    }

    public void removeAllNotes()
    {
        foreach(Note note in activeNotes)
        {
            Destroy(note.gameObject);
        }
        activeNotes.Clear();
    }

    public void removeNote(Note note)
    {
        activeNotes.Remove(note);
        Destroy(note.gameObject);
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
                pos = 22;
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
        float finalPos = basePosY + noteDistY * pos;
        if(pos > 14) { finalPos += staffOffset; }

        GameObject note = Instantiate<GameObject>(defaultNote, gameObject.transform);
        note.transform.localPosition = new Vector3(basePosX + offset * noteDistX, finalPos, 0);

        Note n = note.GetComponent<Note>();
        if (flatOrSharp == -1) { n.makeFlat(); }
        if (flatOrSharp == 1) { n.makeSharp(); }

        foreach(float lpos in getLedgerLinePos(key))
        {
            GameObject l = Instantiate<GameObject>(ledgerLine, gameObject.transform);
            l.transform.localPosition = new Vector3(basePosX + offset * noteDistX, lpos, 0);
            n.addLedgerLine(l);
        }

        if((pos > 8 && pos < 15) || pos > 21) { n.flip(); }
        activeNotes.Add(n);

        return n;
    }

    private List<float> getLedgerLinePos(Key key)
    {
        List<float> res = new List<float>();

        switch (key)
        {
            case Key.C2:
                res.Add(basePosY);
                res.Add(basePosY + 2 * noteDistY);
                break;

            case Key.D2:
            case Key.E2:
                res.Add(basePosY + 2 * noteDistY);
                break;

            case Key.C4:
                res.Add(basePosY + staffOffset + 15 * noteDistY);
                break;

            case Key.A5:
            case Key.B5:
                res.Add(basePosY + staffOffset +  27 * noteDistY);
                break;

        }

        return res;
    }
}
