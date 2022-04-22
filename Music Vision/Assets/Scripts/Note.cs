using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
}
