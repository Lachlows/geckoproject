using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endScene : MonoBehaviour
{
    public Button replayButton;

    // Start is called before the first frame update
    void Start()
    {
        replayButton.Select();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Replay()
    {
        SceneManager.LoadScene("startScene");
    }
}
