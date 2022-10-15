using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public Flocking_Manager myManager;

    int num = 0;
    float speed = 0.0f;
    Vector3 direction = Vector3.zero;
    Vector3 separation = Vector3.zero;
    Vector3 align = Vector3.zero;
    Vector3 cohesion = Vector3.zero;
    Vector3 lider = Vector3.zero;
    float freq = 1.0f;
    float cFreq = 0.3f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation,
                                      Quaternion.LookRotation(direction),
                                      myManager.rotationSpeed * Time.deltaTime);
        transform.Translate(0.0f, 0.0f, Time.deltaTime * speed);
    }

    public void CalculateDirection()
    {
        Cohesion();
        Velocity();
        Separation();
        Lider();
        direction += cohesion * 10;
        direction += align;
        direction += separation * 0.2f;
        direction += lider;
        direction.Normalize();
        direction *= speed;
    }

    void Cohesion()
    {


        foreach (GameObject go in myManager.allFish)
        {
            if (go != this.gameObject)
            {
                float distance = Vector3.Distance(go.transform.position,
                                                  transform.position);
                if (distance <= myManager.neighbourDistance)
                {
                    cohesion += go.transform.position;
                    num++;
                    //Debug.Log(go);
                }
            }
        }
        if (num > 0)
            cohesion = (cohesion / num - transform.position).normalized * speed;
    }
    void Velocity()
    {

        foreach (GameObject go in myManager.allFish)
        {
            if (go != this.gameObject)
            {
                float distance = Vector3.Distance(go.transform.position,
                                                  transform.position);
                if (distance <= myManager.neighbourDistance)
                {
                    align += go.GetComponent<Flock>().direction;
                    num++;
                }
            }
        }
        if (num > 0)
        {
            align /= num;
            speed = Mathf.Clamp(align.magnitude, myManager.minSpeed, myManager.maxSpeed);

        }
    }
    void Separation()
    {

        foreach (GameObject go in myManager.allFish)
        {
            if (go != this.gameObject)
            {
                float distance = Vector3.Distance(go.transform.position,
                                                  transform.position);
                if (distance <= myManager.neighbourDistance)
                    separation -= (transform.position - go.transform.position) /
                                  (distance * distance);
            }
        }
    }

    void Lider()
    {
        lider += (myManager.lider.transform.position - transform.position).normalized;
    }
}
