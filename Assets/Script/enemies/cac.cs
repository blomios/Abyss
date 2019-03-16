using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace completed
{
    public class cac : MonoBehaviour
    {
        public bool detection = false;
        public bool attaque = true;
        public float distanceDetect = 10f;
        public AudioClip priseDegats;

        private GameObject joueur;

        // Use this for initialization
        void Start()
        {
            joueur = GameObject.Find("perso");
            StartCoroutine(timer());
        }

        // Update is called once per frame
        void Update()
        {

            if (joueur)
            {
                float sqrLen = (joueur.transform.position - transform.position).sqrMagnitude;
                if (sqrLen < 50)
                {
                    detection = true;
                }
                else detection = false;

            }

            if (attaque==true && detection == true)
            {
                //Actualisation de la vie du joueur.
                attaque = false;
                GetComponent<AudioSource>().clip = priseDegats;
                GetComponent<AudioSource>().Play();
                perso.vie -= 27;

                //On vérifie si le jeu est terminé.
                if (perso.vie <= 0)
                {

                    SceneManager.LoadScene("GameOver");


                }
            }

        }
        IEnumerator timer()
        {
            if (attaque == false)
            {
                yield return new WaitForSeconds(1.5f);
                attaque = true;
            }
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(timer());
        }
    }
}
