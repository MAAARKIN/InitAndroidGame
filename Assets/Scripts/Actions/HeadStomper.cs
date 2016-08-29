using UnityEngine;
using System.Collections;

public class HeadStomper : MonoBehaviour {

	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = transform.parent.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.layer == LayerMask.NameToLayer("Enemy")) {
			Debug.Log("Head Stomper");
			Destroy(other.gameObject);
		}
	}
}
