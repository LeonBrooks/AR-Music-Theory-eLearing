using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    LineRenderer lineRenderer;
    private float wOffset = 21.2f;
    private float hOffset = 8.5f;
    private float nOffset = 1f;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.005f;
        lineRenderer.endWidth = 0.005f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 parentPos = transform.InverseTransformPoint(transform.parent.position);

        if (parentPos.x < transform.position.x)
        {
            if (parentPos.y < transform.position.y)
            {
                lineRenderer.SetPosition(0, transform.position + new Vector3(-wOffset, -hOffset, 0));
                lineRenderer.SetPosition(1, parentPos + new Vector3(nOffset, 0, 0));
            }
            else
            {
                lineRenderer.SetPosition(0, transform.position + new Vector3(-wOffset, +hOffset, 0));
                lineRenderer.SetPosition(1, parentPos + new Vector3(nOffset, 0, 0));
            }
        }
        else
        {
            if (parentPos.y < transform.position.y)
            {
                lineRenderer.SetPosition(0, transform.position + new Vector3(+wOffset, -hOffset, 0));
                lineRenderer.SetPosition(1, parentPos + new Vector3(nOffset, 0, 0));
            }
            else
            {
                lineRenderer.SetPosition(0, transform.position + new Vector3(+wOffset, +hOffset, 0));
                lineRenderer.SetPosition(1, parentPos + new Vector3(nOffset, 0, 0));
            }


        }
    }
}
