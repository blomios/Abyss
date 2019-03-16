using UnityEngine;
using System.Collections;

public class bosse : MonoBehaviour {

    public static bool isProtected = true;
    public GameObject artefact;
    public static bool presentShield = true;
    public GameObject rocket;
    public GameObject explosion;
    public GameObject bouclier;
    public AudioClip[] priseDegats;
    public AudioClip upBoss;
    public GameObject blocMissil;
    private int phase=1;
    public int cdRocket;
    public int degatBalle;
    public int vie;
    public int vieMax;
    private GameObject perso;
    public GameObject EnemySpawn;



    // Use this for initialization
    void Start ()
    {
        isProtected = true;
        presentShield = false;
        EnemySpawn.gameObject.SetActive(false);
        perso = GameObject.Find("perso");
        vie = vieMax;
        StartCoroutine(cycleRocket());
	}
	
	// Update is called once per frame
	void Update () {

        if (isProtected == true && presentShield==false)
        {
            presentShield = true;
            bouclier.gameObject.SetActive(true);
           
        }

        else if(isProtected==false && presentShield == true)
        {
            bouclier.gameObject.SetActive(false);
            presentShield = false;
            StartCoroutine(cycleShield());
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "balle_j")
        {
            other.gameObject.SetActive(false);
            if (isProtected == false)
            {
                LoseVie(degatBalle);
            }
        }

        if (other.tag == "explosionMine")
        {
            LoseVie(60);
        }

        if (other.tag == "explosionBaril")
        {
            LoseVie(70);
        }
    }

    public void LoseVie(int loss)
    {

        //Actualisation de la vie du joueur.
        vie -= loss;
        int sound = Random.Range(0, priseDegats.Length);
        GetComponent<AudioSource>().clip = priseDegats[sound];
        GetComponent<AudioSource>().Play();

        //On vérifie si le jeu est terminé.
        CheckIfDied();
    }

    private void CheckIfDied()
    {
        //Vérifie si la vie est inférieure ou égale à 0.
        if (vie <= 0)
        {
            if (phase == 1)
            {
                phase = 2;
                vie = vieMax;
                quest.quete = "Talkie: Il rentre en seconde phase ! Il commence a s'enerver... Fais gaffe !";
                alarme.alarmeUp = true;
            }
            else
            {
                EnemySpawn.gameObject.SetActive(true);
                Instantiate(artefact, transform.position, transform.rotation);
                Destroy(gameObject);
                quest.quete = "Talkie: Là !! L'artefact !! Detruit le !!";
                Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
                Instantiate(explosion, transform.position, randomRotation);
            }

        }
    }

    IEnumerator cycleRocket()
    {
        yield return new WaitForSeconds(cdRocket);


        Vector2 tir = perso.transform.position - transform.position;
        float ang = Vector2.Angle(new Vector2(1, 0), tir);
        if (perso.transform.position.y < transform.position.y)
            ang = -ang;
        Instantiate(rocket, blocMissil.transform.position, Quaternion.Euler(new Vector3(0, 0, ang - 90)));

        if (phase == 2)
        {
            yield return new WaitForSeconds(1);
            tir = perso.transform.position - transform.position;
            ang = Vector2.Angle(new Vector2(1, 0), tir);
            if (perso.transform.position.y < transform.position.y)
                ang = -ang;
            Instantiate(rocket, blocMissil.transform.position, Quaternion.Euler(new Vector3(0, 0, ang - 90)));
        }


        StartCoroutine(cycleRocket());
    }

    IEnumerator cycleShield()
    {
        yield return new WaitForSeconds(3);
        isProtected = true;
    }
}
