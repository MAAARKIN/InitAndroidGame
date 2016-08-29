using UnityEngine;
using System.Collections;

public class Deadline : MonoBehaviour {

	public Transform startPosition;
	public Transform endPosition;

	private Player player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		if (startPosition && endPosition) {
			RaycastHit2D hit = Physics2D.Linecast(startPosition.position, endPosition.position);

			if (hit && hit.transform.gameObject.name.Equals("Player")) {
				Debug.Log("Player Morreu");
				player.morreu();
			}
		}
	}
}
