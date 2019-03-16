using UnityEngine;
using System.Collections;

public class caisse : MonoBehaviour {

    private Rigidbody2D rb;
    public GameObject cle;
    public GameObject pile;
    public GameObject medikit;
    public int nbCaisse;


    public int pointsPerBalle = 20;
    public int pointsPerBaril = 200;


    public int vie;                            //Vie de l'ennemi.
    public int vie_max = 100;                  //Vie totale de l'ennemi.


    private void Start()
    {
        //On initialise la vie de l'ennemi.
        
        vie = vie_max;
        radio.instantkey = false;

        rb = GetComponent<Rigidbody2D>();
    }


    //On lance cette fonction dès qu'il y a collision.
    private void OnTriggerEnter2D(Collider2D other)
    {
        //On vérifie si l'ennemi a touché une balle.

        if (other.tag == "balle_j" || other.tag == "balle_e")
        {
            //On détruit la balle.
            other.gameObject.SetActive(false);

            //On appel la fonction de perte de vie.
            LoseVie(pointsPerBalle);
        }

        else if (other.tag == "explosionBaril")
        {

            //On appel la fonction de perte de vie.
            LoseVie(pointsPerBaril);
        }

        else if (other.tag == "explosionMine")
        {

            //On appel la fonction de perte de vie.
            LoseVie(pointsPerBaril);
        }
    }


    //Losevie est appelé quand un ennemi est attaqué.
    //Il contient le parametre loss qui est la vie perdue lors de l'attaque.
    public void LoseVie(int loss)
    {
        //Actualisation de la vie de l'ennemi.
        vie -= loss;

        //On vérifie si l'ennemi est mort.
        CheckIfDied();
    }

    //CheckIfDied vérifie la vie de l'ennemi, si il n'en a plus, mort de l'ennemi et peut être spawn d'un Medkit.
    private void CheckIfDied()
    {
        //Vérifie si la vie est inférieure ou égale à 0.
        if (vie <= 0)
        {
            
            quest.caisse++;
            if (quest.caisse == 12 && radio.instantkey == false)
            {
                Instantiate(cle, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            else
            {
                double chance = Random.value; //on créer un random entre 0.0 et 1.0.
                if (chance > 0.9f && radio.instantkey == false)
                {
                    Instantiate(cle, transform.position, transform.rotation);
                    radio.instantkey = true;
                }
                if (chance <0.4f) Instantiate(pile, transform.position, transform.rotation);
                if (chance < 0.8f && chance > 0.4f) Instantiate(medikit, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
