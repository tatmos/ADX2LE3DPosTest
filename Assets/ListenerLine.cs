using UnityEngine;
using System.Collections;

public class ListenerLine : MonoBehaviour {

	Transform target;
	LineRenderer lr;
	// Use this for initialization
	void Start () {
		target = CriAtomListener.instance.transform;
		lr = this.gameObject.GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(this.transform.position , this.target.position) < 10){
			lr.SetPosition(0,this.transform.position);		
			lr.SetPosition(1,this.target.position);
			lr.SetWidth(0,1);
		} else if(Vector3.Distance(this.transform.position , this.target.position) < 30){
			lr.SetPosition(0,this.transform.position);		
			lr.SetPosition(1,this.target.position);
			lr.SetWidth(0,(30 - Vector3.Distance(this.transform.position , this.target.position))/30f);
		} else {
			lr.SetPosition(0,this.transform.position);		
			lr.SetPosition(1,this.transform.position);
			lr.SetWidth(0.0f,0.0f);
		}
	}
}
