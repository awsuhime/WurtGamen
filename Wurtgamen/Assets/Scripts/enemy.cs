using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int health = 10;
    private MeshRenderer meshRenderer;
    public bool ranged = false;
    public float fireRate = 1f;
    public float stopRange = 20f;
    public GameObject projectile;
    private MovingObject movingObject;
    
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        movingObject = GetComponent<MovingObject>();
        if (ranged)
        {
            StartCoroutine(fire());
        }
        
    }

    void Update()
    {
       if (ranged && movingObject.movable && transform.position.z <= stopRange)
        {
            movingObject.movable = false;
        }
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

    public void Glow(int dam)
    {
        if (dam >= health)
        {
            meshRenderer.material.EnableKeyword("_EMISSION");
        }
    }

    public void deGlow()
    {
        meshRenderer.material.DisableKeyword("_EMISSION");
    }

    System.Collections.IEnumerator fire()
    {
        yield return new WaitForSeconds(fireRate);
        Instantiate(projectile, transform.position, Quaternion.identity);
        StartCoroutine(fire());
        
    }
}
