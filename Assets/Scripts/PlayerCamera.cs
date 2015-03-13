using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour
{
	public Transform positionTarget;
	public Transform lookTarget;
	public float height = 2.0F;
	public float damping = 2.0F;
	public float distance = 2.0F;
	
	// Use this for initialization
	void Start ()
	{
		transform.position = positionTarget.position;
		transform.LookAt (lookTarget);
	}

	void LateUpdate ()
	{

	}
}
