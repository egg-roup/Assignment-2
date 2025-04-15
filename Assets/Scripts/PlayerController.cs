using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRB;
    private Animator myAnim;

    [SerializeField]
    private float speed;

    private Vector2 movement;

    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    void Update()
    {
        // Capture input
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        // Update movement animation
        myAnim.SetFloat("moveX", movement.x);
        myAnim.SetFloat("moveY", movement.y);

        // Only update lastMove when a directional key is pressed
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            myAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }
    }

    void FixedUpdate()
    {
        // Move the player using Unity 6's new linearVelocity
        myRB.linearVelocity = movement * speed;
    }
}
