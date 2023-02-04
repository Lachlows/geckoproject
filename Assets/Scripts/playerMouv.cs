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


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        checkingWorld();
    }

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

    void Update()
    {
        playerMoove();
        checkButons();
        checkingWorld();
    }

    void playerMoove()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical);

        rb.velocity = movement * speed;
    }
    void checkingWorld()
    {
        if (SceneManager.GetActiveScene().name.StartsWith("r"))
        {
            rb.gravityScale = 1;
            if (onChangingWorld)
            {
                transform.position = new Vector3(transform.position.x, -3, transform.position.z);
                onChangingWorld = false;
            }
            else
            {
               rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            }
            canGoUp = false;
            Debug.Log("real world");
        }
        else if (SceneManager.GetActiveScene().name.StartsWith("s"))
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.gravityScale = 0;
            Debug.Log("spirit world");
            canGoUp = true;
        }
    }

    void checkButons ()
    {
        if (Input.GetButton("Interact")) {
            talkingToSpirit();
        }
        if (Input.GetButton("Climb"))
        {
            climbObstacle();
        }
        if (Input.GetButton("ChangingWorld"))
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
        Debug.Log("change world");
        if (SceneManager.GetActiveScene().name.StartsWith("s"))
        {
            SceneManager.LoadScene("rScene");
            Debug.Log("to real");
        }
        else if (SceneManager.GetActiveScene().name.StartsWith("r") && canChangingWorld)
        {
            SceneManager.LoadScene("sScene");
            Debug.Log("to spirit");
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
