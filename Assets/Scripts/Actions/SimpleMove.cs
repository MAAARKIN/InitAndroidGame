using UnityEngine;
using System.Collections;

public class SimpleMove : MonoBehaviour {

	public float timeMoving;
	public bool initLeft;
	public float speed;
	private float clock = 0;

	private 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 move = Vector3.zero;
		clock += Time.deltaTime;
		if (clock <= timeMoving) {

			if (initLeft) {
				move = Vector3.left;
			} else {
				move = Vector3.right;
			}
//			clock++;
		} else {
			clock = 0;
			initLeft = !initLeft;
		}
		this.transform.position += move * speed * Time.deltaTime;
	}
}
