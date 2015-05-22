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
			transform.position = new Vector3(parentPosition.x -(sunPosition.x - parentPosition.x), parentPosition.y -(sunPosition.y - parentPosition.y),0);
	}
}