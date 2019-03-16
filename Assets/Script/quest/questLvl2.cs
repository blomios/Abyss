using UnityEngine;
using System.Collections;

public class questLvl2 : MonoBehaviour {

    public static int niveau = 1;

    public static bool quest1=false;
    public static bool quest2Go = false;
    public static bool quest3Go = false;
    public static bool quest4Go = false;
    public static bool quest5Go = false;
    public static bool quest6Go = false;

    public static bool quest1Ok = false;

    public static bool quest2Ok = false;

    public static bool quest3Ok = false;

    public static bool quest4Ok = false;

    public static bool quest5Ok = false;

    public static bool quest6 = false;

    public static bool quest6Ok = false;

    public static bool mineUsed = false;

    public static bool talkieTaked = false;

    public static bool KeyTaked = false;

    public static int destroyRobots = 0;
    public static int destroyLoader = 0;
    public static int mineLoot = 0;

    // Use this for initialization
    void Start () {

        niveau = 2;
        saveScene.currentScene = 2;

        quest1 = false;
        quest2Go = false;
        quest3Go = false;
        quest4Go = false;
        quest5Go = false;
        quest6Go = false;

        quest1Ok = false;

        quest2Ok = false;

        quest3Ok = false;

        quest4Ok = false;

        quest5Ok = false;

        quest6 = false;

        quest6Ok = false;

        mineUsed = false;
        talkieTaked = false;
        KeyTaked = false;
        destroyRobots = 0;
        destroyLoader = 0;
        mineLoot = 0;
}
	
	// Update is called once per frame
	void Update ()
    {
        if (destroyRobots >= 10)
        {
            quest1Ok = true;
            questBis.valide = true;
        }

        if (destroyLoader >= 8)
        {
            quest2Ok = true;
            questBis.valide = true;
        }

        if (mineLoot >= 2)
        {
            quest3Ok = true;
            questBis.valide = true;
        }
    }
}
