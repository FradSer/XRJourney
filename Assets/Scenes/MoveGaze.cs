using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGaze: MonoBehaviour {
    
  private float startTime;
  private GameObject attachedObject = null;
  private GameObject lookedatObject = null;
  private bool dockHasMovedForward = false;
  
  // Start is called before the first frame update
  void Start() {
    startTime = Time.time;
  }

  // Update is called once per frame
  void Update() {
    Ray ray = new Ray(transform.position, transform.forward);
    RaycastHit hit;
    
    float currentTime = Time.time;

    if (attachedObject == null) {
      // Check to see if the ray cast from the CenterEyeObject hit anything
      if (Physics.Raycast(ray, out hit, 100)) {
        // If the ray cast has hit something check to see if it has been for longer than 0.2 seconds
        if ((currentTime - startTime) > 0.2) {
          attachedObject = lookedatObject;
          dockState = 2;
          if (dockHasMovedForward == false) {
            attachedObject.GetComponent < Animator > ().SetTrigger("Sight Into");
            dockHasMovedForward = true;
          }
        } else {
          // If less than 0.2 seconds make it the looked at object
          if (lookedatObject == null) {
            lookedatObject = hit.collider.gameObject;
          }
        }
      } else {
        // If the ray isn't hitting anything
        if (lookedatObject != null) {
          lookedatObject.GetComponent < Renderer > ().material.color = Color.white;
        }
        startTime = currentTime;
        lookedatObject = null;
      }
    } else {
      // If the attached object is not null, check to see if it has been put down.
      if (attachedObject.GetComponent < Renderer > ().material.color == Color.white) {
        startTime = currentTime;
        attachedObject = null;
      }
    }
  }
}
