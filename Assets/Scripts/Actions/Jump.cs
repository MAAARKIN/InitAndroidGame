using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	public Transform groundLayer;
	public float jumpForce;

	private bool isGrounded;
	private Rigidbody2D rigid2D;

	// Use this for initialization
	void Start () {
		rigid2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (groundLayer) {
			isGrounded = Physics2D.Linecast(this.transform.position, groundLayer.position, 1 << LayerMask.NameToLayer("Ground"));
			if (isGrounded && Input.GetKey(KeyCode.Space)) {
				rigid2D.velocity = new Vector2(0, jumpForce);
			}
		}
	}

}
