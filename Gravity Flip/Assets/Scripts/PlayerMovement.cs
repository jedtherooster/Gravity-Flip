using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.5f;
    public LayerMask groundLayer;

    [Header("Game Objects")]
    public GameObject player;
    public static GameObject spotLight;
    public static GameObject innerLight;

    public static Rigidbody2D rb;
    public static bool isGrounded;
    public static bool isAlive = true;
    public bool canMove = true;

    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public GravityFlip gravityFlip;
    public GameManager gameManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spotLight = GameObject.Find("Spotlight");
        innerLight = GameObject.Find("Inner Glow");
        isAlive = true;
    }

    private void Update()
    {
        if (isAlive && canMove)
        {
            //Horizontal Movement
            float moveInput = Input.GetAxisRaw("Horizontal");
            rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

            if (moveInput != 0 && isGrounded)
            {
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }

            // Check for jump
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

            if (Input.GetKeyDown(KeyCode.W) && isGrounded || Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
            {
                
                if (rb.gravityScale > 0f)
                {
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                } else
                {
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, -jumpForce); ;
                }
            }

            if (!isGrounded)
            {
                animator.enabled = false; // Show jump sprite
            } else
            {
                animator.enabled = true; // Hide jump sprite
            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                spriteRenderer.flipX = false;
            }

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                spriteRenderer.flipX = true;
            }
        } else if (!isAlive)
        {
            spriteRenderer.enabled = false;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Kill")
        {
            gameManager.killPlayer(collision);
        }

        if (collision.tag == "Checkpoint")
        {
            GameManager.checkpoint(collision);
        }

        if (collision.tag == "Limit Gravity")
        {
            gravityFlip.resetGravity();
            gravityFlip.canFlip = false;
        }

        if (collision.tag == "Enable Gravity")
        {
            gravityFlip.canFlip = true;
        }

        if (collision.tag == "End Tutorial")
        {
            gameManager.loadNextLevel(2);   // Scene 2 = Main Game
        }

        if (collision.tag == "Credit")
        {
            gameManager.addCredits(1);
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Shop")
        {
            gameManager.loadShop();
        }
    }
}
