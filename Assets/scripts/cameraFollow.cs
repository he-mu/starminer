using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {

	/*// The target we are following
	public  Transform target;
	// The distance in the x-z plane to the target
	public int distance = 10.0;
	// the height we want the camera to be above the target
	public int height = 10.0;
	// How much we 
	public heightDamping = 2.0f;
	public rotationDamping = 0.6f;
	
	
	void  LateUpdate (){
		// Early out if we don't have a target
		if (TargetScript.russ == true){
			if (!target)
				return;
			
			// Calculate the current rotation angles
			wantedRotationAngle = target.eulerAngles.y;
			wantedHeight = target.position.y + height;
			
			currentRotationAngle = transform.eulerAngles.y;
			currentHeight = transform.position.y;
			
			// Damp the rotation around the y-axis
			currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
			
			// Damp the height
			currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);
			
			// Convert the angle into a rotation
			currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);
			
			// Set the position of the camera on the x-z plane to:
			// distance meters behind the target
			transform.position = target.position;
			transform.position -= currentRotation * Vector3.forward * distance;
			
			// Set the height of the camera
			transform.position.y = currentHeight;
			
			// Always look at the target
			transform.LookAt (target);
		}
	} */
}