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
		
		transform.rotation = Quaternion.LookRotation(lookAt.position - transform.position,this.transform.up);
		this.transform.Translate(0.0f,0f,speed);
	}
}
