using UnityEngine;
using System.Collections;

public class TileTest : MonoBehaviour {
	public GameObject one;
	public GameObject two;
	public GameObject three;
	public GameObject four;
	public GameObject ground;
	public GameObject wall;
	public GameObject groundtile;
	private Color top = new Color(0,114,255);
	private Color mid = new Color(22,70,129);

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 10; i++){
			for (int j = 0; j < 10; j++){
				if (i == 0 || i == 9 || j == 0 || j == 9){
				GameObject t1 = (GameObject) Instantiate(wall,new Vector2(i,j),Quaternion.identity);
				t1.renderer.material.color = top;
				t1.transform.parent = one.transform;
				GameObject t2 = (GameObject) Instantiate(wall,new Vector2(i,j),Quaternion.identity);
				t2.transform.localScale = new Vector3(.7f,.7f,0);
				t2.renderer.material.color = mid;
				t2.transform.parent = two.transform;
				GameObject t3 = (GameObject) Instantiate(wall,new Vector2(i,j),Quaternion.identity);
				t3.transform.localScale = new Vector3(.5f,.5f,0);
			    t3.renderer.material.color = mid;
				t3.transform.parent = three.transform;
				GameObject t4 = (GameObject) Instantiate(wall,new Vector2(i,j),Quaternion.identity);
				t4.transform.localScale = new Vector3(.3f,.3f,0);
				t4.transform.parent = four.transform;
				}
				else{
					GameObject t5 = (GameObject) Instantiate(groundtile,new Vector3(i,j,0),Quaternion.identity);
					t5.transform.parent = ground.transform;
				}

			}
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
