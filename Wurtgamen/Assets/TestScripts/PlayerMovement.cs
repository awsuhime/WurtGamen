using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float speed;
    public float pickupDistance = 2f;

    public LayerMask stoppa;

    private bool objectFound = false;
    public bool holding = false;
    private bool clearPlace = false;
    private GameObject heldObject;
    private Vector3 ghostPosition;
    private Pickup pickupScript;

    public GameObject[] pickups;
    private GameObject pickup;
    private float distance;
    float nearestDistance = 2f;

    Vector3 movement;
    Vector3 lookingSpot;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        float hori = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");

        movement = new Vector3(hori, 0, vert).normalized * speed;
        if (hori != 0 || vert != 0)
        {
            transform.LookAt(transform.position + movement);
            lookingSpot = movement * 7;
        }
        characterController.Move(movement);


    }
    private void Update()
    {
        if (holding)
        {
            heldObject.transform.position = new(transform.position.x, transform.position.y + heldObject.transform.localScale.y/2 + 2, transform.position.z);
            Vector3 roundedPosition = new Vector3(Mathf.Round(transform.position.x + lookingSpot.x), heldObject.transform.localScale.y / 2, Mathf.Round(transform.position.z + lookingSpot.z)) ;
            Collider[] hit = Physics.OverlapBox(roundedPosition, new(1f, heldObject.transform.localScale.y/2, 1f), Quaternion.identity, stoppa);
            if (hit.Length != 0)
            {
                for (int i = 0; i < hit.Length; i++)
                {
                    if (hit[i].gameObject == heldObject)
                    {
                        Debug.Log("Hit nullified; Name: " + hit[i].gameObject.name);
                        hit[i] = null;
                        

                    }
                    else
                    {
                        Debug.Log("Hit deteted; Name: " + hit[i].gameObject.name);
                    }

                }
            }

            if (hit.Length == 0)
            { 
            pickupScript.ghost.SetActive(true);

            pickupScript.ghost.transform.position = roundedPosition;
            clearPlace = true;
            
            }
            else
            {

                pickupScript.ghost.SetActive(false);
                clearPlace = false;
            }
            

            hit = null;

        }
        if (Input.GetKeyDown(KeyCode.R) && holding)
        {
            pickupScript.ghost.transform.Rotate(0, 90, 0);
        }
        if (Input.GetKeyDown(KeyCode.E) && !holding)
        {
            pickups = GameObject.FindGameObjectsWithTag("Pickup");
            for (int i = 0; i < pickups.Length; i++)
            {
                distance = Vector3.Distance(pickups[i].transform.position, transform.position);
                Debug.Log("Distance: " + distance);
                if (distance < nearestDistance)
                {
                    Debug.Log("Nearest: " + pickups[i].name);
                    nearestDistance = distance;
                    pickup = pickups[i];
                    objectFound = true;
                }
                
            }
            if (objectFound && nearestDistance < pickupDistance)
            {
                nearestDistance = 5f;
                objectFound = false;
                Debug.Log(pickup.name);
                holding = true;
                heldObject = pickup;
                pickupScript = heldObject.GetComponent<Pickup>();
            }

        }
        if (clearPlace && Input.GetKeyDown(KeyCode.E) && holding)
        {
                Debug.Log("Object placed down, object name: " + heldObject.name);
                heldObject.transform.position = pickupScript.ghost.transform.position;
            heldObject.transform.rotation = pickupScript.ghost.transform.rotation;
            
                holding = false;
                clearPlace = false;
                pickupScript.ghost.SetActive(false);
        }
    }
}
