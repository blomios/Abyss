using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class porte : MonoBehaviour
{
    public GameObject montexte;
    public GameObject porteOpen;
    public AudioClip openDoorSound;
    public float nrj;


    public static Text txt;

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
        if (other.gameObject.tag == "Joueur")
        {
            txt.text = "";
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Joueur" && generateur.energie>=10)
        {
            txt.text = "Appuyez sur E pour ouvrir";

            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(porteOpen.gameObject);
                GetComponent<AudioSource>().clip = openDoorSound;
                GetComponent<AudioSource>().Play();
                generateur.energie -= nrj/2;
                txt.text = "";
                StartCoroutine(ScanWait());
            }
        }
    }

    IEnumerator ScanWait()
    {
        yield return new WaitForSeconds(1);
        AstarPath.active.Scan();
        Destroy(gameObject);
    }

}
