using UnityEngine;
using System.Collections;

public class explosion : MonoBehaviour {
    public AudioClip[] soundExplode;
    public Animator anim;
    

    // Use this for initialization
    void Start () {
        Debug.Log("test");
        int sound = Random.Range(0, soundExplode.Length);
        GetComponent<AudioSource>().clip = soundExplode[sound];
        GetComponent<AudioSource>().Play();
        anim.Play("explosion");
        StartCoroutine(explode());
    }

    IEnumerator explode()
    {
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }
}
