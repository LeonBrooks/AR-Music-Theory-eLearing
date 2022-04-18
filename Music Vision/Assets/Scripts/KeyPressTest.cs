using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPressTest : MonoBehaviour
{
    Rigidbody b;
    public int m;
    public int i;
    // Start is called before the first frame update
    void Start()
    {
        b = gameObject.GetComponent<Rigidbody>();
        m = 100;
        i = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for(; i>0; i--)
        {
            b.AddForceAtPosition(Vector3.down * m, gameObject.transform.TransformPoint(new Vector3(0, 1, 7.5f)), ForceMode.Impulse);
            Debug.Log("y" + i);
        }
    }
}
