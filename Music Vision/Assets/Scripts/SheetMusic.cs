using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheetMusic : MonoBehaviour
{
    public static Camera mainCam { get; private set; }
    public GameObject defaultNote;
    public GameObject noteHead;
    public GameObject ledgerLine;
    public float noteDistY { get; private set; }
    public float noteDistX { get; private set; }


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

        List<Note> l = drawChord(0, (Key.E4, 0), (Key.F4, 0), (Key.G4, 0));
        l[1].changeColor(Color.Red);
        drawNote(Key.C4, 0, 1);
        drawNote(Key.B5, 0, 2);
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

    public List<Note> drawChord(int offset, params (Key key, int flatOrSharp)[] notes)
    {
        if(notes.Length == 0) { Debug.Log("SheetMusic.drawChord: no notes were given"); return null; }
        List<Note> res = new List<Note>();

        bool baseFlipped =false;
        int basePos = (int) notes[0].key;
        if ((basePos > 15 && basePos < 24) || basePos > 35) { baseFlipped = true; }

        for(int i = 0; i < notes.Length; i++)
        {
            bool headOnly = true;
            if((i == 0 && !baseFlipped) || (i == notes.Length-1 && baseFlipped)) { headOnly = false; }

            Note n = drawNote(notes[i].key, notes[i].flatOrSharp, offset, headOnly);
            if(n != null) { res.Add(n); }
            if(n.isFlipped != baseFlipped) { n.flip(); }
        }

        int prev = -4;
        for(int i=0; i<notes.Length; i++)
        {
            if(notes[i].key.ToString().Contains("F") || notes[i].key.ToString().Contains("C"))
            {
                if (((int)notes[i].key) == prev + 1)
                {
                    if (baseFlipped) { res[i-1].flip(); } else { res[i].flip(); } 
                    prev = -4;
                    continue;
                }
            }
            else
            {
                if (((int)notes[i].key) == prev + 2)
                {
                    if (baseFlipped) { res[i - 1].flip(); } else { res[i].flip(); }
                    prev = -4;
                    continue;
                }
            }

            prev = (int) notes[i].key;
        }

        return res;
    }

    // -1 = flat, 0 = neutral, +1 = shap
    public Note drawNote(Key key, int flatOrSharp, int offset, bool headOnly = false)
    {
        GameObject type;
        if (headOnly) { type = noteHead; } else { type = defaultNote; }

        string noteString = key.ToString();
        if (noteString.Length != 2) { Debug.Log("SheetMusic.drawNote: only neutral keys allowed as input. Use flatOrSharap to set accidental"); return null; }

        

        GameObject note = Instantiate<GameObject>(type, gameObject.transform);
        note.transform.localPosition += new Vector3(basePosX + offset * noteDistX, getNotePosByKey(key), 0);

        Note n = note.GetComponent<Note>();
        if (flatOrSharp == -1) { n.makeFlat(); }
        if (flatOrSharp == 1) { n.makeSharp(); }
        n.key = key;
        n.offset = offset;

        addLedgerLinesToNote(n);

        if((key > Key.D3 && key < Key.C4) || key > Key.B4) { n.flip(); }
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

    public float getNotePosByKey(Key key)
    {
        string noteString = key.ToString();
        if (noteString.Length != 2) 
        {
            Debug.Log("SheetMusic.getNotePosByKey: only neutral keys allowed as input");
            return 0;
        }

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

            case ("5"):
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
        if (pos > 14) { finalPos += staffOffset; }

        return finalPos;
    }

    public void addLedgerLinesToNote(Note n) 
    {
        n.clearLedgerLines();
        foreach (float lpos in getLedgerLinePos(n.key))
        {
            GameObject l = Instantiate<GameObject>(ledgerLine, gameObject.transform);
            l.transform.localPosition += new Vector3(basePosX + n.offset * noteDistX, lpos, 0);
            n.addLedgerLine(l);
        }
    }
}
