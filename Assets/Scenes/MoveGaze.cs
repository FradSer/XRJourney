using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGaze: MonoBehaviour {
    
  private float startTime;
  private GameObject attachedObject = null;
  private GameObject lookedatObject = null;
  
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
        // If the ray cast has hit something check to see if it has been for longer than 2 seconds
        if ((currentTime - startTime) > 2) {
          attachedObject = lookedatObject;
          attachedObject.GetComponent < Rigidbody > ().useGravity = false;
          attachedObject.GetComponent < Rigidbody > ().isKinematic = false;
          // Set the position of the object to the position of the CenterEyeObject
          // attachedObject.transform.parent = this.transform;
          attachedObject.GetComponent < Renderer > ().material.color = Color.red;
          // Trigger the animation
          attachedObject.GetComponent < Animator > ().SetTrigger("Sight Into");
        } else {
          // If less than 2 seconds make it the looked at object and turn it blue
          if (lookedatObject == null) {
            lookedatObject = hit.collider.gameObject;
            lookedatObject.GetComponent < Renderer > ().material.color = Color.blue;
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
