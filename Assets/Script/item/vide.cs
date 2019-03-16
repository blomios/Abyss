using UnityEngine;
using System.Collections;

public class vide : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //On vérifie si le joueur a touché un Medkit.
        if (other.tag == "Joueur")
        {
            perso.vie = 0;
        }

        if (other.tag == "MedKit")
        {
            Destroy(other.gameObject);
        }

        if (other.tag == "Pile")
        {
            Destroy(other.gameObject);
        }


    }
}
