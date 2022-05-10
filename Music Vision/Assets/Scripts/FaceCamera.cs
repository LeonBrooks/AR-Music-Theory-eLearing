using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    public static Camera mainCam { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    private void LateUpdate()
    {
        transform.LookAt(mainCam.transform);
        transform.Rotate(new Vector3(0, 180, 0), Space.Self);
    }
}
