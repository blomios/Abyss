using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Teleportation : MonoBehaviour {

    public string scene;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Joueur")
        {
            SceneManager.LoadScene(scene);
        }
    }
}
