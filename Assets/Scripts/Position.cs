using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour {
	
	private Vector3 sunPosition;
	private Vector3 parentPosition;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

			sunPosition = GameObject.FindGameObjectWithTag ("Sun").transform.position;
			parentPosition = transform.parent.position;
			transform.position = new Vector3(0.0f, parentPosition.y -(sunPosition.y - parentPosition.y), parentPosition.z -(sunPosition.z - parentPosition.z));
	}
}