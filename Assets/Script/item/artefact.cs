using UnityEngine;
using System.Collections;

public class artefact : MonoBehaviour {

    private Rigidbody2D rb;


    public int pointsPerBalle = 20;
    public int pointsPerBaril = 200;


    public int vie;                            //Vie de l'ennemi.
    public int vie_max = 60;                  //Vie totale de l'ennemi.


    private void Start()
    {
        //On initialise la vie de l'ennemi.

        vie = vie_max;

        rb = GetComponent<Rigidbody2D>();
    }
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
            quest.quete = "Talkie: et mince... Je peux plus rien faire pour toi.. On a detruit l'artefact mais rien n'y fait... Je suis desole.. Tu vas devoir resister aussi longtemps que tu le peux..";
            Destroy(gameObject);
        }
    }
}
