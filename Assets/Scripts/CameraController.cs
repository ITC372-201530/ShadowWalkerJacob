using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	public GameObject player;
	public GameObject Sun;
	private Vector3 offset;
	
	void Start () 
	{
		offset = transform.position;
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void LateUpdate (){
		player = GameObject.FindGameObjectWithTag ("Player");
		if (player.transform.position.y >= 1.0) 
			transform.position = player.transform.position + offset;
			
	}
	
}
