using UnityEngine;
using Luminara.SoundManager;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float moveSpeed = 8f;
    private float jumpingPower = 16f;
    private bool isGrounded = false;
    private bool isFacingRight = true;

    private float footstepTimer = 0f;
    private float footstepInterval = 0.3f;

    [SerializeField] private Rigidbody2D rb;
    private Animator animator;

    private AudioSource footstepSource;
    private bool isWalkingSoundPlaying = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        footstepSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
            isGrounded = false;
            animator.SetBool("IsJumping", !isGrounded);
        }

        if (Input.GetButtonDown("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, verticalInput * 0.5f);
        }
        animator.SetFloat("xVelocity", Mathf.Abs(rb.linearVelocity.x));
        animator.SetFloat("yVelocity", Mathf.Abs(rb.linearVelocity.y));

        Flip();
        HandleFootsteps();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, verticalInput * moveSpeed);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        isGrounded = true;
        animator.SetBool("IsJumping", !isGrounded);
    }

    private void Flip()
    {
        if (isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

private void HandleFootsteps()
{
    bool isMoving = Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f;

    if (isMoving && isGrounded)
    {
        footstepTimer -= Time.deltaTime;

        if (footstepTimer <= 0f)
        {
            SoundList stepSound = SoundManager.GetSound(SoundType.Steps);

            footstepSource.PlayOneShot(stepSound.sounds[Random.Range(0, stepSound.sounds.Length)], stepSound.volume);
            footstepTimer = footstepInterval;
        }
    }
    else
    {
        footstepTimer = 0f;
    }
}
}