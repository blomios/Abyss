using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class interact : MonoBehaviour {

    public static string interacted;        // The player's score.


    Text text;                      // Reference to the Text component.


    void Awake()
    {
        // Set up the reference.
        text = GetComponent<Text>();
    }


    void Update()
    {
        // Set the displayed text to be the word "Score" followed by the score value.
        text.text = interacted;
    }
}
