using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPressTest : MonoBehaviour
{
    Rigidbody b;

    // Start is called before the first frame update
    void Start()
    {
        b = gameObject.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log("localPos: " + transform.localPosition + "\ninversePos: " + transform.InverseTransformPoint(transform.position));
    }
}
