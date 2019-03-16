using UnityEngine;
using System.Collections;

public class spawn : MonoBehaviour 
{
	// Use this for initialization
    public int[] spawner;
    private float test;
   

	void Start () 
    {
        test = this.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (test != this.transform.position.x)
        {
            for (int i = 0; i < spawner.Length; i++)
            {
               EnemyManager.booleens[spawner[i]] = true;
            }
        }
	}
}
