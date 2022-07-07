using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractingController : MonoBehaviour
{
    [SerializeField] float distanceWithRadius;

    public Interactable focus;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizInput = Input.GetAxis("Horizontal");
        float verticInput = Input.GetAxis("Vertical");

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    distanceWithRadius = Vector3.Distance(interactable.transform.position, transform.position);
                    if (distanceWithRadius <= 10)
                    {
                        SetFocus(interactable);
                    }
                }
            }
        }

        if (horizInput != 0 || verticInput != 0)
        {
            RemoveFocus();
        }
    }
    void SetFocus(Interactable newFocus)
    {

        if (newFocus != focus)
        {
            if (focus != null)
            {
                focus.OnFocused(transform);
            }
            focus = newFocus;

        }
        newFocus.OnFocused(transform);


    }
    void RemoveFocus()
    {
        if (focus != null)
        {
            focus.OnDefocused();
        }
        focus = null;
    }
}
