using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myRB;
    private Animator myAnim;

    [SerializeField]
    private float speed = 0f;

    private float attackTime = .25f;
    private float attackCounter = .25f;
    private bool isAttacking;

    private Vector2 movement;

    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    void Update()
    {
        // Only capture movement input if not attacking
        if (!isAttacking)
        {
            movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

            // Update movement animation
            myAnim.SetFloat("moveX", movement.x);
            myAnim.SetFloat("moveY", movement.y);

            if (movement.x != 0 || movement.y != 0)
            {
                myAnim.SetFloat("lastMoveX", movement.x);
                myAnim.SetFloat("lastMoveY", movement.y);
            }
        }

        // Handle attack state
        if (isAttacking)
        {
            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0)
            {
                myAnim.SetBool("isAttacking", false);
                isAttacking = false;
            }
        }

        // Start attack
        if (!isAttacking && Input.GetKeyDown(KeyCode.Mouse0))
        {
            attackCounter = attackTime;
            myAnim.SetBool("isAttacking", true);
            isAttacking = true;
            myRB.linearVelocity = Vector2.zero; // Stop immediately when attack starts
        }
    }


    void FixedUpdate()
    {
        if (!isAttacking)
        {
            myRB.linearVelocity = movement * speed;
        }
        else
        {
            myRB.linearVelocity = Vector2.zero;
        }
    }

}
