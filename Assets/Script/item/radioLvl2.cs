using UnityEngine;
using System.Collections;

public class radioLvl2 : MonoBehaviour
{
    
    public static int caisseCassee = 0;

    // Use this for initialization
    void Start()
    {
        caisseCassee = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (questLvl2.quest1 == false)
        {
            questBis.quete = "Aller a la radio";
        }

        if (questLvl2.quest1 == true && questLvl2.quest1Ok == false)
        {
            questBis.quete = "Detruire 10 robots: " + questLvl2.destroyRobots + "/10";
        }


        else if (questLvl2.quest1Ok == true && questLvl2.quest2Go == true && questLvl2.quest2Ok == false)
        {
            questBis.quete = "Detruire les chargeurs de robots" + questLvl2.destroyLoader + "/8";
        }


        else if (questLvl2.quest2Ok == true && questLvl2.quest3Ok == false && questLvl2.quest3Go == true)
        {
            questBis.quete = "Recuperer les mines" + questLvl2.mineLoot + "/2";
        }

        else if (questLvl2.quest3Ok == true && questLvl2.quest4Go == true && questLvl2.quest5Go == false)
        {
            int count = 0;
            if (questLvl2.mineUsed == true) count = 1;
            questBis.quete = "Utiliser une mine" + count + "/1";

        }

        else if (questLvl2.quest4Ok == true && questLvl2.quest5Go == true && questLvl2.quest6Go == false)
        {
            int count = 0;
            if (questLvl2.talkieTaked== true) count = 1;
            questBis.quete = "Aller chercher le talkie Walkie" + count + "/1";
        }

        else if (questLvl2.quest5Ok == true && questLvl2.quest6Go == true)
        {
            int count = 0;
            if (questLvl2.KeyTaked == true) count = 1;
            questBis.quete = "Recuperer la cle et ouvrir la trappe: " + count + "/1";
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        {
            if (other.tag == "Joueur")
            {


                if (questLvl2.quest1Ok == false)
                {

                    interact.interacted = "Appuyez sur E pour interagir";
                    if (Input.GetKeyDown(KeyCode.E))

                    {
                        questLvl2.quest1 = true;
                        StartCoroutine(quest1());
                    }
                }


                else if (questLvl2.quest1Ok == true && questLvl2.quest2Ok == false)
                {

                    interact.interacted = "Appuyez sur E pour interagir";
                    if (Input.GetKeyDown(KeyCode.E))

                    {
                        StartCoroutine(quest2());
                    }
                }


                else if (questLvl2.quest2Ok == true && questLvl2.quest3Ok == false)
                {

                    interact.interacted = "Appuyez sur E pour interagir";
                    if (Input.GetKeyDown(KeyCode.E))

                    {
                        StartCoroutine(quest3());
                    }
                }

                else if (questLvl2.quest3Ok == true && questLvl2.quest4Ok == false)
                {

                    interact.interacted = "Appuyez sur E pour interagir";
                    if (Input.GetKeyDown(KeyCode.E))

                    {
                        StartCoroutine(quest4());
                    }
                }

                else if (questLvl2.quest4Ok == true && questLvl2.quest5Ok == false)
                {

                    interact.interacted = "Appuyez sur E pour interagir";
                    if (Input.GetKeyDown(KeyCode.E))

                    {
                        StartCoroutine(quest5());
                    }
                }

                else if (questLvl2.quest5Ok == true)
                {

                    interact.interacted = "Appuyez sur E pour interagir";
                    if (Input.GetKeyDown(KeyCode.E))

                    {
                        StartCoroutine(quest6());
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

    IEnumerator quest1()
    {
        
        quest.quete = "Radio: MMM.. Pour commencer tu devrais nettoyer un peu la zone.. Detruis nous une dizaine de robots";
        questBis.valide = false;
        yield return new WaitForSeconds(10);
        quest.quete = "";
    }

    IEnumerator quest2()
    {
        questLvl2.quest2Go = true;
        quest.quete = "Radio: Bon... Il y en a toujours autant.. Essaye de detruire les chargeurs des robots ça arretera peut etre les vagues...";
        questBis.valide = false;
        yield return new WaitForSeconds(10);
        quest.quete = "";
    }

    IEnumerator quest3()
    {
        questLvl2.quest3Go = true;
        quest.quete = "Radio: Les vagues ne s'arretent toujours pas.. Va chercher les mines dans les caisses de fer au Sud.. Je te dirai apres comment les utiliser..";
        questBis.valide = false;
        yield return new WaitForSeconds(10);
        quest.quete = "";
    }

    IEnumerator quest4()
    {
        questLvl2.quest4Go = true;
        arme_joueur.minedispo = true;
        quest.quete = "Radio: Bon.. Ces mines sont tres puissantes.. Pour ne pas faire couler le sous-marin tu ne pourras les poser qu'une par une... Commence par en poser une avec clic droit puis tire dessus pour la faire exploser...";
        questBis.valide = false;

        yield return new WaitForSeconds(10);
        quest.quete = "";
    }

    IEnumerator quest5()
    {
        questLvl2.quest5Go = true;
        quest.quete = "Radio: Tres bien... Pour le dernier niveau il n'y a pas de radio.. va donc chercher le talkie Walkie sur le tableau de bord et reviens me voir..";
        questBis.valide = false;
        yield return new WaitForSeconds(10);
        quest.quete = "";
    }

    IEnumerator quest6()
    {
        questLvl2.quest6Go = true;
        quest.quete = "Radio: L'echelle pour acceder au prochain niveau est bloquee par une trappe.. La cle de cette trappe a sans doute ete cachee dans une caisse.. Trouve cette cle et rend toi au prochain niveau..";
        questBis.valide = false;

        yield return new WaitForSeconds(10);
        questLvl2.quest6 = true;
        quest.quete = "";
    }
}
