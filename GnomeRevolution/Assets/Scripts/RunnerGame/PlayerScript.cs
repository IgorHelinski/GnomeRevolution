using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    [SerializeField] private float jumpForce;
    [SerializeField] private float groundCheckLength;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb2D;
    [SerializeField] private bool isGrounded = false;
    private RaycastHit2D hit2D;

    private void Awake()
    {
        if(rb2D == null)
        {
            rb2D = GetComponent<Rigidbody2D>();
        }
    }

    private void Update()
    {
        isGrounded = CheckGround();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(isGrounded == true)
            {
                Jump();
            }
        }
    }

    private void Jump()
    {
        Debug.Log("Jumping, yayy");
        rb2D.AddForce(Vector2.up * jumpForce * Time.deltaTime);
        isGrounded = false;
    }

    private bool CheckGround()
    {
        if(Physics2D.Raycast(transform.position, Vector2.down, groundCheckLength, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
