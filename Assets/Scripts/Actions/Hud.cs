using UnityEngine;
using System.Collections;

public class Hud : MonoBehaviour {

	public Texture2D hudBackground;
	public Texture2D life;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {

		//background
		GUI.DrawTexture(new Rect(Screen.width * (0.01f), Screen.height * (0.03f), Screen.width * (0.19f), Screen.height * (0.1f)), hudBackground);

		//lifes
		GUI.DrawTexture(new Rect(Screen.width * (0.03f), Screen.height * (0.05f), Screen.width * (0.03f), Screen.height * (0.06f)), life);
		GUI.DrawTexture(new Rect(Screen.width * (0.07f), Screen.height * (0.05f), Screen.width * (0.03f), Screen.height * (0.06f)), life);
		GUI.DrawTexture(new Rect(Screen.width * (0.11f), Screen.height * (0.05f), Screen.width * (0.03f), Screen.height * (0.06f)), life);
		GUI.DrawTexture(new Rect(Screen.width * (0.15f), Screen.height * (0.05f), Screen.width * (0.03f), Screen.height * (0.06f)), life);
//		if (exibir) {
//			GUI.DrawTexture(new Rect(Screen.width * (0.01f), Screen.height * (0.06f), Screen.width * (0.2f), Screen.height * (0.1f)), hudBackground);
//		}
	}
}
