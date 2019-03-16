using UnityEngine;
using System.Collections;

public class arme_joueur : MonoBehaviour
{

    // private Animator anim;
    public Rigidbody2D balle_joueur;
    public GameObject canon;
    public GameObject mineObject;
    public static bool minedispo = false;
    public float speed = 20f;
    private bool tirverif = false;
    public AudioClip tir;
    public AudioClip putMine;


    void Awake()
    {
        //anim = transform.root.gameObject.GetComponent<Animator>();
    }


    //Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tirverif == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                tirverif = true;
                StartCoroutine(tirFunction());
            }
        }

        if (minedispo == true)
        {
            if (Input.GetButtonDown("Fire2") && mine.minePlanted == false)
            {
                mine.minePlanted = true;
                GetComponent<AudioSource>().clip = putMine;
                GetComponent<AudioSource>().Play();
                Instantiate(mineObject, transform.position, transform.rotation);
            }
        }

        if (tirverif == true)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                tirverif = false;
            }
        }
    }

    IEnumerator tirFunction()
    {
        while (tirverif == true)
        {
            Vector2 tirr = Camera.main.ScreenToWorldPoint(Input.mousePosition) - canon.transform.position;
            float ang = Vector2.Angle(new Vector2(1, 0), tirr);
            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y < 0)
                ang = -ang;

            Rigidbody2D bulletInstance = Instantiate(balle_joueur, canon.transform.position, Quaternion.Euler(new Vector3(0, 0, ang))) as Rigidbody2D;


            bulletInstance.velocity = speed * tirr.normalized;
            GetComponent<AudioSource>().clip = tir;
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(0.2F); 
        }
    }


}
       