using UnityEngine;
using System.Collections;

public class Y_Rotator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up,0.5F,Space.World );
	}
}
