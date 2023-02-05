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
    bool canGoUp = false;

    bool spiritWorld = true;

    public Transform SpawnReal;
    public Transform SpawnSpirit;

    public float wallStickTime = 1.0f;
    public float wallStickForce = 10.0f;

    public float gravity;
    public float speedWall = 1f;

    private float timeStickingToWall;
    private bool isStickingToWall;

    private Animator animator;


    bool canClimb = false;

    bool falling = false;

    private SpriteRenderer spriteRenderer;

    bool reverseWall =false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        checkingWorld();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = true;
        animator = GetComponent<Animator>();
        animator.SetTrigger("onSpawn");


    }

    void Update()
    {
        playerMoove();
        checkButons();
        checkingWorld();
        climbObstacle();
        animator.SetBool("isReal", !spiritWorld);
    }

    void playerMoove()
    {
        float addSpeed = 1f;
        Vector2 movement = new Vector2(0f,0f);
        float vertical=0;
        float horizontal = Input.GetAxis("Horizontal");
        if (spiritWorld&&!isStickingToWall)
        {
            vertical = Input.GetAxis("Vertical");
        }
        if (!isStickingToWall)
        {
            movement = new Vector2(horizontal, vertical);

        }
        else
        {
            Debug.Log("ça doit monter bordel");
            if (!reverseWall)
            {
                movement = new Vector2(vertical, -horizontal);
                addSpeed = speedWall;
            }
            else
            {
                movement = new Vector2(vertical, horizontal);
                addSpeed = speedWall; 
            }
        }
        if (!reverseWall&&canClimb)
        {
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, -90.0f);

        }
        else if (reverseWall&&canClimb)
                {
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
        } else
        {
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

        }


        rb.velocity = movement * speed * addSpeed;
        if (horizontal > 0)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("onWalk",true);
        }
        else if (horizontal < 0)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("onWalk", true);
        }
        else if (horizontal==0 && vertical!=0){
            animator.SetBool("onWalk", true);
            Debug.Log("àa doit bouger");
        }
        else
        {
            animator.SetBool("onWalk", false);
        }

    }
    void checkingWorld()
    {
        if (!spiritWorld)
        {
            rb.gravityScale = gravity;

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
        if (Input.GetButton("Climb") && canClimb)
        {
            isStickingToWall = true;
            Debug.Log("climb");
        }
        else {
            isStickingToWall = false;
        }
    }
    void changingWorld ()
    {
        Debug.Log("je change de monde");
        if (!spiritWorld)
        {
            animator.SetTrigger("onSpawn");
            transform.position = new Vector3(transform.position.x, SpawnSpirit.position.y, transform.position.z);
            spiritWorld = true;
        }
        else
        {
            Debug.Log("je vais dans le monde des esprits");
            transform.position = new Vector3(transform.position.x, SpawnReal.position.y, transform.position.z);
            spiritWorld = false;
        }
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "WallRight" || collision.gameObject.tag == "WallLeft")
        {
            canClimb = true;
            if (collision.gameObject.tag == "WallRight")
            {
                reverseWall = false;
            } else
            {
                reverseWall = true;
            }
        } else
        {
            falling = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "WallRight" || collision.gameObject.tag == "WallLeft")
        {
            canClimb = false;
        }
    }
}
