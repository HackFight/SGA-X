using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    //Inputs
    InputAction moveAction;
    InputAction jumpAction;
    InputAction lookAction;
    InputAction deltaAction;
    InputAction pointAction;
    InputAction fireAction;
    bool hasReleased;
    bool isMouse = true;
    float detectThreshold = 0.01f;
    Vector2 look;

    //Camera
    Camera mainCamera;

    //Movement
    Rigidbody2D rb;
    [SerializeField] float speed;
    bool airborne;
    bool isGrounded;
    bool endedJumpEarly;
    [SerializeField] float jumpSpeed;
    [SerializeField] float fallSpeed;
    [SerializeField] float maxFallSpeed;
    [SerializeField] float jumpEndEarlyModifier;
    [SerializeField] float coyoteTime;
    [SerializeField] float jumpBufferTime;
    float timeLeftGround;
    bool justGrounded;
    float timeSinceLastJumpRequest = -10.0f;
    [SerializeField] LayerMask groundRaycastLayerMask;
    [SerializeField] float groundRaycastDistance;
    Vector2 startPos;

    //Grab
    [SerializeField] GameObject grab;
    GrabScript grabScript;
    Rigidbody2D grabRb;
    [SerializeField] float grabSpeed;
    [Range(0.0f, 10.0f), SerializeField] float maxGrabDistance;
    [Range(0.0f, 10.0f), SerializeField] float minGrabDistance;

    //Animations
    public bool cutscene;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        lookAction = InputSystem.actions.FindAction("LookJoystick");
        deltaAction = InputSystem.actions.FindAction("LookMouse");
        pointAction = InputSystem.actions.FindAction("Point");
        fireAction = InputSystem.actions.FindAction("Attack");

        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;

        grabScript = grab.GetComponent<GrabScript>();
        grabRb = grab.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ProcessInput();
    }

    private void FixedUpdate()
    {
        if (cutscene)
        {
            grab.SetActive(false);
            return;
        }
        else
        {
            grab.SetActive(true);
        }
        //Check
        if (Physics2D.Raycast(transform.position, -Vector2.up, groundRaycastDistance, groundRaycastLayerMask) && rb.linearVelocityY <= 0 && !isGrounded)
        {
            isGrounded = true;
            justGrounded = true;
        }
        else isGrounded = Physics2D.Raycast(transform.position, -Vector2.up, groundRaycastDistance, groundRaycastLayerMask);
        if (!isGrounded && !airborne)
        {
            airborne = true;
            timeLeftGround = Time.time;
        }
        else if (isGrounded)
        {
            airborne = false;
        }
        if (!justGrounded && hasReleased) timeSinceLastJumpRequest = -10.0f;
        
        //Move
        rb.linearVelocityX = moveAction.ReadValue<Vector2>().x * speed;

        if ((jumpAction.IsPressed() || timeSinceLastJumpRequest + jumpBufferTime >= Time.time) && (isGrounded || timeLeftGround + coyoteTime >= Time.time) && hasReleased)
        {
            isGrounded = false; hasReleased = false;
            rb.linearVelocityY = jumpSpeed;
        }

        endedJumpEarly = !jumpAction.IsPressed() && rb.linearVelocityY > 0;
        float finalFallSpeed = endedJumpEarly && rb.linearVelocityY > 0 ? fallSpeed * jumpEndEarlyModifier : fallSpeed;
        rb.linearVelocityY -= finalFallSpeed * Time.deltaTime;
        rb.linearVelocityY = Mathf.Clamp(rb.linearVelocityY, -maxFallSpeed, 1000.0f);

        justGrounded = false;
        UpdateGrab();
    }

    void ProcessInput()
    {
        if (isMouse)
        {
            if (lookAction.ReadValue<Vector2>().magnitude > detectThreshold) isMouse = false;
        }
        else
        {
            if (deltaAction.ReadValue<Vector2>().magnitude > detectThreshold) isMouse = true;
        }

        if(!jumpAction.IsPressed() && (isGrounded || rb.linearVelocityY < 0))
        {
            hasReleased = true;
        }

        if(jumpAction.IsPressed())
        {
            timeSinceLastJumpRequest = Time.time;
        }
    }

    void UpdateGrab()
    {
        Vector2 mouseWorldPos = mainCamera.ScreenToWorldPoint(pointAction.ReadValue<Vector2>()) - transform.position;
        Vector2 mouseGrabPos = Vector2.ClampMagnitude(mouseWorldPos, maxGrabDistance);
        if (lookAction.ReadValue<Vector2>().magnitude > 0) look = lookAction.ReadValue<Vector2>();
        else look = look.normalized / 100.0f;
        Vector2 controllerGrabPos = look.magnitude * maxGrabDistance > minGrabDistance ? look * maxGrabDistance : look.normalized * minGrabDistance;
        Vector2 dif = ((Vector2)transform.position + (isMouse ? mouseGrabPos : controllerGrabPos)) - (Vector2)grab.transform.position;
        grabRb.MovePosition((Vector2)grab.transform.position + dif * Time.fixedDeltaTime * grabSpeed);

        if(fireAction.IsPressed())
        {
            grabScript.Activate();
            //Gamepad.current.SetMotorSpeeds(0.25f, 0.75f);
            grab.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            //Gamepad.current.SetMotorSpeeds(0.0f, 0.0f);
            grab.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    public void Respawn()
    {
        transform.position = startPos;
    }
}