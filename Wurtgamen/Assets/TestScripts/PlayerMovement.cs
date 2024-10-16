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
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !holding)
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
                objectFound = false;
                Debug.Log(pickup.name);
                holding = true;
                heldObject = pickup;
                pickupScript = heldObject.GetComponent<Pickup>();
            }

        }
        if (holding)
        {
            heldObject.transform.position = new (transform.position.x, transform.position.y + 12, transform.position.z);
            Vector3 roundedPosition = new Vector3 (Mathf.Round(transform.position.x), transform.position.y, Mathf.Round(transform.position.z));
            Collider[] hit = Physics.OverlapSphere(roundedPosition, .1f, stoppa);
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
            if (clearPlace && Input.GetKeyDown(KeyCode.Space))
            {
                heldObject.transform.position = ghostPosition;
                holding = false;
                clearPlace = false;

            }
            hit = null;
            
        }
    }

    void FixedUpdate()
    {
        float hori = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");

        movement = new Vector3(hori, 0, vert).normalized * speed;
        characterController.Move(movement);

        
    }
}
