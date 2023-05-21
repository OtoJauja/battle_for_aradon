using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float moveSpeed;
    public Rigidbody2D theRB;
    public float jumpForce;

    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    private Animator anim;
    private SpriteRenderer theSR;
    private BoxCollider2D boxCollider;

    public float knockBackLength, knockBackForce;
    private float knockBackCounter;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            boxCollider.enabled = true;
            anim.SetTrigger("Hit");
        }

        if (knockBackCounter <= 0)
        {
            
            theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);

            isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);

            if (Input.GetButtonDown("Jump"))
            {
                if(isGrounded)
                {
                    theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                }
            }

            if (theRB.velocity.x < 0)
            {
                theSR.flipX = true;
            }else if(theRB.velocity.x > 0)
            {
                theSR.flipX = false;
            }
        }else
        {
            knockBackCounter -= Time.deltaTime;
            if (!theSR.flipX)
            {
                theRB.velocity = new Vector2(-knockBackForce,  theRB.velocity.y);
            }else
            {
                theRB.velocity = new Vector2(knockBackForce,  theRB.velocity.y);
            }
        }

        anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
    }

    public void knockBack()
    {
        knockBackCounter = knockBackLength;
        theRB.velocity = new Vector2(0f, knockBackForce);

        anim.SetTrigger("hit");
    }
}
