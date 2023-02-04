using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMouv : MonoBehaviour
{
    public float speed = 10.0f;

    private Rigidbody2D rb;

    private static bool created = false;

    bool canChangingWorld = false;
    bool onChangingWorld = false;
    bool canGoUp = false;

    bool spiritWorld = false;

    public Transform SpawnReal;
    public Transform SpawnSpirit;

    public float wallStickTime = 1.0f;
    public float wallStickForce = 10.0f;

    private float timeStickingToWall;
    private bool isStickingToWall;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        checkingWorld();
    }

    void Update()
    {
        //transform.eulerAngles = new Vector3(0, 0, 0);
        playerMoove();
        checkButons();
        checkingWorld();
    }

    void playerMoove()
    {
        float vertical=0;
        float horizontal = Input.GetAxis("Horizontal");
        if (spiritWorld)
        {
            vertical = Input.GetAxis("Vertical");
        }

        Vector2 movement = new Vector2(horizontal, vertical);

        rb.velocity = movement * speed;
    }
    void checkingWorld()
    {
        if (!spiritWorld)
        {
            rb.gravityScale = 1;

            canGoUp = false;
            Debug.Log("real world");
        }
        else
        {
            rb.gravityScale = 0;
            Debug.Log("spirit world");
            canGoUp = true;
        }
    }

    void checkButons ()
    {
        if (Input.GetButtonDown("Interact")) {
            talkingToSpirit();
        }
        if (Input.GetButton("Climb"))
        {
            climbObstacle();
        }
        if (Input.GetButtonDown("ChangingWorld"))
        {
            changingWorld();
        }
    }

    void talkingToSpirit ()
    {
        Debug.Log("talk");
    }

    void climbObstacle ()
    {
        Debug.Log("climb");
    }

    void changingWorld ()
    {
        if (!spiritWorld)
        {
            transform.position = new Vector3(transform.position.x, SpawnSpirit.position.y, transform.position.z);
            spiritWorld = true;
        } else
        {
            transform.position = new Vector3(transform.position.x, SpawnReal.position.y, transform.position.z);
            spiritWorld = false;
        }
        onChangingWorld = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ChangingArea")
        {
            canChangingWorld = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ChangingArea")
        {
            canChangingWorld = false;
        }
    }
}
