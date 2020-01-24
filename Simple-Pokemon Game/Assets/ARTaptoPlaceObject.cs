using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using System;

public class ARTaptoPlaceObject : MonoBehaviour
{
    public GameObject objectToPlace;
    public GameObject object2;
    public Transform ob3;
    public GameObject placementIndicator;
    private ARSessionOrigin arOrigin;
    private Pose placementPose;
    private bool placementPoseIsValid = false;
    public Canvas c;
    private bool a = false;
    public MeshRenderer m;
    public MeshCollider m2;
    void Start()
    {
        c.enabled = false;
        arOrigin = FindObjectOfType<ARSessionOrigin>();
    }

    void Update()
    {
        if (a == false)
        {
            UpdatePlacementPose();
            UpdatePlacementIndicator();

        }

        if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (a == false)
            {
                PlaceObject();
                m.enabled = false;
                m2.enabled = false;          
                //c.enabled = true;
            }
            
            
        }   
    }

    private void PlaceObject()
    {
        Instantiate(objectToPlace, placementPose.position + new Vector3(0f, 0f, 0.5f), ob3.rotation);
            Instantiate(object2, placementPose.position + new Vector3(0f, 0f,-0.5f), placementPose.rotation);
        a = true;
        placementIndicator.SetActive(false);


    }

    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));   
        var hits = new List<ARRaycastHit>();
        arOrigin.GetComponent<ARRaycastManager>().Raycast(screenCenter, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;

            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }

    }
}
