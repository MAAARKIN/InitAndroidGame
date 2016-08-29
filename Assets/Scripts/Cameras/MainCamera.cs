using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;
	public float initialPosition;

//	private float firstPositionFromCamera;

	// Use this for initialization
	void Start () {
//		firstPositionFromCamera = this.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (target) {
			Camera camera = GetComponent<Camera>();
			Vector3 point = camera.WorldToViewportPoint(target.position);
			Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, point.y, point.z));
			Vector3 destination = transform.position + delta;
//			if (destination.x >= initialPosition) {
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
//			} else {
//				destination.x = firstPositionFromCamera;
//				transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
//			}
		}
	}
}
