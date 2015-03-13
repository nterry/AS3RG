using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 6.0F;
	public float turnSpeed = 45.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;

	private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start ()
	{
	}

	void FixedUpdate ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		CharacterController controller = GetComponent<CharacterController> ();

		transform.Rotate (0.0F, Input.GetAxis ("Mouse X") * turnSpeed * Time.deltaTime, 0.0F);

		moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0.0F, Input.GetAxis ("Vertical"));
		moveDirection.Normalize ();
		moveDirection = transform.TransformDirection (moveDirection);

		controller.Move (moveDirection * moveSpeed * Time.deltaTime);

	}
}
