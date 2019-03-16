using UnityEngine;
using System.Collections;

public class talkieWalkie : MonoBehaviour
{

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


                if (questLvl2.quest5Ok == false && questLvl2.quest4Ok == true)
                {

                    interact.interacted = "Appuyez sur E pour interagir";
                    if (Input.GetKeyDown(KeyCode.E))

                    {
                        questLvl2.talkieTaked = true;
                        Destroy(gameObject);
                        questLvl2.quest5Ok = true;
                        interact.interacted = "";
                    }
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Joueur")
        {
            interact.interacted = "";
        }
    }
}
