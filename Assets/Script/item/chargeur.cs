using UnityEngine;
using System.Collections;

public class chargeur : MonoBehaviour {

    private Rigidbody2D rb;
    public GameObject enemi;
    public Sprite sprite;
    public bool detruit = false;
    public AudioClip[] priseDegats;
    public AudioClip vitreCassee;
    public bool versGauche = true;


    public int pointsPerBalle = 20;


    public int vie;                            //Vie de l'ennemi.
    public int vie_max = 100;                  //Vie totale de l'ennemi.


    private void Start()
    {
        detruit = false;
        //On initialise la vie de l'ennemi.
        vie = vie_max;
        radio.instantkey = false;

        rb = GetComponent<Rigidbody2D>();
    }


    //On lance cette fonction dès qu'il y a collision.
    private void OnTriggerEnter2D(Collider2D other)
    {
        //On vérifie si l'ennemi a touché une balle.

        if (other.tag == "balle_j" || other.tag == "balle_e" && questLvl2.quest2Go==true)
        {
            if (questLvl2.quest2Go == true)
            {
                //On détruit la balle.
                other.gameObject.SetActive(false);
                //On appel la fonction de perte de vie.
                LoseVie(pointsPerBalle);
            }
        }

        if (other.tag == "explosionBaril" && questLvl2.quest2Go == true)
        {

            //On appel la fonction de perte de vie.
            LoseVie(200);
        }

        if (other.tag == "explosionMine" && questLvl2.quest2Go == true)
        {

            //On appel la fonction de perte de vie.
            LoseVie(200);
        }
    }


    //Losevie est appelé quand un ennemi est attaqué.
    //Il contient le parametre loss qui est la vie perdue lors de l'attaque.
    public void LoseVie(int loss)
    {
        //Actualisation de la vie de l'ennemi.
        int sound = Random.Range(0, priseDegats.Length);
        vie -= loss;
        GetComponent<AudioSource>().clip = priseDegats[sound];
        GetComponent<AudioSource>().Play();

        //On vérifie si l'ennemi est mort.
        CheckIfDied();
    }

    //CheckIfDied vérifie la vie de l'ennemi, si il n'en a plus, mort de l'ennemi et peut être spawn d'un Medkit.
    private void CheckIfDied()
    {
        //Vérifie si la vie est inférieure ou égale à 0.
        if (vie <= 0 && detruit==false)
        {
            questLvl2.destroyLoader += 1;
            detruit = true;
            Vector3 spawn = transform.position;
            Instantiate(enemi, spawn, transform.rotation);
            GetComponent<AudioSource>().clip = vitreCassee;
            GetComponent<AudioSource>().Play();
            GetComponent<SpriteRenderer>().sprite = sprite;
        }
    }
}
