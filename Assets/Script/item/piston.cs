using UnityEngine;
using System.Collections;

public class piston : MonoBehaviour
{

    public bool directDroite = true;
    private Rigidbody2D rb;
    private Animator anim;

    private bool facingRight = true;
    private bool facingUp = true;
    private Transform groundCheck;
    private bool grounded = false;

    public float moveForce = 20f;
    // Use this for initialization

    void Awake()
    {
        anim = GetComponent<Animator>();
        groundCheck = transform.Find("grooundCheck");
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(deplacement());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator deplacement()
    {
        StartCoroutine(avance());
        yield return new WaitForSeconds(1);
        StartCoroutine(recule());
        yield return new WaitForSeconds(3);
        StartCoroutine(deplacement());
    }

    IEnumerator avance()
    {
        float h = 2;
        for (int i = 0; i < 7; i++)
        {
            if (directDroite == true)
            {
                transform.Translate(Vector2.right * h);
                rb.AddForce(Vector2.right * h);
                yield return new WaitForSeconds(0.01f);
            }
            else
            {
                transform.Translate(Vector2.left * h);
                rb.AddForce(Vector2.left * h);
                yield return new WaitForSeconds(0.01f);
            }
        }
    }

    IEnumerator recule()
    {
        float h = 2;
        for (int i = 0; i < 7; i++)
        {
            if (directDroite == false)
            {
                transform.Translate(Vector2.right * h);
                rb.AddForce(Vector2.right * h);
                yield return new WaitForSeconds(0.01f);
            }
            else
            {
                transform.Translate(Vector2.left * h);
                rb.AddForce(Vector2.left * h);
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}
