using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
    private Camera mainCamera;
    GameObject selectedObject;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (selectedObject != null) //Clear previous selection
            {
                foreach (ISelectable selectable in selectedObject.GetComponents(typeof(ISelectable)))
                    selectable.ClearSelection();
            }
            if (hit.collider != null && IsSelectable(hit.transform))
            {
                selectedObject = hit.transform.gameObject;
                foreach (ISelectable selectable in selectedObject.GetComponents(typeof(ISelectable)))
                    selectable.OnObjectClicked();
            }
        }
    }

    private bool IsSelectable(Transform transform)
    {
        return transform.CompareTag("Tower");
    }
}
