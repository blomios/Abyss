using UnityEngine;
using System.Collections;

public class videoManager : MonoBehaviour {

    public GameObject video1;
    public GameObject video2;
    private AudioSource audio;
    public AudioClip rouage;

    // Use this for initialization
    void Start () {
        Instantiate(video1, transform.position, transform.rotation);
        StartCoroutine(cd());
    }
	
	IEnumerator cd()
    {
        yield return new WaitForSeconds(26f);
        Instantiate(video2, transform.position, transform.rotation);
        audio = GetComponent<AudioSource>();
        GetComponent<AudioSource>().clip = rouage;
        audio.loop = true;
        audio.Play();
    }
}
