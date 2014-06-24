using UnityEngine;
using System.Collections;

public class Transformtest : MonoBehaviour {
	public GameObject scaleThis;
	public GameObject scalar;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		foreach(Transform t in scaleThis.GetComponentInChildren<Transform>()){

			if (t.name == "MID"){
				Vector3 pos = (t.localPosition - scalar.transform.position);
				float clampx = Mathf.Clamp(pos.x,-1,0f);
				float clampy = Mathf.Clamp(pos.y,.1f,.5f);
				float clampz = Mathf.Clamp(pos.z,-1,0f);
				Vector3 clampVec = new Vector3(clampx,.7f,clampz);
				t.localScale = Vector3.Lerp(new Vector3(t.localScale.x,.7f,0), -clampVec ,Time.deltaTime * 5f);

			}
			if (t.name == "BOT"){
				Vector3 pos = (t.localPosition - scalar.transform.position).normalized;
				float clampx = Mathf.Clamp(pos.x,-1,0f);
				float clampy = Mathf.Clamp(pos.y,.1f,.5f);
				float clampz = Mathf.Clamp(pos.z,-1,0f);
				Vector3 clampVec = new Vector3(clampx,.3f,clampz);
				t.localScale = Vector3.Lerp(new Vector3(t.localScale.x,.3f,0), -clampVec ,Time.deltaTime * 5f);
			}

		}
	}
}
