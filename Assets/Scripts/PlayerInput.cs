using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    private GameObject activeUnit = null;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Linecast(clickPosition, clickPosition);

            // If we clicked on an unit
            if (hit.transform != null)
            {
                if (activeUnit != null)
                {
                    // Make the previous unit inactive
                    activeUnit.GetComponent<UnitControl>().isActiveUnit = false;
                }

                // Make this the new active unit
                activeUnit = hit.transform.gameObject;
                activeUnit.GetComponent<UnitControl>().isActiveUnit = true;
            }
            // No unit was click and one was previously active
            else if (activeUnit != null)
            {
                // Unselect the current unit
                activeUnit.GetComponent<UnitControl>().isActiveUnit = false;
                activeUnit = null;
            }
        }
    }

    //void OnMouseDown()
    //{
    //    //Destroy(gameObject);
    //    animator.SetTrigger("UnitSelected");
    //}
}
