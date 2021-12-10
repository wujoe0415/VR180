using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCamera : MonoBehaviour
{
    private const float _maxDistance = 100;
    private GameObject _gazedAtObject = null;

    [Header("MouseLookProperties")]
    public float mouseSenesitvity = 1.0f;
    float xRotation = 0f;
    float debugx = 0f, debugy = 0f;
    
    // Update is called once per frame
    void Update()
    {
        /*float mouseX = Input.GetAxis("Mouse X") * mouseSenesitvity * Time.deltaTime;
        
        float mouseY = Input.GetAxis("Mouse Y") * mouseSenesitvity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0f);
        transform.Rotate(Vector3.up * mouseX);*/

        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        RaycastHit hit;
        Ray ray = GameObject.Find("Main Camera").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            // GameObject detected in front of the camera.
            if (_gazedAtObject != hit.transform.gameObject)
            {
                // New GameObject.
                _gazedAtObject?.SendMessage("OnPointerExit");
                _gazedAtObject = hit.transform.gameObject;
                _gazedAtObject.SendMessage("OnPointerEnter");
                
            }
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("in");
                _gazedAtObject?.SendMessage("OnPointerClick");
            }
        }
        else
        {
            // No GameObject detected in front of the camera.
            _gazedAtObject?.SendMessage("OnPointerExit");
            _gazedAtObject = null;
        }
        
    
    }
}
