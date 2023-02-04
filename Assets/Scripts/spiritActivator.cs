using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiritActivator : MonoBehaviour
{

    public GameObject[] objects;
    public GameObject[] spirits;


    private void Update()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if (!objects[i].activeInHierarchy)
            {
                spirits[i].SetActive(true);
            }
        }
    }
}