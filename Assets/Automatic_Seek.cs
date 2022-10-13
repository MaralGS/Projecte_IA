using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Automatic_Seek : MonoBehaviour
{

    public GameObject target;
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Seek();
    }
    void Seek()
    {
        agent.destination = target.transform.position;
    }
}