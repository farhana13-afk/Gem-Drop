using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidePlane : MonoBehaviour
{
    // Start is called before the first frame update

    private SpawnGem spawn_script;
    private Menu menu_script; 
    public GameObject gemspawn; 
    public Canvas canva;

    public void OnTriggerEnter(Collider other)
     {
                //score
        if(other.gameObject.tag != "Player" && other.gameObject.tag != "Plane" && other.gameObject.tag == "good")
        {
            Destroy(other.gameObject, 0.5f );
            spawn_script.collide = true; 
            menu_script.dropped +=1; 
        }
        if(other.gameObject.tag != "Player" && other.gameObject.tag != "Plane" && other.gameObject.tag == "bad")
        {
            Destroy(other.gameObject, 0.5f);
            spawn_script.collide2 = true; 
        }
        
     }

     


    void Start()
    {
        spawn_script = gemspawn.GetComponent<SpawnGem>();
        menu_script = canva.GetComponent<Menu>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
