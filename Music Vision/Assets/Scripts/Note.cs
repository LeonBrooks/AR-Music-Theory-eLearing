using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour, IMixedRealityPointerHandler
{
    public bool isInteractive;
    public Key key;
    public int offset;

    public bool isFlipped { get; private set; }
    public int flatOrSharp { get; private set; }

    [SerializeField]
    private string type;

    private Color color;
    private Vector3 basePosX;
    private Vector3 basePosY;
    private float flipXOffset = 0.2375f;
    private float thresholdX;
    private float thresholdY;
    private SheetMusic sheet;
    private List<GameObject> ledgerLines;

    // Start is called before the first frame update
    void Awake()
    {
        ledgerLines = new List<GameObject>();
        isFlipped = false;
        basePosX = Vector3.zero;
        basePosY = Vector3.zero;

        thresholdX = 0.015f;
        thresholdY = 0.025f;
        flatOrSharp = 0;
        key = Key.C4;
        sheet = gameObject.GetComponentInParent<SheetMusic>();
        color = Color.Black;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void makeSharp(bool propagateToMC = false)
    {
        if(flatOrSharp == 1) { return; }
        if(propagateToMC) { MusicController.instance.noteDeactivated(key + flatOrSharp, draw: false); }
        gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        flatOrSharp = 1;
        if(propagateToMC) { MusicController.instance.noteActivated(key + flatOrSharp, color, draw: false); }
    }

    public void makeFlat(bool propagateToMC = false)
    {
        if (flatOrSharp == -1) { return; }
        if (propagateToMC) { MusicController.instance.noteDeactivated(key + flatOrSharp, draw: false); }
        gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        flatOrSharp = -1;
        if (propagateToMC) { MusicController.instance.noteActivated(key + flatOrSharp, color, draw: false); }
    }

    public void makeNeutral(bool propagateToMC = false)
    {
        if (flatOrSharp == 0) { return; }
        if (propagateToMC) { MusicController.instance.noteDeactivated(key + flatOrSharp, draw: false); }
        gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        flatOrSharp = 0;
        if (propagateToMC) { MusicController.instance.noteActivated(key + flatOrSharp, color, draw: false); }
    }

    public void addLedgerLine(GameObject ledgerLine)
    {
        ledgerLines.Add(ledgerLine);
        //if (isFlipped) { flipLedgerLine(ledgerLine); }
    }

    public void clearLedgerLines()
    {
        foreach (GameObject ledgerLine in ledgerLines)
        {
            Destroy(ledgerLine);
        }
        ledgerLines.Clear();
    }

    /*public void flipAllLedgerLines()
    {
        foreach (GameObject l in ledgerLines)
        {
            flipLedgerLine(l);
        }
    }*/

    /*private void flipLedgerLine(GameObject ledgerLine)
    {
        ledgerLine.transform.localScale *= -1;
        if(isFlipped)
        {
            ledgerLine.transform.localPosition -= new Vector3(flipXOffset, 0, 0);
        }
        else
        {
            ledgerLine.transform.localPosition += new Vector3(flipXOffset, 0, 0);
        }
    }*/

    public void flip()
    {
        Transform flat = gameObject.transform.GetChild(0).transform;
        Transform sharp = gameObject.transform.GetChild(1).transform;
        if (isFlipped)
        {
            transform.localPosition += new Vector3(flipXOffset, 0, 0);
            flat.localPosition = new Vector3(flat.localPosition.x * 2, flat.localPosition.y, flat.localPosition.z);
            sharp.localPosition = new Vector3(sharp.localPosition.x * 2, sharp.localPosition.y, sharp.localPosition.z);
        }
        else
        {
            transform.localPosition -= new Vector3(flipXOffset, 0, 0);
            flat.localPosition = new Vector3(flat.localPosition.x / 2, flat.localPosition.y, flat.localPosition.z);
            sharp.localPosition = new Vector3(sharp.localPosition.x / 2, sharp.localPosition.y, sharp.localPosition.z);
        }
        
        transform.localScale *= -1;
        flat.localScale *= -1;
        sharp.localScale *= -1;
        flat.localPosition *= -1;
        sharp.localPosition *= -1;

        //flipAllLedgerLines();
        isFlipped = !isFlipped;
    }

    public void changeColor(Color color, int changeOnlyFlatOrSharp = 0)
    {
        Sprite note = Resources.Load<Sprite>(type + "_" + color.ToString());
        Sprite flat = Resources.Load<Sprite>("flat" + "_" + color.ToString());
        Sprite sharp = Resources.Load<Sprite>("sharp" + "_" + color.ToString());

        if(note == null || flat == null || sharp == null)
        {
            Debug.Log("Note: Sprites for the color " + color.ToString() + " not found");
            return;
        }

        if(changeOnlyFlatOrSharp == -1) { gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = flat; }
        else if(changeOnlyFlatOrSharp == 1) { gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = sharp; }
        else
        {
            this.color = color;
            gameObject.GetComponent<SpriteRenderer>().sprite = note;
            gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = flat;
            gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = sharp;
        }
    }

    public bool incrementKey()
    {
        if(key == Key.B5) { return false; }

        MusicController.instance.noteDeactivated(key + flatOrSharp, draw: false);
        string pitch = "" + key.ToString()[0];
        switch (pitch)
        {
            case ("C"):
            case ("D"):
            case ("F"):
            case ("G"):
            case ("A"):
                key += 2;
                break;

            case ("E"):
            case ("B"):
                key++;
                break;
        }
        MusicController.instance.noteActivated(key + flatOrSharp, color, draw: false);

        return true;
    }

    public bool decrementKey()
    {
        if (key == Key.C2) { return false; }

        MusicController.instance.noteDeactivated(key + flatOrSharp, draw: false);
        string pitch = "" + key.ToString()[0];
        switch (pitch)
        {
            case ("D"):
            case ("E"):
            case ("G"):
            case ("A"):
            case ("B"):
                key -= 2;
                break;

            case ("C"):
            case ("F"):
                key--;
                break;
        }
        MusicController.instance.noteActivated(key + flatOrSharp, color, draw: false);

        return true;
    }

    public void adjustPos()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, sheet.getNotePosByKey(key), transform.localPosition.z);
        clearLedgerLines();
        sheet.addLedgerLinesToNote(this);
    }

    private void OnDestroy()
    {
        clearLedgerLines();
    }

    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        basePosX = eventData.Pointer.Position;
        basePosY = eventData.Pointer.Position;
    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {
        if (!isInteractive || !MusicController.instance.noteInputEnabled) { return; }
        Vector3 pointerPos = eventData.Pointer.Position;
        float deltaY = pointerPos.y - basePosY.y;
        float deltaX = pointerPos.x - basePosX.x;

        if(deltaY > thresholdY)
        {
            if (incrementKey())
            {
                basePosY = eventData.Pointer.Position;
                adjustPos();
            }
        }
        else if(deltaY < -thresholdY)
        {
            if (decrementKey())
            {
                adjustPos();
                basePosY = eventData.Pointer.Position;
            }
        }

        if(deltaX > thresholdX)
        {
            makeSharp(true);
        }
        else if(deltaX < -thresholdX)
        {
            makeFlat(true);
        }
        else
        {
            makeNeutral(true);
        }
    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
        if (!isInteractive || !MusicController.instance.noteInputEnabled) { return; }
        MusicController.instance.noteDeactivated(key + flatOrSharp, false, false);
    }

    public void OnPointerClicked(MixedRealityPointerEventData eventData){}
}
