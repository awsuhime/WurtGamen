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

    public TextMeshProUGUI ammoText;
    void Start()
    {
        StartCoroutine(Reload());
        ammoText.text = ("Ammo: " + ammo);
    }
                  
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
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
                
                charging = false;

            }
            else if (Time.time - heldStart > 2.5)
            {
                if (ammo >= 1)
                {
                    charge = 5;
                    ammo = heldAmmo - 6;
                }
                
            }
            else if (Time.time - heldStart > 2f)
            {
                if (ammo >= 1)
                {
                    charge = 4;
                    ammo = heldAmmo - 5;
                }
            }
            else if (Time.time - heldStart > 1.5)
            {
                if (ammo >= 1)
                {
                    charge = 3;
                    ammo = heldAmmo - 4;
                }
            }
            else if (Time.time - heldStart > 1f)
            {
               if (ammo >= 1)
                {
                    charge = 2;
                    ammo = heldAmmo - 3;
                }
            }
            else if(Time.time - heldStart > .5)
            {
                if (ammo >= 1)
                {
                    charge = 1;
                    ammo = heldAmmo - 2;
                }
            }
            ammoText.text = ("Ammo: " + ammo);
        }

    }

    System.Collections.IEnumerator Reload()
    {
        yield return new WaitForSeconds(.5f);
        if (!charging && ammo < maxAmmo)
        {

            ammo += 1;
            Debug.Log("ammo " + ammo);
            ammoText.text = ("Ammo: " + ammo);
        }
        StartCoroutine(Reload());
    }
 
}
