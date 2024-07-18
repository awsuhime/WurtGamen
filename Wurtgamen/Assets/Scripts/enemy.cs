using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int health = 10;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void takeDamage(int dam)
    {
        Debug.Log(health);
        health -= dam;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
