using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
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

            foreach (Transform octav in transform)
            {
                if (octav.tag == "O" + name[name.Length -1])
                {
                    foreach(Transform note in octav)
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
}
