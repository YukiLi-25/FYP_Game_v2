using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
    // Target to follow
    public Interactable focus;

    public LayerMask movementMask;

    Camera cam;
    PlayerMotor motor;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        // If we press left mouse
        if(Input.GetMouseButtonDown(0)) // when press down leftMouseButton, cast out the ray position
        {
            // We create a ray
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100, movementMask))
            {
                Debug.Log("We hit " + hit.collider.name + " " + hit.point);
                
                motor.MoveToPoint(hit.point); // Move our player to what we hit

                RemoveFocus(); // Stop focusing any objects
            }
        }

        // If we press right mouse
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Check if we hit an interactable
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                // If we did set it as our focus
                if(interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }
    }

    // Target to follow
    void SetFocus(Interactable newFocus)
    {
        if(newFocus != focus) // if focus is change
        {
            if (focus != null)
            {
                focus.OnDefocused();
            }
            focus = newFocus;
            motor.FollowTarget(newFocus);
        }

        newFocus.OnFocused(transform);
    }

    // Target to follow
    void RemoveFocus()
    {
        if (focus != null)
        {
            focus.OnDefocused();
        }
        focus = null;
        motor.StopFollowingTarget();
    }
}
