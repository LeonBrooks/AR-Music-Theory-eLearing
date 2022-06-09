using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum Color
{
    Black, White, Blue, Green, Red
};

public class KeyManager : MonoBehaviour
{
    public Material[] materials = new Material[5];
    private List<GameObject> nonDefaultKeys;
    private int surfaceOffset;
    public float normalOffset;

    // Start is called before the first frame update
    void Awake()
    {
        nonDefaultKeys = new List<GameObject>();
        surfaceOffset = 0;
        normalOffset = 0.02f;
    }

    public void changeColor(Color color, string key)
    {
        GameObject target = getKey(key);
        if (target != null)
        {
            nonDefaultKeys.Add(target);
            changeMaterial(materials[(int) color], target);
        }

    }

    public void resetKey(string key)
    {
        GameObject target = getKey(key);
        if (target != null)
        {
            nonDefaultKeys.Remove(target);
            if (target.GetComponent<KeyPressedHandler>().blackKey)
            {
                changeMaterial(materials[0], target);
            }
            else
            {
                changeMaterial(materials[1], target);
            }
        }
    }

    public void resetAllKeys()
    {
        foreach (GameObject target in nonDefaultKeys)
        {
            if (target.GetComponent<KeyPressedHandler>().blackKey)
            {
                changeMaterial(materials[0], target);
            } else
            {
                changeMaterial(materials[1], target);
            }

            target.GetComponentInChildren<TextMeshPro>().enabled = false;
        }

        nonDefaultKeys.Clear();
    }

    public void showNameplate(string keyName)
    {
        GameObject key = getKey(keyName);

        if(key != null)
        {
            key.GetComponentInChildren<TextMeshPro>().enabled = true;
            nonDefaultKeys.Add(key);
        }
    }

    public void hideNameplate(string keyName)
    {
        GameObject key = getKey(keyName);

        if (key != null)
        {
            key.GetComponentInChildren<TextMeshPro>().enabled = false;
        }
    }

    private GameObject getKey(string name)
    {
        if (!string.IsNullOrEmpty(name))
        {
            name = name.ToUpper();
            string target;
            if (name.Length == 2) { target = "" + name[0]; }
            else if (name.Length == 3) { target = "" + name[0] + name[1]; }
            else { Debug.Log("KeyManager.getKey: key not found");  return null; }

            foreach (Transform octave in transform)
            {
                if (octave.tag == "O" + name[name.Length -1])
                {
                    foreach(Transform note in octave)
                    {
                        if(note.gameObject.name == target)
                        {
                            return note.gameObject;
                        }
                    }
                }
            }
        }

        Debug.Log("KeyManager.getKey: key not found"); 
        return null;
    }

    private void changeMaterial(Material mat, GameObject key)
    {
        key.GetComponentInChildren<Renderer>().material = mat;
    }

    public void surfaceOffsetNeutral() 
    {
        if(surfaceOffset == 0) { return; }
        else if(surfaceOffset == 1)
        {
            surfaceOffset = 0;
            transform.position -= transform.up * normalOffset;
        } else if(surfaceOffset == -1)
        {
            surfaceOffset = 0;
            transform.position += transform.up * normalOffset;
        }
    }

    public void surfaceOffsetHigh()
    {
        if (surfaceOffset == 1) { return; }
        else if (surfaceOffset == 0)
        {
            surfaceOffset = 1;
            transform.position += transform.up * normalOffset;
        }
        else if (surfaceOffset == -1)
        {
            surfaceOffset = 1;
            transform.position += 2 * transform.up * normalOffset;
        }
    }

    public void surfaceOffsetLow()
    {
        if (surfaceOffset == -1) { return; }
        else if (surfaceOffset == 0)
        {
            surfaceOffset = -1;
            transform.position -= transform.up * normalOffset;
        }
        else if (surfaceOffset == 1)
        {
            surfaceOffset = -1;
            transform.position -= 2 *transform.up * normalOffset;
        }
    }
}
