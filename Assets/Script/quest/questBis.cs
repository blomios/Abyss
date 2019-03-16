using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class questBis : MonoBehaviour {

    public static string quete;        // The player's score.
    public static bool valide = false;


    Text text;                      // Reference to the Text component.


    void Awake()
    {
        // Set up the reference.
        text = GetComponent<Text>();
    }


    void Update()
    {
        // Set the displayed text to be the word "Score" followed by the score value.
        text.text = quete;
    }
}
