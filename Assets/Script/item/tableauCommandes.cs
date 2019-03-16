using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class tableauCommandes : MonoBehaviour {
    public GameObject montexte;
    public static bool questFilOk = false;


    Text txt;

    void Start()
    {
        questFilOk = false;
    }

    // Use this for initialization
    void Awake()
    {
        txt = montexte.GetComponent<Text>();
        txt.text = "";
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "tableCommande")
        {
            txt.text = "";
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (radio.questFil == true && questFilOk == false)
        {
            if (other.tag == "tableCommande")
            {
                txt.text = "Appuyez sur E pour interagir";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    questFilOk = true;
                    if (generateur.energie == 100) quest.quete = "C'est bon... J'ai enfin ouvert cette porte...";
                    else quest.quete = "Pour l'ouvrir je vais devoir alimenter le generateur a 100%...";
                }
            }
        }
    }
}
