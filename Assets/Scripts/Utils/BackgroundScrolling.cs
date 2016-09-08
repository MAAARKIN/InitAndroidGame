using UnityEngine;
using System.Collections;

public class BackgroundScrolling : MonoBehaviour {

	public float speed;
	private MeshRenderer render;
	private float axisX;

	// Use this for initialization
	void Start () {
		render = GetComponent<MeshRenderer>();
		axisX = 0;
	}
	
	// Update is called once per frame
	void Update () {
//		axisX += speed;
//		render.materials[0].SetTextureOffset("_MainTex", new Vector2(axisX, 0f));
	}

	void FixedUpdate() {
		axisX += speed;
		render.materials[0].SetTextureOffset("_MainTex", new Vector2(axisX, 0f));
	}
}
