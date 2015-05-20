using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Controller : MonoBehaviour {
	public float speed = 6.0F;
	public float jumpSpeed = 10.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;
	public bool isRestarting = false;
	public Slider shadowBar;
	public float shadowEnergy;
	public GameObject [] shadows;
	public float pushPower = 10.0F;
	public Canvas wintext;
	public GameObject Sun;
	public Vector3 restartPoint;
	private static Controller instance;
	public bool regen;
	public AudioClip ShadowDrainSound;
	public AudioClip HitSound;
	public AudioSource Source;

	void Start(){	
		restartPoint = this.transform.position;	
		if (instance == null) {
			instance = this;
			shadowEnergy = 100;
			DontDestroyOnLoad(gameObject);
		}
		if (instance != this)
			Destroy (gameObject);

		Source = GetComponent<AudioSource>();
	}

	void Update() {
		if(shadowBar != null)
			shadowBar.value = shadowEnergy;		 	

		shadows = GameObject.FindGameObjectsWithTag("Shadow");
		CharacterController controller = GetComponent<CharacterController>();

		if (controller.isGrounded) {
			moveDirection = transform.TransformDirection(Input.GetAxis("Horizontal"), 0, 0) * speed;
			if (Input.GetAxis("Fire1") == 1)							
				moveDirection.y = jumpSpeed * 2;
		}	
		else {
			moveDirection = transform.TransformDirection(Input.GetAxis("Horizontal"), moveDirection.y, 0);
			moveDirection.x *= speed;
			moveDirection.y -= gravity * Time.deltaTime;
		}
		  
		if (transform.position.y < -10)
			isRestarting = false;
			
		if (!isRestarting) {				
			RestartLevel ();
			isRestarting = true;
		}
		Vector3 temp = controller.transform.localPosition;
		controller.Move(moveDirection * Time.deltaTime);

		if (controller.transform.localPosition.y == temp.y) {// Hit sound?
			Source.clip = HitSound;
			if(moveDirection.y >= 0)
			{
				if(!Source.isPlaying)
					//Source.Play();						
				moveDirection.y = 0;
			}
		}

		if(Input.GetKey(KeyCode.UpArrow)){
			if (shadowEnergy > 0)
				foreach (GameObject sdw in shadows)				
					sdw.collider.enabled = true;
			if(shadowEnergy>0){	
				Source.clip = ShadowDrainSound;
				if(!Source.isPlaying)
					Source.Play();
				shadowEnergy -= 0.1f;
			}
		}

		if (Input.GetKeyUp (KeyCode.UpArrow)) {
			foreach (GameObject sdw in shadows)			
				sdw.collider.enabled = false;
			regen = true;
			Source.Stop();
		}
		
		if(shadowEnergy <= 0)		
			foreach (GameObject sdw in shadows)			
				sdw.collider.enabled = false;

		if(regen && shadowEnergy<=100)
			shadowEnergy+= 0.01f;

	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Collectable"){
			shadowEnergy += 15f;
			other.gameObject.SetActive(false);
		}
		if (other.gameObject.tag == "Win")		
			wintext.enabled = true;

		if (other.gameObject.tag == "checkPoint") // Checkpoint sound		
			restartPoint = other.gameObject.transform.position;

		if (other.gameObject.tag == "Hazard") // Death sound		
			isRestarting = false;
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		Rigidbody body = hit.collider.attachedRigidbody;
		if (body == null || body.isKinematic)
			return;
		
		if (hit.moveDirection.y < 0)
			return;
		
		Vector3 pushDir = new Vector3(0, 0, hit.moveDirection.z);
		body.velocity = pushDir * pushPower * 2;
	}
	 
	void RestartLevel (){
		Application.LoadLevel ("Level01Updated");
		if(restartPoint.y > 1)
			transform.position = new Vector3 (restartPoint.x, restartPoint.y, 0);
		else
			transform.position = new Vector3 (restartPoint.x, restartPoint.y + 1, 0);
	}
}