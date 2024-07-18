using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float speed = 5f;
    public float lifeTime = 9f;
    private float startTime;
    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if(Time.time - startTime > lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
