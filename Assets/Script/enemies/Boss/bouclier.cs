using UnityEngine;
using System.Collections;

public class bouclier : MonoBehaviour {

    public Sprite bouclierDesactivate;
    public Sprite bouclierActivate;

    // Use this for initialization
    void Start () {
        arme_joueur.minedispo = true;
        mine.minePlanted = false;
	}
	
	// Update is called once per frame
	void Update () {

        if(bosse.isProtected==false) GetComponent<SpriteRenderer>().sprite = bouclierDesactivate;
        if (bosse.isProtected == true) GetComponent<SpriteRenderer>().sprite = bouclierActivate;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "balle_j")
        {
            //On détruit la balle.
            Destroy(other);
        }

        if (other.tag == "explosionMine")
        {
            bosse.isProtected = false;
        }

    }
}
