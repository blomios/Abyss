using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class radio : MonoBehaviour {
    public GameObject montexte;
    public static bool keyRadio = false;
    public static bool questRadio = false;
    public static bool questFil = false;
    private string message;
    public static bool keydone = false;
    public static bool instantkey = false;
    public static int caisseCassee = 0;


    Text txt;

    void Start()
    {
        keydone = false;
        questFil = false;
        questRadio = false;
        keyRadio = false;
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

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "radio")
        {
            txt.text = "";
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (cafe.questcofee == true)
        {
            if (other.tag == "radio")
            {
                txt.text = "Appuyez sur E pour interagir";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (keyRadio == false && tableauCommandes.questFilOk == false)
                    {
                        questBis.quete = "trouvez de quoi reparer la radio";
                        StartCoroutine(messageQuest("La radio est cassée... Va falloir que je trouve de quoi la reparer... Peut etre en cassant une de ses caisses en bois..."));
                    }
                    else if (generateur.energie != 100 && tableauCommandes.questFilOk == false)
                    {
                        questBis.quete = "recuperer de l'energie, mettre le generateur a 100%";
                        StartCoroutine(messageQuest("Radio : COOONTACT !!!! Detruisez des robots et des caisses pour recuperer de l'energie et alimenter le generateur a 100% puis revenez à la radio !"));
                        keydone = true;
                    }
                    else if (generateur.energie == 100 && tableauCommandes.questFilOk == false)
                    {
                        questBis.quete = "Coupez le fil du tableau de bord puis accedez au niveau suivant";
                        StartCoroutine(messageQuest("Radio : Bien joué ! maintenant allez couper le fil de securite des portes au niveau du tableau de commande pour ouvrir la porte au Nord !"));
                        questFil = true;
                    }
                }
            }
        }
    }

    IEnumerator messageQuest(string message)
    {
        quest.quete = message;
        yield return new WaitForSeconds(7f);
        quest.quete = "";
    }
}
