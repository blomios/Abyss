using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class generateur : MonoBehaviour {

    public static float energie = 70;
    public float energieMax = 100;
    public float consomation = 1;
    public Light lumiere;
    public GameObject porte;
    public bool messagePossible = true;

    Text text;

    void Awake()
    {
        // Set up the reference.
        text = GetComponent<Text>();
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(consomme());
        messagePossible = true;
        energie = 70;
}
	
	// Update is called once per frame
	void Update () {

        text.text = "Energie : " + energie +  " %";
        if (energie > 5)
        {
            if (energie != 40)
            {
                lumiere.intensity = 3;
            }
        }

        if (energie == 40)
        {
            StartCoroutine(midCoupure());
        }
        if (energie <= 5)
        {
            lumiere.intensity = 0;
        }
        if (energie == 100)
        {

            StartCoroutine(stabilise());

        }
    }

    IEnumerator consomme()
    {
        yield return new WaitForSeconds(1);
        if (energie > 0)
        {
            if (energie < 100)
            {
                energie -= consomation;
            }
        }
        StartCoroutine(consomme());
    }

    IEnumerator midCoupure()
    {
        lumiere.intensity = 0;
        yield return new WaitForSeconds(1.0f);
        lumiere.intensity = 2f;
        yield return new WaitForSeconds(0.7f);
        lumiere.intensity = 1f;
        yield return new WaitForSeconds(0.7f);
        lumiere.intensity = 3f;
    }

    IEnumerator stabilise()
    {
        if (tableauCommandes.questFilOk == true)
        {
            porte.transform.position += new Vector3(7.75f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(5f);
            quest.quete = "";
        }
    }
}
