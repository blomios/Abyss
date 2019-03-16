using UnityEngine;
using System.Collections;

class arme_ennemi : MonoBehaviour
{

    // private Animator anim;
    public Rigidbody2D balle_ennemi;
    public float speed = 20f;
    public bool detection = false;
    int timer = 0;
    public float distanceDetect = 10f;
    public AudioClip soundTir;

    private GameObject perso;


    void Awake()
    {
        //anim = transform.root.gameObject.GetComponent<Animator>();
    }

    void Start()
    {
        perso = GameObject.Find("perso");
    }



    // Update is called once per frame
    void Update()
    {
                 //Le joueur est a ditance
        if (perso)
        {
            float sqrLen = (perso.transform.position - transform.position).sqrMagnitude;
            if (sqrLen < distanceDetect * distanceDetect)
            {
                detection = true;
                timer++;
            }
            else detection = false;
       
        }


       
        if (timer >= 100 && detection == true)
        {
                tir();
                timer = 0;
        }
    }

    

   
    public void tir()
    {
        GetComponent<AudioSource>().clip = soundTir;
        GetComponent<AudioSource>().Play();
        Vector2 tir = perso.transform.position - transform.position;
        float ang = Vector2.Angle(new Vector2(1, 0), tir);
        if (perso.transform.position.y < transform.position.y)
            ang = -ang;
        Rigidbody2D bulletInstance = Instantiate(balle_ennemi, transform.position, Quaternion.Euler(new Vector3(0, 0, ang - 90))) as Rigidbody2D;
        bulletInstance.velocity = speed * tir.normalized;
    }
}
