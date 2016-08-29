using UnityEngine;
using System.Collections;

public class MobileControl : MonoBehaviour {

	private Player playerClass;
//	private Jump jumpClass;

	private bool goToLeft;
	private bool goToRight;
	private bool canJump;

	// Use this for initialization
	void Start () {
//		player = GameObject.Find("Player").GetComponent<Player>();
		playerClass = FindObjectOfType<Player>();
//		jumpClass = FindObjectOfType<Jump>();
		goToLeft = false;
		goToRight = false;
		canJump = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (goToLeft && !goToRight) {
			playerClass.moverParaEsquerda();
		} else if (goToRight && !goToLeft) {
			playerClass.moverParaDireita();
		} else {
			playerClass.parado();
		}

		if (canJump) {
			playerClass.jump();
//			jumpClass.jump();
		} else {
//			jumpClass.cantJump();
			playerClass.cantJump();
		}
	}

	public void leftPressed() {
		goToLeft = true;
	}

	public void leftUnpressed() {
		goToLeft = false;
	}

	public void rightPressed() {
		goToRight = true;
	}

	public void rightUnpressed() {
		goToRight = false;
	}

	public void jumpPressed() {
		canJump = true;
	}

	public void jumpUnressed() {
		canJump = false;
	}
}
