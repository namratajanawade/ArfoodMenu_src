using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;

public class InputManager : MonoBehaviour
{
// EDITOR FIELDS
    [SerializeField] private Camera arCam;
    [SerializeField] private ARRaycastManager _rayCastManger;
    [SerializeField] private GameObject crosshair;
    
// MEMBER VARIABLES
    private List<ARRaycastHit> _hits = new List<ARRaycastHit>();
    private Touch touch;
    private Pose pose;

// FUNCTIONS

    // Update is called once per frame
    void Update()
    {
        touch = Input.GetTouch(0);

        if (Input.touchCount < 0 || touch.phase != TouchPhase.Began)
            return;

        if (IsPointerOverUI(touch)) return;
        
        // Calculate Crosshair position from the center of screen.
        CrossHairCalc();

        // Creating Object on the game world
        Instantiate(DataHandler.Instance.GetFoodItem(), pose.position, pose.rotation);
    }

// HELPERS

    // If we are updating UI on top of the renderer.
    private bool IsPointerOverUI(Touch touch)
    {
        // Add the touch data to event and store the 2D Location transform
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(touch.position.x, touch.position.y);
        
        // Add to list.
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        return results.Count > 0;
    }

    // Crosshair like interaction.
    private void CrossHairCalc()
    {
        // Get the ray direction from the touch
        Vector3 origin = arCam.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0.5f));
        
        // Screen point to ray works based on mobile orientation.
        Ray ray = arCam.ScreenPointToRay(origin);

        // Stores the crosshair location and rotation
        if(_rayCastManger.Raycast(ray, _hits))
        {
            pose = _hits[0].pose;
            crosshair.transform.position = pose.position;
            crosshair.transform.eulerAngles = new Vector3(90, 0, 0);
        }
    }

}
