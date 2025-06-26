using UnityEngine;

public class GravityFlip : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && PlayerMovement.isGrounded && PlayerMovement.isAlive)
        {
            flipGravity();
        }
    }

    void flipGravity()
    {
        rb.gravityScale *= -1;

        Vector3 scale = transform.localScale;
        scale.y *= -1;
        transform.localScale = scale;
    }
}
