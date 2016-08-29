using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;
	public Transform initPosition;
	public Transform groundStart;
	public Transform groundEnd;
	public float jumpForce;

	private Animator animator;
	private Rigidbody2D rigid2D;
	private bool isGrounded;
	private bool canJump;

	private bool goToLeft;
	private bool goToRight;

	// Use this for initialization
	void Start() {
		goToLeft = false;
		goToRight = false;
		rigid2D = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		canJump = false;
	}

	void FixedUpdate() {
		CheckJump();
//		Movimentacao();
	}

	// Update is called once per frame
	void Update() {
		Movimentacao();
//		CheckJump();
	}

	void morrendo() {
		this.transform.position = initPosition.position;
	}

	void Movimentacao() {
//		#if UNITY_STANDALONE
			float axisX = Input.GetAxis("Horizontal");
			animator.SetBool("isWalking", false);
			if (axisX < 0) {
				moverParaEsquerda();
			} else if (axisX > 0) {
				Debug.Log("go to direita");
				moverParaDireita();
			} else {
				parado();
			}
//		#endif
		Debug.Log("RigidBody velocity X: "+rigid2D.velocity.x);
		Debug.Log("RigidBody velocity Y: "+rigid2D.velocity.y);
		animator.SetBool("isWalking", false);
		this.rigid2D.velocity = new Vector2(0, rigid2D.velocity.y);
		if (goToLeft && !goToRight) {
			this.transform.eulerAngles = new Vector3(0, 180, 0);
			this.animator.SetBool("isWalking", true);
//			this.transform.position += Vector3.left * speed * Time.deltaTime;
			this.rigid2D.velocity = new Vector2(-speed, rigid2D.velocity.y);
		} else if (goToRight && !goToLeft) {
			this.transform.eulerAngles = new Vector3(0, 0, 0);
			this.animator.SetBool("isWalking", true);
//			this.transform.position += Vector3.right * speed * Time.deltaTime;
			this.rigid2D.velocity = new Vector2(speed, rigid2D.velocity.y);
		}
	}

	void CheckJump() {
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

	public void moverParaEsquerda() {
		goToLeft = true;
		goToRight = false;
	}

	public void moverParaDireita() {
		this.goToLeft = false;
		this.goToRight = true;
	}

	public void parado() {
		this.goToLeft = false;
		this.goToRight = false;
	}

	public void morreu() {
		this.animator.SetBool("hit", true);
		Invoke("morrendo", 0.5f);
	}

	public IEnumerator WaitToDead() {
		print("Starting " + Time.time);
		yield return new WaitForSeconds(2);
		print("before " + Time.time);
	}

	void OnCollisionEnter2D(Collision2D collider) {
		if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy")) {
			Debug.Log("Colidiu com o inimigo");

			if (transform.eulerAngles.y > 0) {
				rigid2D.velocity = new Vector2(6, 0);
			} else {
				rigid2D.velocity = new Vector2(-6, 0);
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
