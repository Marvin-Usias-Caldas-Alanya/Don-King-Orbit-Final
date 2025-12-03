using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float xInput;
    private bool isGrounded;
    private bool onLadder;
    private bool movementEnabled = true;
    private BarrelSpawner barrelSpawner;
    
    [SerializeField] private float walkSpeed = 5;
    [SerializeField] private float climbSpeed = 3;
    [SerializeField] private float jumpForce = 7;
    [SerializeField] private float drawLength = 2;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Collider2D[] platformColliders;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        barrelSpawner = FindFirstObjectByType<BarrelSpawner>();
    }

    void Start()
    {
        GameManager.Instance.score = 0;
        GameManager.Instance.lives = 3;
        GameManager.Instance.gameWon = false;
        UIManager.Instance.UpdateLivesUI();
        UIManager.Instance.UpdateScoreUI();
    }    
    
    void Update()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, drawLength, groundMask);
        xInput = Input.GetAxisRaw("Horizontal");

        PlayerFlip();
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    private void FixedUpdate()
    {
        if (isGrounded && movementEnabled)
            rb.linearVelocity = new Vector2(xInput * walkSpeed, rb.linearVelocity.y);
    }
    
    private void PlayerFlip()
    {
        if (xInput > 0)
        {
            transform.eulerAngles = Vector2.zero;
        }
        else if (xInput < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }
    
    private void PlayerDeath()
    {
        GameManager.Instance.LoseLife();
        if (GameManager.Instance.lives > 0)
            transform.position = new Vector3(-5, -6, 0);
    }

    private void OnDrawGizmos()
    {
        // draw line for isGrounded raycast
        Gizmos.DrawLine(transform.position, transform.position - new Vector3(0, drawLength));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "FinishLine")
            GameManager.Instance.ReachedFinishLine();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ladder")
        {
            if (Input.GetAxis("Vertical") != 0)
            {
                onLadder = true;
                rb.gravityScale = 0;

                if (Input.GetAxis("Vertical") > 0)
                {
                    rb.linearVelocity = new Vector2(0, climbSpeed);
                    foreach (Collider2D platform in platformColliders) 
                    {
                        if (platform != null)
                            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), platform, false);
                    }
                }
                
                else if (Input.GetAxis("Vertical") < 0)
                {
                    foreach (Collider2D platform in platformColliders) 
                    {
                        if (platform != null)
                            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), platform, true);
                    }
                    rb.linearVelocity = new Vector2(0, -climbSpeed);
                    print("going down");
                }
            }
            
            else if (onLadder)
            {
                rb.linearVelocity = new Vector2(0, 0);
                foreach (Collider2D platform in platformColliders) 
                {
                    if (platform != null)
                        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), platform, false);
                }
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ladder")
        {
            onLadder = false;
            rb.gravityScale = 1; 
            // make sure platform collision is enabled on exit
            foreach (Collider2D platform in platformColliders) 
            {
                if (platform != null)
                    Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), platform, false);
            }
        }

        if (other.gameObject.tag == "ScoreTrigger")
        {
            GameManager.Instance.AddScore(100);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Barrel")
        {
            PlayerDeath();
            barrelSpawner.DestroyBarrels();
        }
    }
}
