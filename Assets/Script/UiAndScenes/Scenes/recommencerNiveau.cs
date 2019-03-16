using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class recommencerNiveau : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void onClick()
    {
        if (saveScene.currentScene == 1) SceneManager.LoadScene("AbyssJM0");

        if (saveScene.currentScene == 2) SceneManager.LoadScene("niveau2");

        if (saveScene.currentScene == 3) SceneManager.LoadScene("niveau3");
    }
}
