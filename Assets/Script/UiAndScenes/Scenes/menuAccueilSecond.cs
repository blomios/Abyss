using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class menuAccueilSecond : MonoBehaviour
{
    public MovieTexture movie;
    private AudioSource audio;
    public AudioClip rouage;

    // Use this for initialization
    void Start()
    {
        GetComponent<RawImage>().texture = movie as MovieTexture;
        audio = GetComponent<AudioSource>();
        GetComponent<AudioSource>().clip = rouage;
        audio.clip = movie.audioClip;
        movie.loop=true;
        audio.loop = true;
        movie.Play();
        audio.Play();
    }
}
