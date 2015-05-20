using UnityEngine;
using System.Collections;

public class Y_Rotator : MonoBehaviour {
	public float spinSpeed = 0.5f;

	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up,spinSpeed,Space.World );
	}
}
