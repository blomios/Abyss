using UnityEngine;
using System.Collections;

public class firstQuestLvl3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        quest.quete = "";
        arme_joueur.minedispo = true;
        arme_joueur.minedispo = true;
        saveScene.currentScene = 3;
        StartCoroutine(laucher());
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator laucher()
    {
        quest.quete = "Talkie: Oula ! Le robot de combat ! Son bouclier protecteur est un vrai probleme ! Utilise les mines pour le court-circuiter !!";
        yield return new WaitForSeconds(10);
        quest.quete = "";
    }
}
