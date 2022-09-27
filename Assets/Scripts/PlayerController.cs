using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public PlayerAction inputAction;
    Vector2 move;
    Vector3 rotate;
    private float walkSpeed = 5f;
    private float rotateSpeed = 30f;
    public float jump = 5f;


    //Jump
    Rigidbody rb;
    private float distanceToGround;
    private bool isGrounded = true;

    public Camera playerCamera;
    Vector3 cameraRotation;

    //Player animation
    Animator playerAnimator;
    private bool isWalking = false;


    //projectile
   public GameObject bullet;
   public Transform projectilePos;

    private void OnEnable()
    {
        inputAction = new PlayerAction();

        inputAction.Enable();

    }

    private void OnDisable()
    {
        inputAction.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();

        if(!instance)
        {
            instance = this;
        }

        inputAction.Player.Move.performed += cntxt => move = cntxt.ReadValue<Vector2>();
        inputAction.Player.Move.canceled += cntxt => move = Vector2.zero;

        inputAction.Player.Jump.performed += cntxt => Jump();
        inputAction.Player.Shoot.performed += cntxt => Shoot();

        inputAction.Player.Look.performed += cntxt => rotate = cntxt.ReadValue<Vector2>();
        inputAction.Player.Look.canceled += cntxt => rotate = Vector2.zero;

        distanceToGround = GetComponent<Collider>().bounds.extents.y;

    }


    private void Jump()
    {
        if(isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            isGrounded = false; 
        }

    }
    
    private void Shoot()
    {
        Rigidbody bulletRb = Instantiate(bullet, projectilePos.position, Quaternion.identity).GetComponent<Rigidbody>();
        bulletRb.AddForce(transform.forward * 32f, ForceMode.Impulse);
        bulletRb.AddForce(transform.up * 5f, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * move.y * Time.deltaTime * walkSpeed, Space.Self);
        transform.Translate(Vector3.right * move.x * Time.deltaTime * walkSpeed, Space.Self);

        transform.Rotate( new Vector3(0, 1, 0), rotate.x * Time.deltaTime * rotateSpeed);
       

        isGrounded = Physics.Raycast(transform.position, -Vector3.up, distanceToGround);
    }
}
