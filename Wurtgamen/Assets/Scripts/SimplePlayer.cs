using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayer : MonoBehaviour
{
    public int speed = 5;
    public bool movable = true;


    
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

    
    
}
