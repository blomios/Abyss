using UnityEngine;
using System.Collections;

public class saveScene : MonoBehaviour {

    public static bool gameFinish=false;
    public static int currentScene = 1;


    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }


}
