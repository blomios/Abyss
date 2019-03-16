using UnityEngine;
using System.Collections;

public class firstQUestLvl2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        arme_joueur.minedispo = false;
        quest.quete = "";
        StartCoroutine(laucher());
        saveScene.currentScene = 2;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator laucher()
    {
        quest.quete = "Mmmm.. Je devrais me rendre a la radio de cet etage...";
        questBis.quete = "Se rendre a la radio";
        yield return new WaitForSeconds(10);
        quest.quete = "";
    }
}
