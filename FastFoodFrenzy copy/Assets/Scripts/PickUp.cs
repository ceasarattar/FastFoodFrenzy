using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickUp : MonoBehaviour
{
    public float pickUpDistance = 2f; // Distance within which the player can pick up objects
    public KeyCode pickUpKey = KeyCode.E; // Key to pick up and drop objects
    private GameObject objectToPickUp = null; // Reference to the object that can be picked up
    private GameObject pickedUpObject = null; // Reference to the currently picked up object, if any
    public TextMeshProUGUI captionText;
 
    // Update is called once per frame
    void Update()
    {
        // Check if the player has pressed the pick-up key
        if (Input.GetKeyDown(pickUpKey))
        {
            // Attempt to pick up or drop the object
            if (pickedUpObject == null)
            {
                TryPickUpObject();
            }
            else
            {
                DropObject();
            }
        }
        UpdateCaption();
    }

    private void TryPickUpObject()
    {
        // Detect objects around the player
        Collider[] colliders = Physics.OverlapSphere(transform.position, pickUpDistance);
        foreach (var collider in colliders)
        {
            // Check if the object is tagged as "Pickable"
            if (collider.gameObject.CompareTag("Pickable"))
            {
                // Pick up the object
                pickedUpObject = collider.gameObject;
                // Optionally, make the object a child of the player to follow the player's movement
                pickedUpObject.transform.SetParent(transform);
                // Adjust the position relative to the player
                pickedUpObject.transform.localPosition = Vector3.forward; // Adjust this as needed
                // Disable physics while the object is picked up
                Rigidbody rb = pickedUpObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = true;
                }
                
                break; // Exit the loop after picking up an object
            }
        }
    }

    private void DropObject()
    {
        if (pickedUpObject != null)
        {
            // Re-enable physics
            Rigidbody rb = pickedUpObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
            }
            // Detach the object from the player
            pickedUpObject.transform.SetParent(null);
            pickedUpObject = null; // Clear the reference
            
        }
    }

    private void UpdateCaption()
    {
        if (pickedUpObject != null)
        {
            captionText.text = "Holding: " + pickedUpObject.name; // Update the caption with the name of the held object
        }
        else
        {
            captionText.text = ""; // Clear the caption when not holding anything
        }
    }


}
