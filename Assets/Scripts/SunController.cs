using UnityEngine;
using System.Collections;

public class SunController : MonoBehaviour {
	public float speed = 6.0F;
	public float gravity = 0.0F;
	private Vector3 moveDirection = Vector3.zero;
	void Update() {
		CharacterController controller = GetComponent<CharacterController>();
		moveDirection = new Vector3(Input.GetAxis("Vertical"), Input.GetAxis("Vertical")/3* Time.deltaTime, 0);
		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= speed;
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
}