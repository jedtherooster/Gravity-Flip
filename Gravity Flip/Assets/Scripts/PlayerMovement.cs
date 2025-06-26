using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isAlive;

    public SpriteRenderer spriteRenderer;
    //public CameraFollow cameraFollow;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isAlive = true;
    }

    private void Update()
    {
        if (isAlive)
        {
            //Horizontal Movement
            float moveInput = Input.GetAxisRaw("Horizontal");
            rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

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

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                spriteRenderer.flipX = true;
            }

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                spriteRenderer.flipX = false;
            }
        } else
        {
            spriteRenderer.enabled = false;
        }
    }

    private void untrackCamera()
    {
        //cameraFollow.tracking = false;

        Debug.Log("Camera Not Tracking");
    }
}
