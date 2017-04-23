using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBase : MonoBehaviour {

	[SerializeField]
	private float STARTING_RESOURCE = 300.0f;

	private float _resource;

	public bool HasEnoughResource(float amount) {
		return (amount <= _resource);
	}

	public void AddResource(float amount) {
		_resource += amount;
	}

	public void UseResource(float amount) {
		_resource -= amount;
	}

	public void Damage(float amount) {
		_resource -= amount;

		// Death Scenario:
		if(_resource <= 0.0f) {
			Die();
		}
	}

	private void Awake() {
		_resource = STARTING_RESOURCE;
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	private void Die() {
		//@TODO: Die Mofucka.
	}

	private void OnGUI() {
		if(Application.isEditor) {
			//Rect location = new Rect(Screen.width / 2, Screen.height - 10, Screen.width, Screen.height);
			GUIStyle style = new GUIStyle();
			//style.alignment = TextAnchor.LowerCenter;
			style.normal.textColor = Color.black;
			float posX = (Screen.width / 2) + 100;
			float posY = Screen.height - 150;
			Rect location = new Rect(posX, posY, Screen.width, Screen.height);
			GUI.Label(location, "" + _resource, style);
		}
	}
}
