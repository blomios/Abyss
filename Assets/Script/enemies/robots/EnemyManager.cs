using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
	public GameObject enemy;                // The enemy prefab to be spawned.
	public float spawnTime = 3f;            // How long between each spawn.
	public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    public Transform[] Points;
    public static bool[] booleens;
	



	void Start ()
	{
        booleens = new bool[spawnPoints.Length];
        booleens[7] = true;
        booleens[8] = true;

			// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		StartCoroutine(Spawn());

	}

    void Update()
    {
        int j = 0;
        for (int i = 0; i < booleens.Length; i++)
        {
            if (booleens[i] == true)
            {
                j++;
            }
        }

        Points = new Transform[j];
        j = 0;
        for (int i = 0; i < booleens.Length; i++)
        {
            if(booleens[i]==true)
            {
               Points[j] = spawnPoints[i];
               j++;
            }
        }
    }

	IEnumerator Spawn ()
	{
		for (int i = 1; i !=0; i++) {
			for (int j = 0; j <10; j++) {
				yield return new WaitForSeconds (3);
		
				// Find a random index between zero and one less than the number of spawn points.
				int spawnPointIndex = Random.Range (0, Points.Length);
				// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
                Instantiate(enemy, Points[spawnPointIndex].position, Points[spawnPointIndex].rotation);
			}
			yield return new WaitForSeconds (5);
		}
		
	}
}
