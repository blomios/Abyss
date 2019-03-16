using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class musiqueManager : MonoBehaviour {
    public AudioClip musique1;
    public AudioClip musique2;
    private AudioSource audio;

    // Use this for initialization
    void Start () {
        Debug.Log(saveScene.currentScene);
        audio = GetComponent<AudioSource>();
        GetComponent<AudioSource>().clip = musique1;
        GetComponent<AudioSource>().Play();
        StartCoroutine(musisqueNiv1());

   

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator musisqueNiv1()
    {
        yield return new WaitForSeconds(musique1.length);
        audio.loop=true;
        GetComponent<AudioSource>().clip = musique2;
        GetComponent<AudioSource>().Play();
    }


}
