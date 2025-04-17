using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private Animator myAnim;
    private Transform target;
    public Transform homePosition;

    [SerializeField]
    private float speed = 0f;
    [SerializeField]
    private float maxRange = 0f;
    [SerializeField]
    private float minRange = 0f;

    void Start()
    {
        myAnim = GetComponent<Animator>();
        target = FindObjectOfType<PlayerController>().transform;
    }


    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange) {
            FollowPlayer();
        } 
        else if (Vector3.Distance(target.position, transform.position) >= maxRange) {
            GoHome();
        }
    }

    // function to follow player
    public void FollowPlayer() {
        myAnim.SetBool("isMoving", true);
        myAnim.SetFloat("moveX", (target.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void GoHome() {
        myAnim.SetFloat("moveX", (homePosition.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (homePosition.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, homePosition.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, homePosition.position) == 0) {
            myAnim.SetBool("isMoving", false);
        }
    }
}
