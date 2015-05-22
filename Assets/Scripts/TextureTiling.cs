using UnityEngine;
using System.Collections;

public class TextureTiling : MonoBehaviour {


	// Use this for initialization
	void Start () {
		this.gameObject.renderer.material.SetTextureScale("_MainTex",new Vector2(this.gameObject.transform.lossyScale.x,this.gameObject.transform.lossyScale.y))  ;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
