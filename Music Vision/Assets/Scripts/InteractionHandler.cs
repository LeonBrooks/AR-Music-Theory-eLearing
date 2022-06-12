using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class InteractionHandler : MonoBehaviour
{
    private Vector3 baseScale;
    private static bool quitDiaologOpen;
    private static GameObject dialogPrefab;
    void Awake()
    {
        baseScale = 2 * transform.localScale;
        quitDiaologOpen = false;
        dialogPrefab = Resources.Load("DialogPrefab") as GameObject;
    }

    public void setScale(SliderEventData d)
    {
        transform.localScale = new Vector3(baseScale.x * d.NewValue, baseScale.y * d.NewValue, baseScale.z * d.NewValue);
    }

    public void setScaleWithMin(SliderEventData d)
    {
        Vector3 minScale = baseScale / 2;
        transform.localScale = new Vector3(minScale.x + minScale.x * d.NewValue, minScale.y + minScale.y * d.NewValue, minScale.z + minScale.z * d.NewValue);
    }

    public void setYRotation(SliderEventData d)
    {
        transform.localRotation = Quaternion.Euler(0, 360f * d.NewValue, 0);
    }

    public void toggleIsActive()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public static void quitApp()
    {
        if (quitDiaologOpen) { return; }
        Dialog dialog = Dialog.Open(dialogPrefab, DialogButtonType.Yes | DialogButtonType.No,
                                    "Quit Music Vision", "Are you sure you want to quit the application?", true);
        if (dialog != null)
        {
            quitDiaologOpen = true;
            dialog.OnClosed += (DialogResult res) => {
                if (res.Result == DialogButtonType.Yes) { Application.Quit(); }
                quitDiaologOpen = false;
            };
        }
    }
}
