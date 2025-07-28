using UnityEngine;

public class GravityFlip : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool canFlip = false;
    private bool hasFlip;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canFlip)
        {
            if (Input.GetKeyDown(KeyCode.Space) && hasFlip && PlayerMovement.isAlive)
            {
                flipGravity();
                hasFlip = false;
            }
        }

        if (PlayerMovement.isGrounded)
        {
            hasFlip = true;
        }
    }

    public void flipGravity()
    {
        rb.gravityScale *= -1;

        Vector3 scale = transform.localScale;
        scale.y *= -1;
        transform.localScale = scale;
    }

    public void resetGravity()
    {
        rb.gravityScale = 2.5f;
        
        Vector3 scale = transform.localScale;
        scale.y *= -1;
        transform.localScale = scale;
    }
}
