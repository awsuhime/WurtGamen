using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private SimplePlayer player;

    public int damage = 2;
    public bool variance = true;
    public float varRange = 10f;

    private GameObject playa;
    void Start()
    {
        playa = GameObject.Find("Playa");
        transform.LookAt(playa.transform.position);

        if (variance)
        {
            transform.Rotate(0, Random.Range(-varRange, varRange), 0);
        }
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
