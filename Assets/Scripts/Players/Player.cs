using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;
	public Transform initPosition;
	public Transform groundStart;
	public Transform groundEnd;
	public float jumpForce;
	public int lifes;

	private Animator animator;
	private Rigidbody2D rigid2D;
	private SpriteRenderer spriteRenderer;

	private bool isGrounded;
	private bool canJump;
	private int counterBlink;

	private bool goToLeft;
	private bool goToRight;

	public GameObject deathParticle;
	public GameObject respawnParticle;

	private GameObject instantiatedObj;


	// Use this for initialization
	void Start() {
		//utilizados para movimentação
		goToLeft = false;
		goToRight = false;

		//inicialização dos componentes
		rigid2D = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();

		//controle de pulo
		canJump = false;

		//controle de efeito de blink;
		counterBlink = 0;

	}

	void Update() {
		Movimentacao();
		CheckJump();
	}

	void Movimentacao() {
		#if UNITY_STANDALONE
			float axisX = Input.GetAxis("Horizontal");
			animator.SetBool("isWalking", false);
			if (axisX < 0) {
				moverParaEsquerda();
			} else if (axisX > 0) {
				moverParaDireita();
			} else {
				parado();
			}
		#endif

		animator.SetBool("isWalking", false);


		this.rigid2D.velocity = new Vector2(0, rigid2D.velocity.y);
		if (goToLeft && !goToRight) {
			this.transform.eulerAngles = new Vector3(0, 180, 0);
			this.animator.SetBool("isWalking", true);
			this.rigid2D.velocity = new Vector2(-speed, rigid2D.velocity.y);
		} else if (goToRight && !goToLeft) {
			this.transform.eulerAngles = new Vector3(0, 0, 0);
			this.animator.SetBool("isWalking", true);
			this.rigid2D.velocity = new Vector2(speed, rigid2D.velocity.y);
		}
	}

	void CheckJump() {
		if (groundStart && groundEnd) {

			#if UNITY_STANDALONE
				canJump = Input.GetKey(KeyCode.Space);
			#endif

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

	void RestartPlayer() {
		transform.position = initPosition.position;
		InvokeRepeating("Blink", 0.1f, 0.2f);
	}

	void Blink() {
		spriteRenderer.enabled = !spriteRenderer.enabled;

		if (counterBlink == 10) {
			counterBlink = 0;
			spriteRenderer.enabled = true;
			CancelInvoke();
		} else {
			counterBlink++;
		}
	}

	public void PerdeuVida() {

		instantiatedObj = (GameObject) Instantiate(deathParticle, transform.position, transform.rotation);
//		Inst
//		this.animator.SetBool("hit", true);
//		StartCoroutine(RespawnPlayer());
//		Invoke("RestartPlayer", 0f);
		RestartPlayer();
		Destroy(instantiatedObj, 3f);
		lifes--;
	}

	void OnCollisionEnter2D(Collision2D collider) {
		if (collider.gameObject.layer == LayerMask.NameToLayer("Enemy")) {
			Debug.Log("Colidiu com o inimigo");

			if (transform.position.x > collider.transform.position.x) {
//				rigid2D.velocity = new Vector2(jumpForce, 0);
				rigid2D.AddForce(Vector2.right * 100);
			} else {
//				rigid2D.velocity = new Vector2(-jumpForce, 0);
				rigid2D.AddForce(Vector2.left * 100);
			}
//			Vector2 opposite = -rigid2D.velocity;
//			rigid2D.AddForce(opposite * 200);

//			if (transform.position.x < collider.transform.position.x) {
//				rigid2D.AddForce();
//			}
		}
	}

	public void jump() {
		canJump = true;
		TesteCo();
	}

	public void cantJump() {
		canJump = false;
	}

	public void TesteCo() {
//		StartCoroutine("RespawnPlayer");
		StartCoroutine(RespawnPlayer());
	}

	public IEnumerator RespawnPlayer() {
		Debug.Log("teste");
		yield return new WaitForSeconds(3);
		Debug.Log("teste After");
		RestartPlayer();
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;

		Gizmos.DrawLine(groundStart.position, groundEnd.position);
	}
}
