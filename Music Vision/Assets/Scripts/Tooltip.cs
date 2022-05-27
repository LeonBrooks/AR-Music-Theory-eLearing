using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tooltip : MonoBehaviour
{
    private LineRenderer lineRenderer1;
    private LineRenderer lineRenderer2;
    [SerializeField]
    private GameObject secondAnchor;
    private float wOffset = 21.2f;
    private float hOffset = 8.5f;
    private float nOffset = 1f;
    bool isFlipped = false;

    void Awake()
    {
        lineRenderer1 = GetComponentInChildren<LineRenderer>();
        lineRenderer1.positionCount = 2;
        lineRenderer1.startWidth = 0.005f;
        lineRenderer1.endWidth = 0.005f;

        lineRenderer2 = GetComponentsInChildren<LineRenderer>()[1];
        lineRenderer2.positionCount = 2;
        lineRenderer2.startWidth = 0.005f;
        lineRenderer2.endWidth = 0.005f;
        lineRenderer2.enabled = false;

        /*Note n = transform.parent.GetComponent<Note>();
        if(n != null && n.isFlipped)
        {
            transform.localScale *= -1;
            transform.localPosition *= -1;
            isFlipped = true;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 parentPos = transform.InverseTransformPoint(transform.parent.position);
        Vector3 secondAnchorPos = Vector3.zero;
        if(lineRenderer2.enabled) 
        { 
            secondAnchorPos = transform.InverseTransformPoint(secondAnchor.transform.position);

            if (secondAnchorPos.x < transform.position.x)
            {
                if (secondAnchorPos.y < transform.position.y)
                {
                    lineRenderer2.SetPosition(0, transform.position + new Vector3(-wOffset, -hOffset, 0));
                    lineRenderer2.SetPosition(1, secondAnchorPos + new Vector3(nOffset, 0, 0));
                }
                else
                {
                    lineRenderer2.SetPosition(0, transform.position + new Vector3(-wOffset, hOffset, 0));
                    lineRenderer2.SetPosition(1, secondAnchorPos + new Vector3(nOffset, 0, 0));
                }
            }
            else
            {
                if (secondAnchorPos.y < transform.position.y)
                {
                    lineRenderer2.SetPosition(0, transform.position + new Vector3(wOffset, -hOffset, 0));
                    lineRenderer2.SetPosition(1, secondAnchorPos + new Vector3(nOffset, 0, 0));
                }
                else
                {
                    lineRenderer2.SetPosition(0, transform.position + new Vector3(wOffset, hOffset, 0));
                    lineRenderer2.SetPosition(1, secondAnchorPos + new Vector3(nOffset, 0, 0));
                }
            }
        }

        if (parentPos.x < transform.position.x)
        {
            if (parentPos.y < transform.position.y)
            {
                lineRenderer1.SetPosition(0, transform.position + new Vector3(-wOffset, -hOffset, 0));
                lineRenderer1.SetPosition(1, parentPos + new Vector3(nOffset, 0, 0));
            }
            else
            {
                lineRenderer1.SetPosition(0, transform.position + new Vector3(-wOffset, hOffset, 0));
                lineRenderer1.SetPosition(1, parentPos + new Vector3(nOffset, 0, 0));
            }
        }
        else
        {
            if (parentPos.y < transform.position.y)
            {
                lineRenderer1.SetPosition(0, transform.position + new Vector3(wOffset, -hOffset, 0));
                lineRenderer1.SetPosition(1, parentPos + new Vector3(nOffset, 0, 0));
            }
            else
            {
                lineRenderer1.SetPosition(0, transform.position + new Vector3(wOffset, hOffset, 0));
                lineRenderer1.SetPosition(1, parentPos + new Vector3(nOffset, 0, 0));
            }
        }

        Note n = transform.parent.gameObject.GetComponent<Note>();
        if (n != null && n.isFlipped != isFlipped)
        {
            transform.localScale *= -1;
            transform.localPosition *= -1;
            isFlipped = !isFlipped;
        }
    }

    public void activateSecondLine(GameObject secondAnchor)
    {
        if(secondAnchor == null) { return; }
        this.secondAnchor = secondAnchor;
        lineRenderer2.enabled = true;
        Update();
    }

    public void changeText(string text)
    {
        GetComponentInChildren<TextMeshPro>().text = text;
    }
}
