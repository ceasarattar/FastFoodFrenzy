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
        public AudioClip pickUpSound; // Assign this in the Inspector
        public AudioClip dropSound; // Assign this in the Inspector
        private AudioSource audioSource;

        // Start is called before the first frame update
        void Start()
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            // Configure the AudioSource component
            audioSource.playOnAwake = false;
        }

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
            // Create a ray from the center of the screen
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            // Cast the ray and check if it hits anything within the pickup distance
            if (Physics.Raycast(ray, out hit, pickUpDistance))
            {
                // Check if the hit object has the "Pickable" tag
                if (hit.collider.gameObject.CompareTag("Pickable"))
                {
                    pickedUpObject = hit.collider.gameObject;
                    // Make the object a child of the player to follow the player's movement
                    pickedUpObject.transform.SetParent(transform);
                    // Adjust the position relative to the player
                    pickedUpObject.transform.localPosition = Vector3.forward; // Adjust this as needed
                    // Disable physics while the object is picked up
                    Rigidbody rb = pickedUpObject.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.isKinematic = true;
                    }
                    
                    // Play the pick-up sound
                    audioSource.PlayOneShot(pickUpSound);
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
                
                // Play the drop sound
                audioSource.PlayOneShot(dropSound);

                // Clear the reference
                pickedUpObject = null;
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
                captionText.text = "Press 'E' to pick up"; // Clear the caption when not holding anything
            }
        }
    }