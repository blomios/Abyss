using UnityEngine;
using System.Collections;

public class ennemyManagerlvl2 : MonoBehaviour {

    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 3f;            // How long between each spawn.
    public Transform[] spawnPoints;




    void Start()
    {
        StartCoroutine(Spawn());

    }

    void Update()
    {
    }

    IEnumerator Spawn()
    {
        for (int i = 1; i != 0; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                yield return new WaitForSeconds(3);

                // Find a random index between zero and one less than the number of spawn points.
                int spawnPointIndex = Random.Range(0, spawnPoints.Length);
                // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
                Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            }
            yield return new WaitForSeconds(5);
        }

    }
}
