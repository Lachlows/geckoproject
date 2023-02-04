using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiritActivator : MonoBehaviour
{

    public bool[] objectsState;
    public bool[] spitirtsState;

    bool created = false;

    private void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public bool checkObjectActive(int index)
    {
        Debug.Log("ça check les états des objets");
        if (objectsState[index])
        {
            return true;
        }
        return false;
    }

    public bool checkSpiritActive(int index)
    {
        Debug.Log("ça check les états des esprits");
        if (objectsState[index])
        {
            return true;
        }
        return false;
    }

    public void toggleActive (int index)
    {
        Debug.Log("ça toggle les etats");
        objectsState[index] = false;
        spitirtsState[index] = true;
    }
}