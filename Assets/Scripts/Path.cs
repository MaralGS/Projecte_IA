using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Path : MonoBehaviour
{
    public List<Transform> vector3s;
    public GameObject target;
    public NavMeshAgent agent;
    public Transform current_target;
    private int n = 0;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        current_target.position = vector3s[n].position;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(agent.transform.position, current_target.position);
        if (distance < 0.5f)
        {
            n++;
            if (n >= 7)
            {
                n = 0;
            }
            //Debug.Log(n);
            current_target.position = vector3s[n].position;
           // Debug.Log(Vector3.Distance(agent.transform.position, current_target.position));

        }
        
        Seek(current_target.position);

        //agent.destination = vector3s.
    }
    void Seek(Vector3 position)
    {
        agent.destination = position;
    }
}