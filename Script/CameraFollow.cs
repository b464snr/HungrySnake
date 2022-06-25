using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform targetObject;
    public float smoothFactor;
    public Space offsetPositionSpace = Space.Self;
    public Vector3 cameraOffset;
    public bool lookAtTarget = true;
    private Vector3 newPosition;
    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - targetObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {   
        if(offsetPositionSpace == Space.Self)
        {
            newPosition = targetObject.TransformPoint(cameraOffset);
        }
        else {
            newPosition = targetObject.transform.position + cameraOffset;
        }

        transform.position = Vector3.Slerp(transform.position, newPosition, smoothFactor);
        
        if (lookAtTarget) {
            transform.LookAt(targetObject);
        }
     }
}