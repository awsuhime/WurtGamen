using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayer : MonoBehaviour
{
    public int speed = 5;
    public bool movable = true;
    public int health = 100;

    
    private void Start()
    {
        
    }
    void Update()
    {
        if (movable)
        {
            transform.Translate(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0, 0);

        }
    }

    public void TakeDamage(int dam)
    {
        health -= dam;
        Debug.Log("Health: " + health);
        if (health <= 0)
        {
            Debug.Log("GAME OVER LOLLWDOWA<");
        }
    }

    
    
}
