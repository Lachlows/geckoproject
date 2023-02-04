using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activingSpirit : MonoBehaviour
{
    public int index;
    private GameObject Go;


    private spiritActivator activatorScript;

    void Start()
    {
        Go = GetComponent<GameObject>();

        activatorScript = GetComponent<spiritActivator>();
    }
    private void Update()
    {
        if (activatorScript.checkSpiritActive(index))
        {
            Go.SetActive(true);

        }
        else
        {
            Go.SetActive(false);
        }
    }
}
