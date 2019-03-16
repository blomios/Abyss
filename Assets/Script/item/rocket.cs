using UnityEngine;
using System.Collections;

public class rocket : MonoBehaviour {

    public GameObject explosion;
    public GameObject degats;
    public bool canExplode = false;
    private GameObject perso;

    // Use this for initialization
    void Start () 
    {
        perso = GameObject.Find("perso");
        StartCoroutine(cdExplode());
	}

    // Update is called once per frame
    void Update()
    {
        Vector2 tir = perso.transform.position - transform.position;
        float ang = Vector2.Angle(new Vector2(1, 0), tir);
        if (perso.transform.position.y < transform.position.y)
            ang = -ang;
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, ang - 90));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "degats" && other.tag != "table" && canExplode ==true)
        {
            Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
            Instantiate(degats, transform.position, randomRotation);
            Instantiate(explosion, transform.position, randomRotation);
            Destroy(gameObject);
        }

    }

    IEnumerator cdExplode()
    {
        yield return new WaitForSeconds(1);
        canExplode = true;
    }
}
