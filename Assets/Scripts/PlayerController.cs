using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{
    public float velocity = 1f;
    public float jumpForce = 2f;
    public bool canWalk = true;
    public bool canJump = true;
    public bool hasMagnet;
    public Animator animator;

    [HideInInspector]
    public bool canReturnWalk;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public Transform setLever;
    public float interactionRadius;
    public LayerMask whatIsMagnet;

    // public Collider2D headCollider;
    // public Collider2D MagnetCollider;
    // public Collider2D bodyCollider;
    // public Collider2D wheelCollider;

    private Rigidbody2D rb;
    private bool isGrounded = true;
    private bool isBeingPulled = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // --- Walking ---
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if(isGrounded)
        {
            animator.SetBool("IsGrounded", true);
        }

        if (canWalk)
        {
            float hMove = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(hMove * velocity, rb.velocity.y);
        }

        // --- Jumping ---
        if (Input.GetKey(KeyCode.Space) && isGrounded && canJump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            animator.SetTrigger("Jump");
            animator.SetBool("IsGrounded", false);
        }

        // --- Interaction ---
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider2D col = Physics2D.OverlapCircle(setLever.position, interactionRadius);
            Interactable interactable = col?.gameObject.GetComponent<Interactable>();
            if (interactable != null)
            {
                StartCoroutine(ActivateInteractable(interactable));
                animator.SetTrigger("SetLever");
            }
        }

        // --- Magnet ---
        isBeingPulled = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsMagnet);

        if (isBeingPulled && hasMagnet)
        {
            canWalk = false;
            rb.velocity = new Vector2(0f, rb.velocity.y);
            rb.AddForce(Vector2.up, ForceMode2D.Impulse);
        } else {
            canWalk = true;
        }

        animator.SetFloat("Speed", rb.velocity.x);
    }

    private IEnumerator ActivateInteractable(Interactable interactable)
    {
        yield return new WaitForSeconds(0.3f);
        interactable.Interact();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Magnet" && hasMagnet)
        {
            animator.SetBool("IsBeingPulled", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Magnet" && hasMagnet)
        {
            animator.SetBool("IsBeingPulled", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Magnet" && hasMagnet)
        {
            animator.SetBool("IsCollidingWithMagnet", true);
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "Magnet" && hasMagnet)
        {
            animator.SetBool("IsCollidingWithMagnet", false);
        }
    }
    
    // private void OnTriggerStay2D(Collider2D other) {
    //     if (other.tag == "Magnet" && hasMagnet)
    //     {
    //         rb.AddForce(Vector2.up, ForceMode2D.Impulse);
    //     }
    // }
}
