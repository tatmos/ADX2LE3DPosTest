using UnityEngine;
using System.Collections;

public class RandomCube : MonoBehaviour {
	public int numCube = 10;
	public GameObject target;
	// Use this for initialization
	void Start () {
		for(int i = 0;i<numCube;i++){
			GameObject go = Instantiate(target,new Vector3(Random.Range (-10,10)*4f,Random.Range (-10,10)*4f,Random.Range (-10,10)*4f),Quaternion.identity) as GameObject;

			PanChange pc = go.GetComponent<PanChange>();
			LineRenderer lr = go.GetComponent<LineRenderer>();

			switch(Random.Range(0,5))
			{
			case 0:		pc.atomPlayer.SetCue(null,"wood");go.renderer.material.color = new Color(0.95f+Random.Range(0,0.05f),0.5f+Random.Range(0,0.5f),0.5f+Random.Range(0,0.5f));break;
			case 1:		pc.atomPlayer.SetCue(null,"glass");go.renderer.material.color = new Color(0.5f+Random.Range(0,0.5f),0.95f+Random.Range(0,0.05f),0.5f+Random.Range(0,0.5f));break;
			case 2:		pc.atomPlayer.SetCue(null,"synth");go.renderer.material.color = new Color(0.5f+Random.Range(0,0.5f),0.5f+Random.Range(0,0.5f),0.95f+Random.Range(0,0.05f));break;
			case 3:		pc.atomPlayer.SetCue(null,"noise");go.renderer.material.color = new Color(0.95f+Random.Range(0,0.05f),0.95f+Random.Range(0,0.05f),0.95f+Random.Range(0,0.05f));break;
			case 4:		pc.atomPlayer.SetCue(null,"tri");go.renderer.material.color = new Color(0.95f+Random.Range(0,0.05f),0.95f+Random.Range(0,0.05f),0.5f+Random.Range(0,0.5f));break;
			}

			int[] noteScale = new int[]{0-12,2-12,5-12,7-12,9-12,0,2,5,7,9,0+12,2+12,5+12,7+12,9+12};
			
			pc.atomPlayer.SetPitch(noteScale[Random.Range(0,noteScale.Length)]*100);
			pc.duration = Random.Range(1,5)*0.2f;

			lr.SetColors(new Color(go.renderer.material.color.r,go.renderer.material.color.g,go.renderer.material.color.b,0.2f),
			             new Color(go.renderer.material.color.r,go.renderer.material.color.g,go.renderer.material.color.b,0.1f));
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
