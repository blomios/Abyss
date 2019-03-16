using UnityEngine;
using System.Collections;

public class firstQuest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        quest.quete = "";
        StartCoroutine(laucher());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator laucher()
    {
        quest.quete = "Le technicien Meyer ne commence jamais sans son café ! Allons me le chercher !";
        questBis.quete = "Aller chercher le cafe du technicien Meyer dans la cuisine";
        yield return new WaitForSeconds(10);
        quest.quete = "";
    }
}
