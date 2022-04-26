using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private List<GameObject> ledgerLines;
    public string type;
    public bool isFlipped;

    // Start is called before the first frame update
    void Awake()
    {
        ledgerLines = new List<GameObject>();
        isFlipped = false;
}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void makeSharp()
    {
        gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void makeFlat()
    {
        gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void makeNeutral()
    {
        gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void addLedgerLine(GameObject ledgerLine)
    {
        ledgerLines.Add(ledgerLine);
    }

    public void flip()
    {
        isFlipped = !isFlipped;
        SpriteRenderer r = gameObject.GetComponent<SpriteRenderer>();
        r.flipX = !r.flipX;
        r.flipY = !r.flipY;
    }

    public void changeColor(Color color)
    {
        Sprite note = Resources.Load<Sprite>(type + "_" + color.ToString());
        Sprite flat = Resources.Load<Sprite>("flat" + "_" + color.ToString());
        Sprite sharp = Resources.Load<Sprite>("sharp" + "_" + color.ToString());

        if(note == null || flat == null || sharp == null)
        {
            Debug.Log("Note: Sprites for the color " + color.ToString() + "not found");
        }

        gameObject.GetComponent<SpriteRenderer>().sprite = note;
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = flat;
        gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = sharp;
    }

    private void OnDestroy()
    {
        foreach (GameObject ledgerLine in ledgerLines)
        {
            Destroy(ledgerLine);
        }
    }
}
