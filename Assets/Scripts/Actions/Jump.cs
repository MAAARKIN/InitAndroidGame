using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	public Transform groundStart;
	public Transform groundEnd;
	public float jumpForce;

	private bool isGrounded;
	private Rigidbody2D rigid2D;
	private bool canJump;

	// Use this for initialization
	void Start () {
		canJump = false;
		rigid2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (groundStart && groundEnd) {

//			#if UNITY_STANDALONE
				canJump = Input.GetKey(KeyCode.Space);
//			#endif

			Debug.DrawLine(groundStart.position, groundEnd.position, Color.red);
			isGrounded = Physics2D.Linecast(groundStart.position, groundEnd.position, 1 << LayerMask.NameToLayer("Ground"));

			if (isGrounded && canJump) {
				rigid2D.velocity = new Vector2(0, jumpForce);
			}

		}
	}

	public void jump() {
		canJump = true;
	}

	public void cantJump() {
		canJump = false;
	}

}
