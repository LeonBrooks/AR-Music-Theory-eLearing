using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyPressedHandler : MonoBehaviour
{
    private Vector3 basePos;
    private Vector3 minPosVec;
    private Vector3 activationPosVec;
    public bool blackKey;
    private bool col;
    public bool isActive;
    private float incrementUp;
    private float incrementDown;
    private float minPos;
    private float activationPos;
    private string keyID;
    // Start is called before the first frame update
    void Start()
    {
        basePos = transform.localPosition;
        col = false;
        isActive = false;
        incrementUp = 0.2f;
        incrementDown = 15f;

        if (gameObject.tag == "BlackKey")
        {
            blackKey = true;
            minPos = -1f;
            activationPos = -0.5f;
        }
        else
        {
            blackKey = false;
            minPos = -1.3f;
            activationPos = -0.8f;
        }
        minPosVec = transform.localPosition + Vector3.up * minPos;
        activationPosVec = transform.localPosition + Vector3.up * activationPos;

        keyID = gameObject.name + transform.parent.gameObject.tag[1];

        GetComponentInChildren<TextMeshPro>().text = gameObject.name;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!col && transform.localPosition.y < basePos.y) 
        {
            Vector3 targetPos = transform.localPosition + Vector3.up * incrementUp;
            if (targetPos.y > basePos.y) { targetPos.y = basePos.y; }
            transform.localPosition = targetPos;
        }

        if (!isActive && transform.localPosition.y < activationPosVec.y)
        {
            isActive =  true;
            MusicController.instance.keyPressed(keyID);
        } else if(isActive && transform.localPosition.y >= activationPosVec.y)
        {
            isActive = false;
            MusicController.instance.keyReleased(keyID);
        }
    }


    private void OnCollisionStay(Collision collision)
    {
        ContactPoint[] cont = new ContactPoint[collision.contactCount];
        collision.GetContacts(cont);

        float min = 200;
        foreach (ContactPoint p in cont) 
        {
            if(p.separation < min) { min = p.separation; }
        }

        col = true;

        Vector3 targetPos = transform.localPosition + Vector3.up * min * incrementDown;
        if (targetPos.y < minPosVec.y)
        {
            targetPos = minPosVec;
        }
        else if (targetPos.y > basePos.y)
        {
            targetPos = basePos;
        }
        transform.localPosition = targetPos;

    }

    private void OnCollisionExit(Collision collision)
    {
        col = false;
    }
}
