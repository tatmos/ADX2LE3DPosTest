using UnityEngine;
using System.Collections;

public class RandomCube : MonoBehaviour {
	public int numCube = 10;
	public GameObject target;
	// Use this for initialization
	void Start () {
		for(int i = 0;i<numCube;i++){
			GameObject go = Instantiate(target,new Vector3(Random.Range (-10,10)*4f,Random.Range (-10,10)*4f,Random.Range (-10,10)*4f),Quaternion.identity) as GameObject;
			go.renderer.material.color = new Color(0.5f+Random.Range(0,0.5f),0.5f+Random.Range(0,0.5f),0.5f+Random.Range(0,0.5f));
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
