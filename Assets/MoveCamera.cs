using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

	public Transform lookAt = null;
	public float speed = 0.01f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.X)){
			this.transform.Translate(0.0f,0f,-speed*100f);
		} 
		if(Input.GetKey(KeyCode.E)){
			this.transform.Translate(0.0f,0f,speed*100f);
		}  
		if(Input.GetKey(KeyCode.Z)){
			this.transform.Translate(-speed*100f,0f,0f);
		} 
		if(Input.GetKey(KeyCode.C)){
			this.transform.Translate(speed*100f,0f,0f);
		}  
		if(Input.GetKey(KeyCode.R)){
			this.transform.Translate(0f,speed*100f,0f);
		} 
		if(Input.GetKey(KeyCode.F)){
			this.transform.Translate(0f,-speed*100f,0f);
		}  
		{
			transform.rotation = Quaternion.LookRotation(lookAt.position - transform.position,this.transform.up);
			this.transform.Translate(0.0f,0f,speed);
		}
	}
}
