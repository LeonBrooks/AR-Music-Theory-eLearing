using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using UnityEngine;
using UnityEngine.Events;


//adapted version of: https://localjoost.github.io/Placing-holograms-on-any-surface-using-the-MRTK-surface-magnetism/
public class SurfaceFinder : MonoBehaviour
{
    private SurfaceMagnetism surfaceMagnet;
    [SerializeField]
    private GameObject lookPrompt;
    [SerializeField]
    private GameObject confirmPrompt;
    [SerializeField]
    private Vector3 rotationOffset = new Vector3(-90,0,0);
    //private AudioSource locationFoundSound;

    private float delayMoment;
    private float initTime;
    private Vector3? foundPosition = null;
    private SolverHandler solverHandler;
    private RadialView radialView;
    private bool locked;

    private void Awake()
    {
        surfaceMagnet = GetComponent<SurfaceMagnetism>();
        solverHandler = surfaceMagnet.GetComponent<SolverHandler>();
        radialView = surfaceMagnet.GetComponent<RadialView>();
        initTime = Time.time + 2;
        locked = false;
    }

    private void Start()
    {
        surfaceMagnet.enabled = false;
        radialView.enabled = true;
    }

    private void OnEnable()
    {
        Reset();
    }

    private void Update()
    {
        CheckLocationOnSurface();
    }

    public void Reset()
    {
        delayMoment = Time.time + 0.5f;
        foundPosition = null;
        lookPrompt.SetActive(true);
        confirmPrompt.SetActive(false);
        solverHandler.enabled = true;
        locked = false;
    }

    public void Accept()
    {
        if (foundPosition != null)
        {
            lookPrompt.SetActive(false);
            confirmPrompt.SetActive(false);
        }
    }

    private void CheckLocationOnSurface()
    {
        if (Time.time > initTime && radialView.enabled)
        {
            radialView.enabled = false;
            transform.GetChild(0).Rotate(rotationOffset);
            surfaceMagnet.enabled = true;
            delayMoment = Time.time + 2;
        }

        if (foundPosition == null && Time.time > delayMoment)
        {
            if (surfaceMagnet.OnSurface)
            {
                foundPosition = surfaceMagnet.transform.position;
            }

            if (foundPosition != null)
            {
                if (locked)
                {
                    solverHandler.enabled = false;
                    lookPrompt.SetActive(false);
                    confirmPrompt.SetActive(true);
                    //locationFoundSound.Play();
                }
                else
                {
                    foundPosition = null;
                }
            }
        }
    }

    public void lockPosition ()
    {
        locked = true;
    }
}
