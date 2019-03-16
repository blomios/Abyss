using UnityEngine;
using System.Collections;

public class alarme : MonoBehaviour {

    public static bool alarmeUp = false;
    public AudioClip upBoss;
    public Light lumiere;

    // Use this for initialization
    void Start () {
        alarmeUp = false; 
    }
	
	// Update is called once per frame
	void Update () {
        if (alarmeUp == true)
        {
            alarmeUp = false;
            StartCoroutine(up());
        }
    }

    IEnumerator up()
    {
        for (int i = 0; i < 7; i++)
        {
            yield return new WaitForSeconds(1.0f);
            GetComponent<AudioSource>().clip = upBoss;
            GetComponent<AudioSource>().Play();
            lumiere.color = Color.red;
            yield return new WaitForSeconds(0.830f);
            lumiere.color = Color.white;
        }
    }
}
