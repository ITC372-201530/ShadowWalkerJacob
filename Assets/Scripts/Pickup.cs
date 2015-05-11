using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {
	public bool f;
	public GameObject grabedObject;
	public Vector3 Position;
	public Vector3 LastPosition;
	public bool direction; // left - true, right = false

	// Use this for initialization
	void Start () {
		f = false;
		grabedObject = this.gameObject;
		Position = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Position = this.transform.position;
		if(Input.GetAxis("Horizontal")>0)
			Position.z = Position.z + 1;
		else
			Position.z = Position.z - 1;

		f = Input.GetKey (KeyCode.F);
		if (grabedObject.tag == "PickUpable" && f)
			grabedObject.transform.position = Position;  
	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.tag == "PickUpable" && f) 
			grabedObject = other.gameObject;
		else
			grabedObject = this.gameObject;
	}

}
