using UnityEngine;
using System.Collections;

public class posarme : MonoBehaviour 
{

    public Transform pointeur;
    public Transform perso;
    public Transform bras1;
    public Transform bras2;
    public SpriteRenderer brasRenderer;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        //if (perso.position.y == pointeur.position.y && perso.position.x < pointeur.position.x) this.transform.position = bras1.transform.position;
        //if (perso.position.y == pointeur.position.y && perso.position.x > pointeur.position.x) this.transform.position = bras2.transform.position;

        Vector3 directionOfRotation = transform.position - pointeur.position; // direction de la rotation
        transform.rotation = Quaternion.LookRotation(Vector3.forward, directionOfRotation);
	}
}
