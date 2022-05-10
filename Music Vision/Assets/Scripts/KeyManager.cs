using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Color
{
    Black, White, Blue, Green, Red
};

public class KeyManager : MonoBehaviour
{
    public Material[] materials = new Material[5];
    private List<GameObject> nonDefaultKeys;
    private Vector3 baseScale;

    // Start is called before the first frame update
    void Start()
    {
        nonDefaultKeys = new List<GameObject>();
        baseScale = 2 * transform.localScale;
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

    public void resetColors()
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
        }

        nonDefaultKeys.Clear();
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

    public void setScale(SliderEventData d)
    {
        transform.localScale = new Vector3(baseScale.x * d.NewValue, baseScale.y * d.NewValue, baseScale.z * d.NewValue);
    }

    public void setYRotation(SliderEventData d)
    {
        transform.localRotation = Quaternion.Euler(0, 360f * d.NewValue, 0);
    }
}
