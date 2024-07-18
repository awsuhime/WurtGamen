using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using TMPro;
public class ShootingPlayer : MonoBehaviour
{
    public GameObject[] projectile;

    public float heldStart;
    private int charge;
    private bool charging;
    public int ammo = 10;
    public int maxAmmo = 10;
    private int heldAmmo;
    public float reloadRate = .4f;
    public float chargeInt = .6f;

    public bool shootable = true;
    public bool reloadable = true;
    public TextMeshProUGUI ammoText;
    private enemy[] enemies;
    void Start()
    {
        StartCoroutine(Reload());
        ammoText.text = ("Ammo: " + ammo);
    }
                  
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && shootable)
        {
            if (ammo >= 1)
            {
                heldStart = Time.time;
                charging = true;
                charge = 0;
                heldAmmo = ammo;
                ammo -= 1;
                ammoText.text = ("Ammo: " + ammo);
            }
            
            
        }
        if (charging)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                Instantiate(projectile[charge], transform.position, transform.rotation);
                enemies = FindObjectsOfType<enemy>();
                for (int i = 0; i < enemies.Length; i++)
                {
                    enemies[i].deGlow();
                }
                charging = false;

            }
            else if (Time.time - heldStart > chargeInt * 5)
            {
                if (ammo >= 1 && charge < 5)
                {
                    charge = 5;
                    ammo = heldAmmo - 6;
                    enemies = FindObjectsOfType<enemy>();
                    for (int i = 0; i < enemies.Length; i++)
                    {
                        enemies[i].Glow(13);
                    }
                }
                
            }
            else if (Time.time - heldStart > chargeInt * 4)
            {
                if (ammo >= 1 && charge < 4)
                {
                    charge = 4;
                    ammo = heldAmmo - 5;
                    enemies = FindObjectsOfType<enemy>();
                    for (int i = 0; i < enemies.Length; i++)
                    {
                        enemies[i].Glow(9);
                    }
                }
            }
            else if (Time.time - heldStart > chargeInt * 3)
            {
                if (ammo >= 1 && charge < 3)
                {
                    charge = 3;
                    ammo = heldAmmo - 4;
                    enemies = FindObjectsOfType<enemy>();
                    for (int i = 0; i < enemies.Length; i++)
                    {
                        enemies[i].Glow(6);
                    }
                }
            }
            else if (Time.time - heldStart > chargeInt * 2)
            {
               if (ammo >= 1 && charge < 2)
                {
                    charge = 2;
                    ammo = heldAmmo - 3;
                    enemies = FindObjectsOfType<enemy>();
                    for (int i = 0; i < enemies.Length; i++)
                    {
                        enemies[i].Glow(4);
                    }
                }
            }
            else if(Time.time - heldStart > chargeInt)
            {
                if (ammo >= 1 && charge < 1)
                {
                    charge = 1;
                    ammo = heldAmmo - 2;
                    enemies = FindObjectsOfType<enemy>();
                    for (int i = 0; i < enemies.Length; i++)
                    {
                        enemies[i].Glow(2);
                    }

                }
            }
            ammoText.text = ("Ammo: " + ammo);
        }

    }

    System.Collections.IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadRate);
        if (!charging && reloadable && ammo < maxAmmo)
        {

            ammo += 1;
            Debug.Log("ammo " + ammo);
            ammoText.text = ("Ammo: " + ammo);
        }
        StartCoroutine(Reload());
    }
 
}
