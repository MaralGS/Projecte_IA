using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour
{
    public GameObject target;
    public float turnSpeed;
    public float movSpeed;
    public float turnAcceleration = 1;
    public float acceleration = 5;
    public float maxSpeed = 100;
    public float maxTurnSpeed = 100;
    public float stopDistance = 3;
    float freq = 0f;
    Quaternion rotation;
    Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.transform.position, transform.position) <
       stopDistance) return;


        freq += Time.deltaTime;
        if (freq > 0.5)
        {
            Debug.Log("Dins");
            freq -= 0.5f;
            Seek_1();
        }
        // Update commands

        turnSpeed += turnAcceleration * Time.deltaTime;
        turnSpeed = Mathf.Min(turnSpeed, maxTurnSpeed);
        movSpeed += acceleration * Time.deltaTime;
        movSpeed = Mathf.Min(movSpeed, maxSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation,
                                              rotation, Time.deltaTime * turnSpeed);
        transform.position += transform.forward.normalized * movSpeed *
                              Time.deltaTime;
    }
    public void Seek_1()
    {
        Vector3 direction = target.transform.position - transform.position;
        direction.y = 0f;
        movement = direction.normalized * acceleration;
        float angle = Mathf.Rad2Deg * Mathf.Atan2(movement.x, movement.z);
        rotation = Quaternion.AngleAxis(angle, Vector3.up);
    }
}