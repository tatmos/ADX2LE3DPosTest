using UnityEngine;
using System.Collections;

public class PanChange : MonoBehaviour {
	public float duration = 0.02f;
	public float minDistance = 10f;
	public float maxDistance = 100f;
	public float dopplerFactor = 0.2f;

	public CriAtomExPlayer atomPlayer = null;
	CriAtomEx3dSource atom3dSource = null;
	LineRenderer lr;
	void Awake () {
		atomPlayer = new CriAtomExPlayer(); // AtomExPlayer()作成		
		atom3dSource = new CriAtomEx3dSource();
	}
	void Start () {
		atom3dSource.SetMinMaxDistance(minDistance,maxDistance);
		atom3dSource.SetDopplerFactor(dopplerFactor);
		atomPlayer.SetPanType(CriAtomEx.PanType.Pos3d);		

		atomPlayer.Set3dSource(atom3dSource);
		atomPlayer.Set3dListener(CriAtomListener.instance.internalListener);

		lr = GetComponent<LineRenderer>();
    }
	float time = 0;
	void Update () {	
		atom3dSource.SetPosition(this.transform.position.x,this.transform.position.y,this.transform.position.z);
		atom3dSource.Update();
		//atomPlayer.UpdateAll();
		if(Time.timeSinceLevelLoad > time){
			atomPlayer.Start();
			time = Time.timeSinceLevelLoad+duration;
        }

		this.transform.localScale = new Vector3(Mathf.Max(0.5f+1.0f-atomPlayer.GetTime()*0.0001f,1f),Mathf.Min(0.5f+atomPlayer.GetTime()*0.01f,1f),Mathf.Min(0.5f+atomPlayer.GetTime()*0.01f,1f));
		this.transform.LookAt(CriAtomListener.instance.transform.position);

		if(atomPlayer.GetTime() < 200){
			lr.enabled = true;
		} else {
			lr.enabled = false;
		}
    }
	void OnDestroy()
	{
		if(atomPlayer != null){
            atomPlayer.Dispose(); // 破棄
            atomPlayer = null;
			atom3dSource.Dispose();
			atom3dSource = null;
		}
	}
}