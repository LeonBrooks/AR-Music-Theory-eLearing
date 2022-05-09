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
    //private AudioSource locationFoundSound;

    private float delayMoment;
    private float initTime;
    private Vector3? foundPosition = null;
    private Vector3 previousPosition = Vector3.positiveInfinity;
    private Vector3 basePos;
    private SolverHandler solverHandler;
    private bool initialized;
    private bool locked;

    private void Awake()
    {
        surfaceMagnet = GetComponent<SurfaceMagnetism>();
        solverHandler = surfaceMagnet.GetComponent<SolverHandler>();
        surfaceMagnet.enabled = false;
        initTime = Time.time + 2;
        initialized = false;
        locked = false;
        basePos = transform.position;
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
        previousPosition = Vector3.positiveInfinity;
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
        if (Time.time > initTime && !initialized)
        {
            transform.position = basePos;
            surfaceMagnet.enabled = true;
            delayMoment = Time.time + 2;
            initialized = true;
        }

        if (foundPosition == null && Time.time > delayMoment)
        {
            Debug.Log("surfaceFinder: " + surfaceMagnet.OnSurface.ToString());
            if (surfaceMagnet.OnSurface)
            {
                foundPosition = surfaceMagnet.transform.position;
            }

            if (foundPosition != null)
            {
                previousPosition = foundPosition.Value;
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
