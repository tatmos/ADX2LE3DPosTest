using UnityEngine;
using System.Collections;

public class MoveTarget : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.localPosition = new Vector3(Input.GetAxis("Horizontal")+0.01f,0.05f+Input.GetAxis("Vertical"),22+Input.GetAxis("Vertical")*10f);
	}
}
