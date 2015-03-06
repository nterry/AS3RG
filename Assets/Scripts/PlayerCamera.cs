using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {

	public Transform target;
	
	public float height = 2.0F;
	public float damping = 2.0F;
	public float distance = 2.0F;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void LateUpdate() {
		//return if we dont have a target
		if (!target)
			return;

		transform.position = Vector3.Lerp (transform.position, new Vector3(target.position.x, target.position.y + height, target.position.z - distance), Time.deltaTime * damping);
	}
}
