using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [SerializeField]
    GameObject pauseMenu;

    private Rigidbody2D rb;
    private bool isGrounded = true;
    private bool isBeingPulled = false;

    private int playerID;
    
    PlayerControls controls;

    private bool jumped = false;
    private bool interacted = false;

    private void Awake() {
        controls = new PlayerControls();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        controls.Gameplay.Jump.performed += ctx => jumped = true;
        controls.Gameplay.Interact.performed += ctx => interacted = true;
        controls.Gameplay.Pause.performed += ctx => Pause();
    }

    private void OnEnable() 
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Pause()
    {
        if (Time.timeScale == 0f)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    void FixedUpdate()
    {   
        float hMove = 0f;
        // --- Walking ---
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if(isGrounded)
        {
            animator.SetBool("IsGrounded", true);
        }

        if (canWalk)
        {
            float analog = controls.Gameplay.Move.ReadValue<Vector2>().x;
            float digital = controls.Gameplay.DiscreteRight.ReadValue<float>() -  controls.Gameplay.DiscreteLeft.ReadValue<float>();
            hMove = Mathf.Abs(analog) > Mathf.Abs(digital) ? analog : digital;
            rb.velocity = new Vector2(hMove * velocity, rb.velocity.y);
        }

        // --- Jumping ---
        if (jumped && isGrounded && canJump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            animator.SetTrigger("Jump");
            animator.SetBool("IsGrounded", false);
        }

        // --- Interaction ---
        if (interacted)
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

        jumped = false;
        interacted = false;
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
}
