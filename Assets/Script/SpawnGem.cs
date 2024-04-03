using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGem : MonoBehaviour
{

    public GameObject gemObject; 
    public GameObject badObject; 
    public bool collide2; 
    public bool collide; 

    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //spawning with bounds

        //good
        if(collide)
        {
            float num = Random.Range(0,8);
            Vector3 randomPosition = new Vector3(Random.Range(-(num+5.5f), num+5.5f), 20f, num);
            Instantiate(gemObject, randomPosition, Quaternion.identity);
            collide = false;
        }

        //bad
        if(collide2)
        {
            float num = Random.Range(0,8);
            Vector3 randomPosition = new Vector3(Random.Range(-(num+5.5f), num+5.5f), 20f, num);
            Instantiate(badObject, randomPosition, Quaternion.identity);
            collide2 = false;
        }
    }



}
