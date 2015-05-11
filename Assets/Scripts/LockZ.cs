using UnityEngine;
using System.Collections;

public class LockZ : MonoBehaviour {

	//This script locks the object to z = 0 stopping it from falling off the Map

	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, 0);
	}
}
