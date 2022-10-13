using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flocking_Manager : MonoBehaviour
{
    public int numFish = 25;
    Vector3 VectorRand;
    public GameObject fishPrefab;
    public GameObject[] allFish;
    public float neighbourDistance = 5f;
    public float minSpeed = 1.0f;
    public float maxSpeed = 5.0f;
    public float rotationSpeed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Create();
    }

    // Update is called once per frame
    void Update()
    {

    
    }
    void Create() 
    {
        allFish = new GameObject[numFish];
        for (int i = 0; i < numFish; ++i)
        {
            VectorRand = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), Random.Range(-3, 3));
            Vector3 pos = this.transform.position + VectorRand; // random position
            Vector3 randomize = VectorRand; // random vector direction
            allFish[i] = (GameObject)Instantiate(fishPrefab, pos,
                                Quaternion.LookRotation(randomize));
            allFish[i].GetComponent<Flock>().myManager = this;
        }
    }
}