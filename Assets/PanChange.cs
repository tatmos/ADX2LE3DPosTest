using UnityEngine;
using System.Collections;

public class PanChange : MonoBehaviour {
	public float duration = 0.02f;
	public float minDistance = 5f;
	public float maxDistance = 30f;
	public float dopplerFactor = 0.0f;

	CriAtomExPlayer atomPlayer = null;
	CriAtomEx3dSource atom3dSource = null;
	void Start () {
		atomPlayer = new CriAtomExPlayer(); // AtomExPlayer()作成		
		atom3dSource = new CriAtomEx3dSource();
		atom3dSource.SetMinMaxDistance(minDistance,maxDistance);
		atom3dSource.SetDopplerFactor(dopplerFactor);
		atomPlayer.SetPanType(CriAtomEx.PanType.Pos3d);		
		switch(Random.Range(0,3))
		{
		case 0:		atomPlayer.SetCue(null,"wood");break;
		case 1:		atomPlayer.SetCue(null,"glass");break;
		case 2:		atomPlayer.SetCue(null,"synth");break;
		}
		atomPlayer.Set3dSource(atom3dSource);
		atomPlayer.Set3dListener(CriAtomListener.instance.internalListener);

		int[] noteScale = new int[]{0-12,2-12,5-12,7-12,9-12,0,2,5,7,9,0+12,2+12,5+12,7+12,9+12};
		
		atomPlayer.SetPitch(noteScale[Random.Range(0,noteScale.Length)]*100);
		duration = Random.Range(1,5)*0.2f;
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