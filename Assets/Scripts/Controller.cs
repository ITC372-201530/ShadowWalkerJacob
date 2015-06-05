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
	public float shadowEnergyCP;
	public GameObject [] shadows;
	public Vector3 restartPoint;
	private static Controller instance;
	public bool regen;
	public float regenAmount;
	public AudioClip ShadowDrainSound;
	public AudioClip HitSound;
	public AudioClip DoorUnlockSound;
	public AudioClip JumpSound;
	public AudioClip CheckPointSound;
	public AudioClip ShadowPickupSound;
	public AudioClip KeySound;
	public AudioSource Source;
	public int keys;
	public Text KeyText;
	public Text WinText;
	public Text Timer;
	public float gameTime;
	private int score = -1;


	void Start(){	

		shadowEnergyCP = 100;
		regenAmount = 0.01F;
		restartPoint = this.transform.position;	
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		if (instance != this) 
			Destroy (gameObject);
		instance.keys = 0;
		instance.shadowBar = this.shadowBar;
		instance.KeyText = this.KeyText;
		instance.WinText = this.WinText;
		instance.Timer = this.Timer;
		WinText.text = "";
		Source = GetComponent<AudioSource>();
	}

	void Update() {
		gameTime += Time.deltaTime;
		Timer.text = gameTime.ToString("0.00") + "  Seconds";
		if(shadowBar != null)
			shadowBar.value = shadowEnergy;

		shadows = GameObject.FindGameObjectsWithTag("Shadow");
		CharacterController controller = GetComponent<CharacterController>();

		if (controller.isGrounded) {
			moveDirection = transform.TransformDirection(Input.GetAxis("Horizontal"), 0, 0) * speed;
			if (Input.GetAxis("Fire1") == 1){							
				moveDirection.y = jumpSpeed * 2;
				Source.clip = JumpSound;
				Source.Play();
			}
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

		if (controller.transform.localPosition.y == temp.y) {
			if(!(moveDirection.y <= 0)){
				if(!Source.isPlaying){
					Source.clip = HitSound;
					Source.Play();
				}
			}
			moveDirection.y = 0;
		}

		if (Input.GetAxis ("Exit") == 1) {
			Application.Quit();
		}

		if(Input.GetAxis("L_TRigger") == 1){
			if (shadowEnergy > 0){
				foreach (GameObject sdw in shadows)				
					sdw.collider.enabled = true;

				Source.clip = ShadowDrainSound;
				if(!Source.isPlaying)
					Source.Play();
				shadowEnergy -= 0.1f;
			}			
		}

		if (Input.GetAxis("L_TRigger") <= 0.8F) {
			foreach (GameObject sdw in shadows)			
				sdw.collider.enabled = false;
			regen = true;
		}
		
		if (shadowEnergy <= 0)		
			foreach (GameObject sdw in shadows) {
				sdw.collider.enabled = false;
				sdw.GetComponentInChildren<Collider>().enabled = true;
			}

		if (regen && shadowEnergy < 100)
			shadowEnergy += regenAmount;
		else
			shadowEnergy = 100;
	}

	void OnTriggerEnter(Collider other){
		switch (other.gameObject.tag) {
			case "Collectable":
				shadowEnergy += 15f;
				other.gameObject.SetActive(false);
				Source.clip = ShadowPickupSound;
				Source.Play();
				break;

			case "Win":
				print ("You Win");
				if(score == -1)
					score = (int)(shadowEnergy / gameTime * 100);
				WinText.text = "Level Complete! \n\n Score:" + score ;
				regenAmount = 1;
				break;

			case "checkPoint":
				if(restartPoint != other.gameObject.transform.position){
					Source.clip = CheckPointSound;
					Source.Play();
					restartPoint = other.gameObject.transform.position;
					shadowEnergyCP = shadowEnergy;
				}
				break;

			case "Hazard":
				isRestarting = false;
				break;

			case "Locked Door":
				if(keys > 0){
					other.gameObject.SetActive(false);
					keys--;
					KeyText.text = "Keys: " + keys;
					
					Source.clip = DoorUnlockSound;
					Source.Play();
				}
				break;

			case "Key":
				other.gameObject.SetActive(false);
				keys++;
				KeyText.text = "Keys: " + keys;
				Source.clip = KeySound;
				Source.Play();
				break;
		}
	}

	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Ladder" && Input.GetAxis("Vertical") != 0)  {				
			transform.position = new Vector3 (transform.position.x, transform.position.y + 0.4F, transform.position.z);
			gravity = 0;
		}		 
	}

	void OnTriggerExit(Collider other){
		gravity = 30;	 
	}	

	void RestartLevel (){
		Application.LoadLevel ("Level01");
		if(restartPoint.y > 1)
			transform.position = new Vector3 (restartPoint.x, restartPoint.y + 1, 0);
		else
			transform.position = new Vector3 (restartPoint.x, restartPoint.y + 1, 0);
		shadowEnergy = shadowEnergyCP;
	}
}