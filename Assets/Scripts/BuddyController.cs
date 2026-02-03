using UnityEngine;

public class BuddyController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public float moveSpeed = 4;
    public float jumpForce = 10;
    
    private float inputX = 0;
    private float facing = 1;   //facing right =1, facing left = -1
    private bool isGrounded;    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();    
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");


        //Facing direction
        if (inputX > 0)
        {
            facing = 1;
        }
        else if (inputX < 0)
        {
            facing = -1;
        }

        if (facing >= 0.001f)
        {
            spriteRenderer.flipX = false;
        }
        else if (facing <= 0.001f)
        {
            spriteRenderer.flipX = true;
        }
        if( Input.GetButtonDown("Jump"))
        {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);    //Having a sudden force upward for the impulse 
        }
        //if (Input.GetKeyDown(KeyCode.Space)) { } //The same with above just coded differently
    }
    private void FixedUpdate()
    {
        rigidBody.linearVelocityX = inputX * moveSpeed;
        //rigidBody.linearVelocity = new Vector2(inputX * moveSpeed, rigidBody.linearVelocityY);
    }
}
