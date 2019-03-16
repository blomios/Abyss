using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class titleButton : MonoBehaviour
{
    public GameObject boutton;
    public Texture btnTexture;

    void OnGUI()
    {
        if (GUI.Button(new Rect(boutton.transform.position.x, boutton.transform.position.y,200, 80), btnTexture))
        {
            SceneManager.LoadScene("AbyssJM0");
        }
    }
}
