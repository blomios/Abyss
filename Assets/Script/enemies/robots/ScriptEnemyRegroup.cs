using UnityEngine;
using System.Collections;
using Pathfinding;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]

public class ScriptEnemyRegroup : MonoBehaviour {

    private int enemyType;

    public Rigidbody2D balle_ennemi;
    public float speedCac = 20f;
    public float speedTir = 20f;
    public float speedDist = 20f;
    public bool detection = false;
    int timer = 0;
    public float distanceDetectDist = 999f;
    public float distanceDetect = 10f;
    public GameObject explosion;
    public AudioClip[] priseDegats;
    public AudioClip priseDegatsJoueur;
    public AudioClip soundTir;

    private GameObject joueur;
    public bool attaque = true;

    public float updateRateCac = 2f;
    public float updateRateDist = 2f;

    private Seeker seeker;
    private Rigidbody2D rb;

    public Path path;
    public ForceMode2D fMode;

    [HideInInspector]
    public bool pathIsEnded = false;

    public float nextWayPointDistanceCac = 3;
    public float nextWayPointDistanceDist = 3;

    private int currentWaypoint = 0;
    public GameObject Medkit; //objet Medkit
    public GameObject Pile; //objet Medkit


    public int pointsPerBalle = 20;  //Nombre de points de vie perdu en prenant une balle.
    public int pointsPerBaril = 80;
    public int scoreValue = 1;


    public int vie;                            //Vie de l'ennemi.
    public int vie_maxCac = 100;
    public int vie_maxDist = 100; //Vie totale de l'ennemi.

    private Vector3 temp;
    public SpriteRenderer enemisCac;
    public Sprite gaucheCac;
    public Sprite droitCac;
    public Sprite hautCac;
    public Sprite basCac;
    public SpriteRenderer enemisDist;
    public Sprite gaucheDist;
    public Sprite droitDist;
    public Sprite hautDist;
    public Sprite basDist;
    private Vector3 now;
    private Vector3 difPos; //Va voir les changements de position sur les axes x y et z
    private Vector3 dif; //Va garder les negativité pour savoir dans quel sens on s'est deplacé sur chaque axe
    private bool first = true;

    // Use this for initialization
    void Start () {
        
        rb = GetComponent<Rigidbody2D>();

        double chance = Random.value;
        if (chance >= 0.4)
        {
            vie = vie_maxCac;
            enemyType = 0;
        }
        else
        {
            vie = vie_maxDist;
            enemyType = 1;
        }

        StartCoroutine(refresh(enemyType));
        joueur = GameObject.Find("perso");
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        if (joueur == null)
        {
            return;
        }

        seeker.StartPath(transform.position, joueur.transform.position, OnPathComplete);

        StartCoroutine(UpdatePath());



        if (enemyType == 1)
        {
            StartCoroutine(timerFunction());
        }


    }

    // Update is called once per frame
    void Update()
    {

        if (enemyType == 0)
        {
            if (joueur)
            {
                float sqrLen = (joueur.transform.position - transform.position).sqrMagnitude;
                if (sqrLen < distanceDetectDist * distanceDetectDist)
                {
                    detection = true;
                    timer++;
                }
                else detection = false;

            }
            if (timer >= 100 && detection == true)
            {
                tir();
                timer = 0;
            }
        }



        else
        {
            if (joueur)
            {
                float sqrLen = (joueur.transform.position - transform.position).sqrMagnitude;
                if (sqrLen < 50)
                {
                    detection = true;
                }
                else detection = false;

            }

            if (attaque == true && detection == true)
            {
                //Actualisation de la vie du joueur.
                attaque = false;
                GetComponent<AudioSource>().clip = priseDegatsJoueur;
                GetComponent<AudioSource>().Play();
                perso.vie -= 20;

                //On vérifie si le jeu est terminé.
                if (perso.vie <= 0)
                {

                    SceneManager.LoadScene("GameOver");
                }
            }
        }




    }

    public void tir()
    {

        Vector2 tir = joueur.transform.position - transform.position;
        float ang = Vector2.Angle(new Vector2(1, 0), tir);
        if (joueur.transform.position.y < transform.position.y)
            ang = -ang;
        Rigidbody2D bulletInstance = Instantiate(balle_ennemi, transform.position, Quaternion.Euler(new Vector3(0, 0, ang - 90))) as Rigidbody2D;
        bulletInstance.velocity = speedTir * tir.normalized;
        GetComponent<AudioSource>().clip = soundTir;
        GetComponent<AudioSource>().Play();
    }

    IEnumerator timerFunction()
    {
        if (attaque == false)
        {
            yield return new WaitForSeconds(1.5f);
            attaque = true;
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(timerFunction());
    }

    IEnumerator UpdatePath()
    {
        if (joueur == null)
        {
            //TODO: player search ici
            yield return false;
        }
        seeker.StartPath(transform.position, joueur.transform.position, OnPathComplete);
        if (enemyType==0) yield return new WaitForSeconds(1f / updateRateDist);
        else yield return new WaitForSeconds(1f / updateRateCac);
        StartCoroutine(UpdatePath());
    }

    public void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }


    void FixedUpdate()
    {

        if (joueur == null)
        {
            //TODO: player search ici
            return;
        }

        if (path == null)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
            {
                return;
            }
            pathIsEnded = true;
            return;
        }
        pathIsEnded = false;
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        if (enemyType==0) dir *= speedDist * Time.fixedDeltaTime;
        else dir *= speedCac * Time.fixedDeltaTime;

        rb.AddForce(dir, fMode);

        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
        if (enemyType == 0)
        {
            if (dist < nextWayPointDistanceDist)
            {
                currentWaypoint++;
                return;
            }
        }
        else
        {
            if (dist < nextWayPointDistanceCac)
            {
                currentWaypoint++;
                return;
            }
        }
    }

    //On lance cette fonction dès qu'il y a collision.
    private void OnTriggerEnter2D(Collider2D other)
    {
        //On vérifie si l'ennemi a touché une balle.

        if (other.tag == "balle_j")
        {
            //On détruit la balle.
            other.gameObject.SetActive(false);

            //On appel la fonction de perte de vie.
            LoseVie(pointsPerBalle);
        }

        if (other.tag == "explosionBaril")
        {
            LoseVie(pointsPerBaril);
        }

        if (other.tag == "explosionMine")
        {
            LoseVie(pointsPerBaril);
        }

        if (other.tag == "vide")
        {
            vie = 0;
            CheckIfDied();
        }
    }


    //Losevie est appelé quand un ennemi est attaqué.
    //Il contient le parametre loss qui est la vie perdue lors de l'attaque.
    public void LoseVie(int loss)
    {
        //Actualisation de la vie de l'ennemi.
        int sound = Random.Range(0, priseDegats.Length);
        vie -= loss;
        GetComponent<AudioSource>().clip = priseDegats[sound];
        GetComponent<AudioSource>().Play();

        //On vérifie si l'ennemi est mort.
        CheckIfDied();
    }

    //CheckIfDied vérifie la vie de l'ennemi, si il n'en a plus, mort de l'ennemi et peut être spawn d'un Medkit.
    private void CheckIfDied()
    {
        //Vérifie si la vie est inférieure ou égale à 0.
        if (vie <= 0)
        {
            if (questLvl2.quest1 == true && questLvl2.quest1Ok == false)
            {
                questLvl2.destroyRobots += 1;
                Debug.Log(questLvl2.destroyRobots);
            }
            ScoreManager.score += scoreValue;
            double chance = Random.value; //on créer un random entre 0.0 et 1.0.
            if (chance > 0.6f) Instantiate(Medkit, transform.position, transform.rotation);
                 Destroy(gameObject);
            if (chance <= 0.5f && questLvl2.niveau==1) Instantiate(Pile, transform.position, transform.rotation);
                Destroy(gameObject);
            Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
            Instantiate(explosion, transform.position, randomRotation);
        }
    }

    IEnumerator refresh(int enemyType )
    {


        yield return new WaitForSeconds(0.2f);

        if (first == true)
        {
            first = false;
            temp = transform.position;
        }
        else
        {
            now = transform.position;

            if (temp.x > 0)
            {
                if (now.x > 0)
                {
                    dif.x = (temp.x) * (-1) + now.x;
                }
                else dif.x = temp.x - now.x;
            }

            else
            {
                if (now.x > 0)
                {
                    dif.x = (temp.x) * (-1) + now.x;
                }
                else
                {
                    dif.x = (temp.x) * (-1) + now.x;
                }
            }

            if (temp.y > 0)
            {
                if (now.y > 0)
                {
                    dif.y = (temp.y) * (-1) + now.y;
                }
                else dif.y = temp.y - now.y;
            }

            else
            {
                if (now.x > 0)
                {
                    dif.y = (temp.y) * (-1) + now.y;
                }
                else
                {
                    dif.y = (temp.y) * (-1) + now.y;
                }
            }


            //On change les sprites en fonction de l'orientation du mob (par rapport a son dernier deplacement)
            
            if (dif.x > dif.y)
            {
                if (dif.x > 0)
                {
                    //Le mob se deplace vers la droite
                    if (enemyType == 0)
                    {
                        GetComponent<SpriteRenderer>().sprite = droitDist;
                    }
                    else GetComponent<SpriteRenderer>().sprite = droitCac;
                }
                else
                {
                    //Le mob se deplace vers la gauche
                    if (enemyType==0) GetComponent<SpriteRenderer>().sprite = gaucheDist;
                    else GetComponent<SpriteRenderer>().sprite = gaucheCac;
                }
            }
            else
            {
                if (dif.y > 0)
                {
                    //Le mob se deplace vers le haut
                    if(enemyType==0) GetComponent<SpriteRenderer>().sprite = hautDist;
                    else GetComponent<SpriteRenderer>().sprite = hautCac;
                }
                else
                {
                    //Le mob se deplace vers le bas
                    if (enemyType==0) GetComponent<SpriteRenderer>().sprite = basDist;
                    else GetComponent<SpriteRenderer>().sprite = basCac;
                }
            }

            temp = now;
        }
        StartCoroutine(refresh(enemyType));
    }
}
