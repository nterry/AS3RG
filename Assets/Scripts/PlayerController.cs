using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 6.0F;
	public float turnSpeed = 45.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 0.01F;
	
	
	private Vector3 moveDirection = Vector3.zero;
	private float health = 100.0F;
	private float vSpeed = 0.0F;
	
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
		
		if (controller.isGrounded) {
			if (Input.GetButton ("Jump")) {
				vSpeed = 10.0F;
			} else {
				vSpeed = 0.0F;
			}
		} else {
			vSpeed -= gravity * Time.deltaTime;
		}
		
		Debug.Log (vSpeed);
		
		moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0.0F, Input.GetAxis ("Vertical"));
		moveDirection.Normalize ();
		moveDirection = transform.TransformDirection (moveDirection);
		
		moveDirection.y = vSpeed * 0.15F;
		
		
		
		controller.Move (moveDirection * moveSpeed * Time.deltaTime);
		
		
	}
	
	public void Damage(float damageAmount)
	{
		if (health > 0.0F) {
			health -= damageAmount;
		} else if (health <= 0.0F) {
			health = 0.0F;
			Die ();
		}
	}
	
	private void Die()
	{
	}
}
