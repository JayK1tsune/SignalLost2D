using UnityEngine;
using UnityEngine.InputSystem;
using SignalLost;

namespace SignalLost
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
{
    Vector2 moveInput;
    
    bool IsJumping;
    public float jumpAmount = 10;
   
    public float fallingGravityScale = 3;
    public float jumpTime;
    public float jumpForce=20;
    public float gravity = -9.81f;
    public float gravityScale = 5;

    public float walkSpeed = 5f;
    float velocity;
    Rigidbody2D rb;
    [SerializeField] Animator animator;
    public GroundCheck groundCheck;
    public bool IsMoving { get; private set; }
    
   
    [SerializeField] colourDetect _colourDetect;
    [SerializeField] GameObject player;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        _colourDetect = player.GetComponent<colourDetect>();
        
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * walkSpeed, rb.velocity.y);
        if(rb.velocity.y >= 0)
        {
            rb.gravityScale = gravityScale;
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallingGravityScale;
        }
        velocity += gravity * gravityScale * Time.deltaTime;
        if (groundCheck.isGrounded && velocity < 0)
        {
            velocity = 0;
        }
        transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);
        
    }
    public void OnMove(InputAction.CallbackContext context){
        moveInput = context.ReadValue<Vector2>();

        IsMoving = moveInput != Vector2.zero;
        if (IsMoving)
        {
            
        }
    }
    public void OnSignal(InputAction.CallbackContext context){   
        //Debug.Log("Pressed E");
        _colourDetect.scriptEnabled = !_colourDetect.scriptEnabled;
        _colourDetect.lineRenderer.enabled = true;
    }
    public void OnJump(InputAction.CallbackContext context){
        
        IsJumping = true;
        jumpTime = 0;
        velocity = jumpForce;
        
        
    }
}
    
}

