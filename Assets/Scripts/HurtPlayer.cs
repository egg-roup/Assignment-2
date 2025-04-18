using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour
{
    private HealthManager healthMan;
    public float waitToHurt = 2f;
    public bool isTouching;
    [SerializeField]
    private int damageToGive = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthMan = FindFirstObjectByType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (reloading)
        {
            waitToLoad -= Time.deltaTime;
            if (waitToLoad <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }*/

        if (isTouching)
        {
            waitToHurt -= Time.deltaTime;
            if (waitToHurt <= 0)
            {
                healthMan.HurtPlayer(damageToGive);
                waitToHurt = 2f;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            //Destroy(other.gameObject);
            //other.gameObject.SetActive(false);
            other.gameObject.GetComponent<HealthManager>().HurtPlayer(damageToGive);

            //reloading = true;
            
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            isTouching = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            isTouching = false;
            waitToHurt = 2f;
        }
    }
}
