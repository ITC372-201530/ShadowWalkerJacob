using UnityEngine;
using System.Collections;

public class PlatformMovement : MonoBehaviour {

	public Transform movingPlatform;
	public Transform position1;
	public Transform position2;
	public Vector3 newPosition;
	public string currentState;

	public float resetTime;
	public AudioClip MovingSound;
	public AudioSource Source;
	
	// Use this for initialization
	void Start () {
		changeTarget ();
		Source = GetComponent<AudioSource>();
		Source.clip = MovingSound;
		
	}
	
	// Update is called once per frame
	void Update () {
		movingPlatform.position = Vector3.MoveTowards(movingPlatform.position, newPosition,Time.deltaTime*10) ;
	}

	void changeTarget ()
	{
		Source = GetComponent<AudioSource>();
		if(!Source.isPlaying)
			Source.Play();

		if (currentState == "1")
		{
			currentState = "2";
			newPosition = position2.position;
		}
		else if (currentState == "2")
		{
			currentState = "1";
			newPosition = position1.position;
		}
		else if (currentState == "")
		{
			currentState = "2";
			newPosition = position2.position;
		}
		Invoke ("changeTarget", resetTime);
	}
}
