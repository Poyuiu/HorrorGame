using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Config")]
    public float speed;
    public float sprintMultiplier;
    public float gravity;
    public float groundDistance;
    public float jumpHeight;
    public Animator anim;
    public Canvas hints_1;
    public GameObject brian;

    public Camera cam;
    //public LayerMask groundMask;

    // PRIVATE //
    private bool isGrounded = true;
    private float actualSpeed;
    private float stepOffset;
    private float slopeLimit;
    private Vector3 velocity;

    [Header("Reference")]
    public CharacterController controller;
    //public Transform groundCheck;

    private void Start()
    {
        stepOffset = controller.stepOffset;
        slopeLimit = controller.slopeLimit;
    }

    private void Update()
    {
        // Change the stepOffset and slope limit for avoid "climbing" if you don't have the jump distance
        if (isGrounded)
        {
            controller.stepOffset = stepOffset;
            controller.slopeLimit = slopeLimit;
        }
        else
        {
            controller.stepOffset = 0f;
            controller.slopeLimit = 100f;
        }
        // Control speed
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded) actualSpeed = speed * sprintMultiplier;
        else if (isGrounded) actualSpeed = speed;

        // Check ground
        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //if (isGrounded && velocity.y < 0) velocity.y = -2f;

        // Movement
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        // Horizontal
        Vector3 move = Vector3.Normalize(transform.right * x + transform.forward * z);
        controller.Move(move * actualSpeed * Time.deltaTime);

        // Vertical
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        if ((controller.collisionFlags & CollisionFlags.Above) != 0)
        {
            velocity.y = -2f;
        }


        // check state
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            cam.cullingMask = LayerMask.GetMask(
                    "Default", "Ignore Raycast", "Water", "UI");
        }
        else
        {
            cam.cullingMask = LayerMask.GetMask("TransparentFX",
                    "Default", "Ignore Raycast", "Water", "UI");
            anim.SetBool("Picking", false);
            hints_1.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Medicine"))
        {
            hints_1.enabled = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Medicine"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                brian.transform.position
                    = transform.position - new Vector3(0, 1, 0) - transform.forward;
                cam.cullingMask = LayerMask.GetMask("TransparentFX",
                    "Default", "Ignore Raycast", "Water", "UI");
                anim.SetBool("Picking", true);
                Destroy(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Medicine"))
        {
            hints_1.enabled = false;
        }
    }
}
