using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {


    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 60, Screen.height / 2 + -30, 100, 40), "Recommencer"))
        {
            SceneManager.LoadScene("AbyssJM0");
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 60, Screen.height / 2 + 30, 100, 40), "quitter"))
        {
            Application.Quit();
        }
    }
}
