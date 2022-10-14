using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flocking_Manager : MonoBehaviour
{
    public int numFish = 1;
    Vector3 VectorRand;
    public GameObject fishPrefab;
    public GameObject[] allFish;
    public float neighbourDistance = 1.0f;
    public float minSpeed = 1.0f;
    public float maxSpeed = 1.0f;
    public float rotationSpeed = 0.0f;
    float freq = 1.0f;
    float cFreq = 0.3f;
    public GameObject lider;

    // Start is called before the first frame update
    void Start()
    {
        Create();
    }

    // Update is called once per frame
    void Update()
    {
        freq += Time.deltaTime;
        if (freq > cFreq)
        {
            freq = 0.0f;
            foreach (GameObject go in allFish)
            {
                go.GetComponent<Flock>().CalculateDirection();
                Debug.Log("Si");
            }
        }

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