using UnityEngine;
using System.Collections;

public class pointeur : MonoBehaviour
{
   
    public Vector3 posMouse;
    public float velocity = 5f;



    private void Start()
    {
        Cursor.visible = false;
    }


    // Update is called once per frame
    void Update()
    {
        
        posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        posMouse.z = 0;
        this.transform.position = posMouse;
    }

}

