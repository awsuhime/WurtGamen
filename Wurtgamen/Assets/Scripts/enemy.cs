using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int health = 10;
    private MeshRenderer meshRenderer;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
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
}
