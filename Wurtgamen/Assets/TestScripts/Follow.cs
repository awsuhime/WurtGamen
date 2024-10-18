using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new (player.transform.position.x, player.transform.position.y + 10, player.transform.position.z - 10);
    }
}
