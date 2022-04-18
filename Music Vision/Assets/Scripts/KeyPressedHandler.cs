using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPressedHandler : MonoBehaviour
{
    private Vector3 basePosition;
    private bool col;
    private float incrementUp = 0.008f;
    // Start is called before the first frame update
    void Start()
    {
        basePosition = transform.position;
        col = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!col && transform.position.y < basePosition.y) 
        {
            Vector3 targetPos = transform.position + Vector3.up * incrementUp;
            if (targetPos.y > basePosition.y) { targetPos.y = basePosition.y; }
            transform.position = targetPos;
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

        Debug.Log("sep: " + min);

        col = true;
        transform.position += Vector3.up * min;
    }

    private void OnCollisionExit(Collision collision)
    {
        col = false;
    }
}
