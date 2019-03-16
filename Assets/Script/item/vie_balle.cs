using UnityEngine;
using System.Collections;

public class vie_balle : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="mur")
        {
            Destroy(gameObject);
        }
        if (other.tag == "portes")
        {
            Destroy(gameObject);
        }
        if (other.tag == "piston")
        {
            Destroy(gameObject);
        }
        if (other.tag == "cachePiston")
        {
            Destroy(gameObject);
        }
    }

}
