using UnityEngine;
using System.Collections;

public class trappe : MonoBehaviour
{
    public GameObject echelleTrappe;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        {
            if (other.tag == "Joueur")
            {


                if (questLvl2.quest6 == true)
                {

                    interact.interacted = "Appuyez sur E pour interagirt";
                    if (Input.GetKeyDown(KeyCode.E))

                    {
                        if (questLvl2.quest6Ok == true)
                        {
                            interact.interacted = "";
                            Instantiate(echelleTrappe, transform.position, transform.rotation);
                            Destroy(gameObject);
                        }
                        else quest.quete = "La trappe est bien verrouillée...";
                    }
                }
            }
        }
    }
}
