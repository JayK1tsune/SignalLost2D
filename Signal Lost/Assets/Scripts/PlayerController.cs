using UnityEngine;
using UnityEngine.InputSystem;
using SignalLost;

namespace SignalLost
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
{
    Vector2 moveInput;

    
    /// <summary>////
    /// Jumping delegates
     /// </summary>

    [SerializeField] int jumpPower;
    [SerializeField] float fallMultiplier;

    public Transform groundCheck;
    public LayerMask groundLayer;
    bool isGrounded;
    Vector2 VecGravity;
    ////

    public float walkSpeed = 5f;
    float velocity;
    Rigidbody2D rb;
    [SerializeField] Animator animator;
   
    public bool IsMoving { get; private set; }
    
   
    [SerializeField] colourDetect _colourDetect;
    [SerializeField] GameObject player;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        _colourDetect = player.GetComponent<colourDetect>();
        
        
    }

    void Update()
    {
        
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position,new Vector2(1f,0.14f),CapsuleDirection2D.Horizontal,0,groundLayer);

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * walkSpeed, rb.velocity.y);
        
        if(rb.velocity.y < 0 ){
            rb.velocity -= VecGravity * fallMultiplier * Time.deltaTime;
        }  
        
        
    }
    public void OnMove(InputAction.CallbackContext context){
        moveInput = context.ReadValue<Vector2>();

        IsMoving = moveInput != Vector2.zero;
        
    }

    public void OnSignal(InputAction.CallbackContext context){   
        //Debug.Log("Pressed E");
        _colourDetect.scriptEnabled = !_colourDetect.scriptEnabled;
    }
    public void OnJump(InputAction.CallbackContext context){


        if(isGrounded){
            rb.velocity = new Vector2(rb.velocity.x,jumpPower);
        }
   
    }
}
    
}

