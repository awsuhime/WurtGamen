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
    public int guard = 0;
    public bool active = false;
    public float moveInterval = 1f;
    public float moveRange = 1f;
    public Material altMaterial;

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
        if (active)
        {
            StartCoroutine(move());
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
        if (guard == 0)
        {
            Debug.Log(health);
            health -= dam;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            guard -= 1;
            if (guard == 0)
            {
                meshRenderer.material = altMaterial;
            }
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

    System.Collections.IEnumerator move()
    {
        yield return new WaitForSeconds(moveInterval);
        transform.Translate(moveRange, 0, 0);
        moveRange *= -1;
        StartCoroutine(move());
    }
}
