using UnityEngine;
using System.Collections;

public class cle : MonoBehaviour {

    public Sprite sprite;
    public Sprite spriteTransp;
    // Use this for initialization
    void Start () {
        GetComponent<SpriteRenderer>().sprite =spriteTransp;
    }
	
	// Update is called once per frame
	void Update () {
	 if (radio.keyRadio == true && radio.keydone==false)
     {
            GetComponent<SpriteRenderer>().sprite = sprite;
      }
     else if (radio.keydone == true)
        {
            GetComponent<SpriteRenderer>().sprite = sprite;
            Debug.Log("test");
            Destroy(gameObject);
        }
	}
}
