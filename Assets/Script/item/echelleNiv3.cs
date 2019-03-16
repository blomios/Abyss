using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class echelleNiv3 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        {
            if (other.tag == "Joueur")
            {
                    SceneManager.LoadScene("niveau3");
            }
        }
    }
}
