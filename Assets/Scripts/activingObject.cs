using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activingObject : MonoBehaviour
{
    public int index;
    bool canInteract = false;
    private GameObject Go;

    private spiritActivator activatorScript;

    void Start()
    {
        GameObject activatorGo = GameObject.FindWithTag("checkActive");
        Go = GetComponent<GameObject>();
        activatorScript = activatorGo.GetComponent<spiritActivator>();
    }
    private void Update()
    {
        if (activatorScript.checkObjectActive(index))
        {
            Go.SetActive(true);

        } else
        {
            Go.SetActive(false);
        }
        if (canInteract&& Input.GetButtonDown("Interact"))
        {
            activatorScript.toggleActive(index);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
    if(collision.CompareTag("player"))
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            canInteract = false;
        }
    }
}
