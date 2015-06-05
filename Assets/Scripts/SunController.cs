using UnityEngine;
using System.Collections;

public class SunController : MonoBehaviour {

	public float speed = 6.0F;
	public float gravity = 0.0F;
	private Vector3 moveDirection = Vector3.zero;
	public GameObject player;
	private Vector3 temp;

	void Update() {
		CharacterController controller = GetComponent<CharacterController>();
		if(Input.GetAxis("RightDown") == 0)
			moveDirection = new Vector3(Input.GetAxis("Horizontal2")*2, 0, 0);
		else
			moveDirection = new Vector3(Input.GetAxis("Horizontal2")*4, 0, 0);

		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= speed;
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);

		if (transform.position.x > 58)
			transform.position = new Vector3 (transform.position.x,36.5F,10);			
		else
			transform.position = new Vector3 (transform.position.x,22.34F,10);

		/* Slowly follow the player
		if (Vector3.Distance (transform.position, player.transform.position) > 220) {
			temp = new Vector3(player.transform.position.x, transform.position.y, 10);
			transform.position = Vector3.MoveTowards (transform.position, temp, Time.deltaTime*2);
		}
		*/


	}
}