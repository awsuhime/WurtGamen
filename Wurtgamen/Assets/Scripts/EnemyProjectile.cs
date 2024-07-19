using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private SimplePlayer player;
    public int damage = 2;
    private GameObject playa;
    void Start()
    {
        playa = GameObject.Find("Playa");
        transform.LookAt(playa.transform.position);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            player = other.GetComponent<SimplePlayer>();
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
