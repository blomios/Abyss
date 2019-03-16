using UnityEngine;
using System.Collections;

namespace Completed
{
    //Class ia.
    public class IA_vie_dropMedkit : MonoBehaviour
    {

        private Rigidbody2D rb;
        public GameObject Medkit; //objet Medkit
        public GameObject Pile; //objet Medkit


        public int pointsPerBalle = 20;             //Nombre de points de vie perdu en prenant une balle.
        public int scoreValue = 1;


        public int vie;                            //Vie de l'ennemi.
        public int vie_max = 100;                  //Vie totale de l'ennemi.


        private void Start()
        {
            //On initialise la vie de l'ennemi.
            vie = vie_max;

            rb = GetComponent<Rigidbody2D>();
        }


        //On lance cette fonction dès qu'il y a collision.
        private void OnTriggerEnter2D(Collider2D other)
        {
            //On vérifie si l'ennemi a touché une balle.

            if (other.tag == "balle_j")
            {
                //On détruit la balle.
                other.gameObject.SetActive(false);

                //On appel la fonction de perte de vie.
                LoseVie(pointsPerBalle);
            }

            if (other.tag == "explosionMine")
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
                ScoreManager.score += scoreValue;
                double chance = Random.value; //on créer un random entre 0.0 et 1.0.
                if (chance > 0.6f) Instantiate(Medkit, transform.position,transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}



