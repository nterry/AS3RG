using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

	public Transform target;
	
	private float height;
	private float heightDamping;
	private float rotationDamping;
	private float distance;
	
	// Use this for initialization
	void Start () {
		height = 2.0f;
		heightDamping = 2.0f;
		rotationDamping = 3.0f;
		distance = 5.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void LateUpdate() {
		//return if we dont have a target
		if (!target) return; 

		// Calculate the current rotation angles
		var wantedRotationAngle = target.eulerAngles.y;
		var wantedHeight = target.position.y + height;
		
		var currentRotationAngle = transform.eulerAngles.y;
		var currentHeight = transform.position.y;
		
		// Damp the rotation around the y-axis
		currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
		
		// Damp the height
		currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);
		
		// Convert the angle into a rotation
		var currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);
		
		// Set the position of the camera on the x-z plane to:
		// distance meters behind the target
		transform.position = target.position;
		transform.position -= currentRotation * Vector3.forward * distance;
		
		// Set the height of the camera
		var currentPosition = transform.position;
		transform.position = new Vector3 (currentPosition.x, currentHeight, currentPosition.z);
		
		// Always look at the target
		transform.LookAt (target);
	}
}
