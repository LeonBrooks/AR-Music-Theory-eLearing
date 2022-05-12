using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class InteractionHandler : MonoBehaviour
{
    private Vector3 baseScale;
    void Awake()
    {
        baseScale = 2 * transform.localScale;
    }

    public void setScale(SliderEventData d)
    {
        transform.localScale = new Vector3(baseScale.x * d.NewValue, baseScale.y * d.NewValue, baseScale.z * d.NewValue);
    }

    public void setYRotation(SliderEventData d)
    {
        transform.localRotation = Quaternion.Euler(0, 360f * d.NewValue, 0);
    }

    public void toggleIsActive()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
