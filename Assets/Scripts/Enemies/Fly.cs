using UnityEngine;
using System.Collections;

public class Fly : MonoBehaviour {

	public Transform knockStartArea;
	public Transform knockEndArea;
//	private SimpleMove simpleMove;
	private Animator animatorController;

	// Use this for initialization
	void Start () {
//		this.simpleMove = GetComponent<SimpleMove>();
		this.animatorController = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.DrawLine(knockStartArea.position, knockEndArea.position, Color.red);
//		RaycastHit2D hit = Physics2D.Linecast(knockStartArea.position, knockEndArea.position);
//
//		if (hit && hit.transform.gameObject.name.Equals("Player")) {
//			Debug.Log("Player deu knockout");
//			simpleMove.enabled = false;
//			hit.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10);
//			this.animatorController.SetTrigger("dead");
//			dying();
//		}
	}

	IEnumerator WaitToDead() {
		yield return new WaitForSeconds(2.0F);
	}

	void dying() {
//		StartCoroutine(WaitToDead());
		this.animatorController.SetTrigger("dead");
//		Destroy(gameObject);
	}
}
