using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    private float speed;

     Vector3 move; 

     float xRange; 
     float zRange; 
    private SpawnGem spawn_script;
    private Menu menu_script; 
    public GameObject gemspawn; 
    public Canvas canva;

     public void OnTriggerEnter(Collider other)
     {
        //score when it collides with paddle

        //good 
        if(other.gameObject.tag != "Plane" && other.gameObject.tag == "good")
        {
            Destroy(other.gameObject, 0.5f);
            spawn_script.collide = true; 
            menu_script.score += 1;   
        }
        
        //bad
        if(other.gameObject.tag != "Plane" && other.gameObject.tag == "bad")
        {
            Destroy(other.gameObject, 0.5f);
            spawn_script.collide2 = true; 
            menu_script.score -= 1;     
        }
     }


    // Start is called before the first frame update
    void Start()
    {
        speed = 15f;

        spawn_script = gemspawn.GetComponent<SpawnGem>();
        menu_script = canva.GetComponent<Menu>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //player movement
        move.x = Input.GetAxis("Horizontal");
        move.z = Input.GetAxis("Vertical");

        //bounds
        xRange = transform.position.z + 5.5f;
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        zRange = 8;
        if(transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
        if(transform.position.z < 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }
    public void FixedUpdate()
    {
        //add force
        gameObject.GetComponent<Rigidbody>().AddForce(move*speed); 

    }
}
