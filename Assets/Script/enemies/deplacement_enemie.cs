/*a faire sur l'ennemie
 faire un rigidbody est cocher la case Z dans freeze rotation
 faire un circle collider2D et cocher "is Triger"
 faire une boxcollider2D*/ 

using UnityEngine;
using System.Collections;
using Pathfinding;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]

public class deplacement_enemie : MonoBehaviour
{

    private GameObject target;

    public float updateRate = 2f;

    private Seeker seeker;
    private Rigidbody2D rb;

    public Path path;

    public float speed = 300f;
    public ForceMode2D fMode;

    [HideInInspector]
    public bool pathIsEnded = false;

    public float nextWayPointDistance = 3;

    private int currentWaypoint = 0;

    void Start()
    {

        target = GameObject.Find("perso");
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        if (target == null)
        {
            return;
        }

        seeker.StartPath(transform.position, target.transform.position, OnPathComplete);

        StartCoroutine(UpdatePath());

    }

    IEnumerator UpdatePath()
    {
        if (target == null)
        {
            yield return false;
        }
        seeker.StartPath(transform.position, target.transform.position, OnPathComplete);
        yield return new WaitForSeconds(1f / updateRate);
        StartCoroutine(UpdatePath());
    }

    public void OnPathComplete (Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void FixedUpdate()
    {

        if (target == null)
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
        dir *= speed * Time.fixedDeltaTime;

        rb.AddForce(dir, fMode);

        float dist =Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
        if (dist < nextWayPointDistance)
        {
            currentWaypoint++;
            return;
        }
    }
}

