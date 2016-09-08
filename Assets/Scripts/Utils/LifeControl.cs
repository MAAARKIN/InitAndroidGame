using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifeControl : MonoBehaviour {

	public Image[] lifes;
	private Player playerClass;

	// Use this for initialization
	void Start () {
		playerClass = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		if (lifes.Length > 0) {

			switch (playerClass.lifes) {
				case 1:
					lifes[0].enabled = true;
					lifes[1].enabled = false;
					lifes[2].enabled = false;
					break;
				case 2:
					lifes[0].enabled = true;
					lifes[1].enabled = true;
					lifes[2].enabled = false;
					break;
				case 3:
					lifes[0].enabled = true;
					lifes[1].enabled = true;
					lifes[2].enabled = true;
					break;
				default:
					Debug.Log("Switch Game Over");
					break;
			}
		} else if (lifes.Length == 0) {
			Debug.Log("Game Over");
		}
	}
}
