using UnityEngine;
using System.Collections;

public class Deplacement : MonoBehaviour
{

    //public Vector2 forceSaut = new Vector3(500,500,0);

    private Rigidbody2D rb;
    private Animator anim;

    private bool facingRight = true;
    private bool facingUp = true;
    private Transform groundCheck;
    private bool grounded = false;

    public float moveForce = 0.1f;

    public float h = 0;
    public float g = 0;


    void Awake()
    {
        anim = GetComponent<Animator>();
        groundCheck = transform.Find("grooundCheck");
    }

    void Start()
    {
        //Debug.Log("Affichage scripts-start-personnage principale");
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        //déplacent horizontal
        h = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * h * moveForce);
        rb.AddForce(Vector2.right * h * moveForce);

        //déplacement vertical
        g = Input.GetAxis("Vertical");
        rb.AddForce(Vector2.up * g * moveForce);
        transform.Translate(Vector2.up * g * moveForce);

        if (h != 0 || g != 0) visee.move = true;
        else visee.move = false;
    }

    void FixedUpdate()
     {

    }

     

 }
