using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class quest : MonoBehaviour
{
    public static string quete;        // The player's score.
    public static int caisse;


    Text text;                      // Reference to the Text component.


    void Awake()
    {
        // Set up the reference.
        caisse = 0;
        text = GetComponent<Text>();
    }


    void Update()
    {
        // Set the displayed text to be the word "Score" followed by the score value.
        text.text = quete;
    }
}
