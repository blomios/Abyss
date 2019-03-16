using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class cafe : MonoBehaviour {

    public GameObject montexte;
    public GameObject cofee;
    public static bool questcofee = false;

    void Start()
    {
        questcofee = false;
    }


    Text txt;

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
        if (other.gameObject.tag == "cafe")
        {
            txt.text = "";
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        {
            if (other.tag == "cafe")
            {
                porte.txt.text = "Appuyez sur E pour interagir";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    questcofee = true;
                    txt.text = "";
                    StartCoroutine(messageQuest("Je me sent tout revigore ! Je ferais mieux d'aller demander de l'aide par la radio !"));
                    questBis.quete = "Aller a la radio";
                    Destroy(cofee);
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
