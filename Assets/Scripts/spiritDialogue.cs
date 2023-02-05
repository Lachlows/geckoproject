using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class spiritDialogue : MonoBehaviour
{
    public string[] dialogue;

    public TextMeshProUGUI textElement;
    public GameObject textElementGo;

    public int textOrder = 0;

    bool textActive = false;
    bool canTalk = false;

    private void Update()
    {
        if (Input.GetButtonDown("Interact")&& canTalk)
        {
            if (textActive)
            {
                nextText();
            } else
            {
                textActive = true;
            }
        }
        if (textActive)
        {
            textElementGo.SetActive(true);
            printText();
        }
        else
        {
            textElementGo.SetActive(false);
        }
    }

    void printText ()
    {
        textElement.text = dialogue[textOrder];
    }

    public void nextText ()
    {
        textOrder += 1;
        Debug.Log("ordre des texte" + textOrder);
        if (textOrder>=dialogue.Length)
        {
            textActive = false;
            textOrder = 0;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision");
        canTalk = true;
    }
    private void OnTriggerExit(Collider other)
    {
        canTalk = false;
    }

}
