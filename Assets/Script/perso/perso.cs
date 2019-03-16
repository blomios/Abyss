using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



//Class perso.
public class perso : MonoBehaviour
    {
        public int pointsPerMedkit = 10;            //Nombre de points de vie gagné en prenant un Medkit.
        public int pointsPerBigMedkit = 20;         //Nombre de points de vie gagné en prenant un BigMedkit.
        public int pointsPerBalle = 36;             //Nombre de points de vie perdu en prenant une balle.
        public int pointsPerBaril = 80;
        public float rotation = 0F;
        private int timer = 0;
        public AudioClip priseDegats;

        public static Text txt;

        public GameObject aiguille;


        public static int vie;                            //Vie du joueur.
        public int vie_max = 180;                  //Vie totale du joueur.


        private void Start()
        {
            //On initialise la vie du joueur.
            vie = vie_max;
        }

        void Update ()
        {
            aiguille.transform.rotation = Quaternion.Euler(0, 0, 180-vie);

        }

        //On lance cette fonction dès qu'il y a collision.
        private void OnTriggerEnter2D(Collider2D other)
        {
            //On vérifie si le joueur a touché un Medkit.
            if (other.tag == "Medkit")
            {
                //On ajoute la vie.
                if (vie == vie_max) ;
                else if (vie + pointsPerMedkit >= vie_max)
                {
                    vie = vie_max;
                    Destroy(other.gameObject);
                }
                else if (vie + pointsPerMedkit < vie_max)
                {
                    vie += pointsPerMedkit;
                    Destroy(other.gameObject);
                }


            }

            if (other.tag == "mineLoot")
            {
                questLvl2.mineLoot += 1;
                Destroy(other.gameObject);
        }

        if (other.tag == "cleTrappe")
        {
            questLvl2.quest6Ok=true;
            questLvl2.KeyTaked = true;
            Destroy(other.gameObject);
        }

        if (other.tag == "vide")
            {
                Debug.Log("videPerso");
                vie = 0;
                CheckIfGameOver();
            }

                if (other.tag == "Pile")
            {
                generateur.energie += 13;
                Destroy(other.gameObject);
                if (generateur.energie > 100)
                {
                    generateur.energie = 100;
                }
            }

            if (other.tag == "cle")
            {
                radio.keyRadio = true;
                if (radio.questRadio == false) quest.quete = "Cle recuperee ! Je devrais pouvoir reparer quelque chose avec ca !";
                Destroy(other.gameObject);

            }



            //On vérifie si le joueur a touché un BigMedkit.
            else if (other.tag == "BigMedkit")
            {
                //On ajoute la vie
                if (vie + pointsPerBigMedkit >= vie_max)
                {
                    vie = vie_max;
                }
                else
                {
                    vie += pointsPerBigMedkit;
                }

                //Retire le BigMedkit.
                other.gameObject.SetActive(false);
            }

            else if (other.tag == "balle_e")
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


        //Losevie est appelé quand un ennemi attaque le joueur.
        //Il contient le parametre loss qui est la vie perdue lors de l'attaque.
        public void LoseVie(int loss)
        {

            //Actualisation de la vie du joueur.
            vie -= loss;
            GetComponent<AudioSource>().clip = priseDegats;
            GetComponent<AudioSource>().Play();

            //On vérifie si le jeu est terminé.
            CheckIfGameOver();
        }


        //CheckIfGameOver vérifie la vie du joueur and, si il n'en a plus, fin du jeu.
        private void CheckIfGameOver()
        {
            //Vérifie si la vie est inférieure ou égale à 0.
            if (vie <= 0)
            {

                SceneManager.LoadScene("GameOver");


            }
        }
}

