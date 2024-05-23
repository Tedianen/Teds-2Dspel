using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    private float horizontal;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private float dirX;
/*    private bool IsWallSliding;
    private float WallSlidingSpeed = 2f;*/

    private enum MovementState {idle,running,jumping,falling,dubble_jumping/*,wall_jumping*/}
    private MovementState state = MovementState.idle;

    [SerializeField] private int jumpForce = 5;
    [SerializeField] private float movementSpeed = 5;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private int extraJumps = 1;
    [SerializeField] private int maxJumps = 1;
    /*[SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;*/
    
    private BoxCollider2D boxCol;

    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource dubbleJumpSoundEffect;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody2D>();

        boxCol = GetComponent<BoxCollider2D>();
        anim = GetComponent <Animator>();
        sprite = GetComponent <SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        /*horizontal = Input.GetAxisRaw("Horizontal");*/


        dirX = Input.GetAxisRaw("Horizontal");
        UpdateAnimationState();

        rb.velocity = new Vector2(dirX * movementSpeed, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && isGrounded()) {
            Jump();
        }
        else if(Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            extraJumps--;
            DoubleJump();
        }
        if (isGrounded())
        {
            extraJumps = maxJumps;
        }
       /* if (IsWalled())
        {
            extraJumps = maxJumps;
        }

        WallSlide();*/
        
    }

    private void Jump()
    {
        jumpSoundEffect.Play();
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    private void DoubleJump()
    {
        dubbleJumpSoundEffect.Play();
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    /*private bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }
    private void WallSlide()
    {
        Debug.Log(IsWalled());
        if (IsWalled() && !isGrounded() && horizontal != 0f)
        {
            IsWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -WallSlidingSpeed, float.MaxValue));
        }
        else 
        { 
            IsWallSliding = false; 
        }
    }
*/

    private void UpdateAnimationState()
    {
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f && extraJumps == 0)
        {
            state = MovementState.dubble_jumping;
        }

        else if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }

        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state",(int)state);

    }


    bool isGrounded(){
        return Physics2D.BoxCast(boxCol.bounds.center, boxCol.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);

    }
}