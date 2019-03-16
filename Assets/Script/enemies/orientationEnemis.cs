﻿using UnityEngine;
using System.Collections;

public class orientationEnemis : MonoBehaviour {

    private Vector3 temp;
    public SpriteRenderer enemis;
    public Sprite gauche;
    public Sprite droit;
    public Sprite haut;
    public Sprite bas;
    private bool negativeX;
    private bool negativeY;

    private Vector3 now;
    private Vector3 difPos; //Va voir les changements de position sur les axes x y et z
    private Vector3 dif; //Va garder les negativité pour savoir dans quel sens on s'est deplacé sur chaque axe
    private bool first = true;
    public SpriteRenderer balle;

    // Use this for initialization
    void Start () {
        StartCoroutine(refresh());
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    IEnumerator refresh()
    {


        yield return new WaitForSeconds(0.2f);

        if (first == true)
        {
            first = false;
            temp = transform.position;
        }
        else
        {
            now = transform.position;

            if (temp.x > 0)
            {
                if (now.x > 0)
                {
                    dif.x = (temp.x) * (-1) + now.x;
                }
                else dif.x = temp.x - now.x;
            }

            else
            {
                if (now.x > 0)
                {
                    dif.x = (temp.x) * (-1) + now.x;
                }
                else
                {
                    dif.x = (temp.x) * (-1) + now.x;
                }
            }

            if (temp.y > 0)
            {
                if (now.y > 0)
                {
                    dif.y = (temp.y) * (-1) + now.y;
                }
                else dif.y = temp.y - now.y;
            }

            else
            {
                if (now.x > 0)
                {
                    dif.y = (temp.y) * (-1) + now.y;
                }
                else
                {
                    dif.y = (temp.y) * (-1) + now.y;
                }
            }


            //On change les sprites en fonction de l'orientation du mob (par rapport a son dernier deplacement)

            if (dif.x > dif.y)
            {
                if (dif.x > 0)
                {
                    GetComponent<SpriteRenderer>().sprite = droit;
                }
                else
                {
                    GetComponent<SpriteRenderer>().sprite = gauche;
                }
            }
            else
            {
                if (dif.y > 0)
                {
                    GetComponent<SpriteRenderer>().sprite = haut;
                }
                else
                {
                    GetComponent<SpriteRenderer>().sprite = bas;
                }
            }

            temp = now;
        }
        StartCoroutine(refresh());
    }
}
