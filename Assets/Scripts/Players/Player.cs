using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;
	private Animator animator;
//	private Hud hud;
//	private bool isMaxLeft;
//	private bool isMaxRight;
	// Use this for initialization
	void Start() {
		animator = GetComponent<Animator>();
//		hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<Hud>();
	}

	// Update is called once per frame
	void Update() {
		movimentacao();	
	}

	void movimentacao() {
		if (Application.platform == RuntimePlatform.OSXEditor) {
			float axisX = Input.GetAxis("Horizontal");
			Debug.Log(axisX);
			Vector3 move = Vector3.zero;
			animator.SetBool("isWalking", false);
			if (axisX < 0) {
				move = Vector3.left;
				transform.eulerAngles = new Vector3(0, 180, 0);
				animator.SetBool("isWalking", true);
			} else if (axisX > 0) {
				transform.eulerAngles = new Vector3(0, 0, 0);
				move = Vector3.right;
				animator.SetBool("isWalking", true);
			}
			this.transform.position += move * speed * Time.deltaTime;
		}
	}
}
