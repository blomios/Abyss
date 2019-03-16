using UnityEngine;
using System.Collections;

public class visee : MonoBehaviour
{
    public GameObject player;
    public Transform pointeur;
    public GameObject brasPos;
    public GameObject bras;
    public Sprite gauche;
    public int order = 0;
    public SpriteRenderer balle;
    public SpriteRenderer brasLayer;
    public Animator anim;

    public bool droitTrigger=false;
    public bool gaucheTrigger = false;
    public bool faceTrigger = false;
    public bool dosTrigger = false;
    public static bool move = false;

    private int precPrecOrientation=0;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionOfRotation = transform.position - pointeur.position; // direction de la rotation
        bras.transform.rotation = Quaternion.LookRotation(Vector3.forward, directionOfRotation);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "viseur")
        {
            bras.transform.position = brasPos.transform.position;
            balle.sortingOrder = order;
            brasLayer.sortingOrder = order;

            if (droitTrigger == true && move==true) {
                anim.Play("Marche droite");
            }

            if (droitTrigger == true && move == false)
            {
                anim.Play("Idle droite");
            }

            if (faceTrigger == true && move == true)
            {
                anim.Play("Marche");
            }

            if (faceTrigger == true && move == false)
            {
                anim.Play("Idle");
            }

            if (gaucheTrigger == true && move == true)
            {
                anim.Play("Marche gauche");
            }

            if (gaucheTrigger == true && move == false)
            {
                anim.Play("Idle gauche");
            }

            if (dosTrigger == true && move == true)
            {
                anim.Play("Marche tourné");
            }

            if (dosTrigger == true && move == false)
            {
                anim.Play("Idle tourné");
            }
        }
    }
}
