using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This component is for all object that the player can 
    interact with such as enemies, items etc. It is meant
    to be used as a base class.
 */

public class Interactable : MonoBehaviour
{
    public float radius = 3f; // How close do we need to be to interact
    public Transform interactionTransform; // The transform from where we interact

    bool isFocus = false; // Is this interactable currently being focused?
    Transform player; // Reference to the player transform

    bool hasInteracted = false; // Have we already interacted with the object?

    public virtual void Interact() // calling the Interact() can trigger this method
    {
        // this method is meant to be overwritten
        //Debug.Log("Interacting with " + transform.name);
    }

    void Update()
    {
        // If we are currently being focused
        // and we haven't already interacted with the object
        if (isFocus && !hasInteracted)
        {
            // if we are close enough
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if(distance <= radius)
            {
                // Interact with the object
                //Debug.Log("INTERACT");
                Interact();
                hasInteracted = true;
            }
        }
    }

    // Called when the object starts being focused
    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    // Called when the object starts being focused
    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    // Draw our radius in the editor
    void OnDrawGizmosSelected()
    {
        if(interactionTransform == null)
        {
            interactionTransform = transform;
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}