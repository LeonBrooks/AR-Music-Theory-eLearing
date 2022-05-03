using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour, IMixedRealityPointerHandler
{
    private List<GameObject> ledgerLines;
    public string type;
    public bool isFlipped;
    public Key key;
    public int offset;
    public bool isInteractive;
    public int flatOrSharp { get; private set; }

    private Vector3 basePosX;
    private Vector3 basePosY;
    private float thresholdX;
    private float thresholdY;
    private SheetMusic sheet;

    // Start is called before the first frame update
    void Awake()
    {
        ledgerLines = new List<GameObject>();
        isFlipped = false;
        basePosX = Vector3.zero;
        basePosY = Vector3.zero;

        thresholdX = 0.035f;
        thresholdY = 0.025f;
        flatOrSharp = 0;
        key = Key.C4;
        sheet = gameObject.GetComponentInParent<SheetMusic>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void makeSharp()
    {
        gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        flatOrSharp = 1;
    }

    public void makeFlat()
    {
        gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        flatOrSharp = -1;
    }

    public void makeNeutral()
    {
        gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        flatOrSharp = 0;
    }

    public void addLedgerLine(GameObject ledgerLine)
    {
        ledgerLines.Add(ledgerLine);
        if (isFlipped) { flipLedgerLine(ledgerLine); }
    }

    public void clearLedgerLines()
    {
        foreach (GameObject ledgerLine in ledgerLines)
        {
            Destroy(ledgerLine);
        }
        ledgerLines.Clear();
    }

    private void flipAllLedgerLines()
    {
        foreach (GameObject l in ledgerLines)
        {
            flipLedgerLine(l);
        }
    }

    private void flipLedgerLine(GameObject ledgerLine)
    {
        ledgerLine.transform.localScale *= -1;
    }

    public void flip()
    {
        
        isFlipped = !isFlipped;
        transform.localScale *= -1;

        Transform flat = gameObject.transform.GetChild(0).transform;
        Transform sharp = gameObject.transform.GetChild(1).transform;
        flat.localScale *= -1;
        sharp.localScale *= -1;
        flat.localPosition *= -1;
        sharp.localPosition *= -1;

        flipAllLedgerLines();
    }

    public void changeColor(Color color)
    {
        Sprite note = Resources.Load<Sprite>(type + "_" + color.ToString());
        Sprite flat = Resources.Load<Sprite>("flat" + "_" + color.ToString());
        Sprite sharp = Resources.Load<Sprite>("sharp" + "_" + color.ToString());

        if(note == null || flat == null || sharp == null)
        {
            Debug.Log("Note: Sprites for the color " + color.ToString() + " not found");
        }

        gameObject.GetComponent<SpriteRenderer>().sprite = note;
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = flat;
        gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = sharp;
    }

    public bool incrementKey()
    {
        if(key == Key.B5) { return false; }

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

        return true;
    }

    public bool decrementKey()
    {
        if (key == Key.C2) { return false; }

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
        if (!isInteractive) { return; }
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
            if(flatOrSharp != 1) { makeSharp(); }
        }
        else if(deltaX < -thresholdX)
        {
            if(flatOrSharp != -1) { makeFlat(); }
        }
        else
        {
            if (flatOrSharp != 0) { makeNeutral(); }
        }
    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {

    }

    public void OnPointerClicked(MixedRealityPointerEventData eventData){}
}
