
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public Animator animator;

    public float MS = 1f;     //můžeme nastavit rychlost pohybu v editoru
    public float Jump = 1f;     //můžeme nastavit výšku skoku v editoru
    public bool boolJump = false;

    private Rigidbody2D rigidbody;   //rigidbody hráče pro skok
    private SpriteRenderer sprite; //získání sprite rendereru, abychom mohli flipovat sprite postavy
    private bool FlipWayRight = true; //jestli se hráč dívá do prava (pro flip postavy)

    public float LadderSpeed = 1; //rychlost lezení po žebříku
    public float distance;
    public LayerMask WhatIsLadder; 
    private bool isClimbing;

    PlaySound playSound;    //pro hraní zvuku

    public GameObject hat;

    void Start()
    {
        PlayerPrefs.SetInt("Win", 0);
        rigidbody = GetComponent<Rigidbody2D>();  //najdeme rigidbody hráče
        sprite = GetComponent<SpriteRenderer>();  //najdeme SpriteRenderer hráče

        playSound  = GameObject.Find("AudioManager").GetComponent<PlaySound>();  //pro hraní zvuků
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("Health", 0) != 0 && PlayerPrefs.GetInt("Win", 0) == 0)
        {
            jump();  // metoda pro skok
            ladderMovement(); //metoda pro lezení žebříku
        }
    }


    void FixedUpdate()
    {
        if (PlayerPrefs.GetInt("Health", 0) != 0 && PlayerPrefs.GetInt("Win", 0) == 0)
        {
            movement();    // metoda pro pohyb
        }
    }


    void movement() // metoda pro pohyb
    {
        var movement = Input.GetAxis("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(movement));

        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MS;
        // Debug.Log(movement);
        if (movement * Time.deltaTime > 0 && !FlipWayRight)    //podmínka jestli se hráč dívá do leva a chceme ho otočit do prava
        {
            flip();
        }
        else if (movement * Time.deltaTime < 0 && FlipWayRight) //podmínka jestli se hráč dívá do prava a chceme ho otočit do leva
        {
            flip();
        }

        if (!boolJump && rigidbody.velocity.y < 0.01 && rigidbody.velocity.y > -0.01)
        {
            animator.SetBool("Jump", true);
        }
    }

    void jump()  // metoda pro skok
    {
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rigidbody.velocity.y) < 0.001f)
        {
            Vector2 vector = new Vector2(0, Jump);    // využití námi nastavené hodnoty(jak moc má skočit)
            rigidbody.AddForce(vector, ForceMode2D.Impulse);  //skok v impulsu
            animator.SetBool("Jump", true);

            playSound.Play(8);  //přehrání zvuku
        } 
        else if (!boolJump && rigidbody.velocity.y < 0.01 && rigidbody.velocity.y > -0.01)
        {
             animator.SetBool("Jump", false);
        }           
    }

    void flip()  // metoda pro otočení postavy na druhou stranu
    {
        FlipWayRight = !FlipWayRight;  //změnění orientace(kam se dívá)

        sprite.flipX = !FlipWayRight; //flipnutí spritu ve sprite rendereru

        hat.GetComponent<SpriteRenderer>().flipX = !FlipWayRight;
    }


    //metoda pro lezení žebříku
    //využívá se reycastu který se dívá jestli nekoliduje s vrstvou(layer) jménem ladder (= žebřík)
    //reycast se dívá nahoru nad hráčem
    private void ladderMovement()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, Vector2.up, distance, WhatIsLadder);

        if (hitinfo.collider != null)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                isClimbing = true;
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                isClimbing = false;

                animator.SetBool("Jump", true);
            }
        }

        if (isClimbing == true && hitinfo.collider != null)         //pokud se může lézt po žebříku, tak se vypne gravitace, jakmile nemůžu, tak se zpátky zapne
        {
            rigidbody.gravityScale = 0;
            float inputVertical = Input.GetAxisRaw("Vertical");
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, inputVertical * MS);
        }
        else
        {
            rigidbody.gravityScale = 1.5f; 
        }

        if (!boolJump && rigidbody.velocity.y < 0.01 && rigidbody.velocity.y > -0.01)
        {
            animator.SetBool("Jump", false);
        }
    }
}
