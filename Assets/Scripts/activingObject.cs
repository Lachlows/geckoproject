using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activingObject : MonoBehaviour
{
    bool canInteract = false;
    public GameObject Go;

    private void Update()
    {
        if (canInteract&& Input.GetButtonDown("Interact"))
        {
            Go.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("le trigger se fait bordel");
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
