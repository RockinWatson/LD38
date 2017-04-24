﻿using UnityEngine;
using UnityEngine.SceneManagement;

using Assets.Scripts;

public class HomeBase : MonoBehaviour {

	private static HomeBase _singleton = null;
	static public HomeBase Get() { return _singleton; }

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
		_singleton = this;
		_resource = STARTING_RESOURCE;
	}

	private void Die() {
		SceneManager.LoadScene(Constants.Scenes.GameOver);

		//@TODO: Die Mofucka.
		GameObject.Destroy(this.gameObject);
	}

	private void OnGUI()
    { 
		if(Application.isEditor) {
			//Rect location = new Rect(Screen.width / 2, Screen.height - 10, Screen.width, Screen.height);
			GUIStyle style = new GUIStyle();
		    style.font = Font.CreateDynamicFontFromOSFont("Cheeseburger",30);
			//style.alignment = TextAnchor.LowerCenter;
			//style.normal.textColor = Color.black;
			float posX = (Screen.width / 2) + 100;
			float posY = Screen.height - 135;
			Rect location = new Rect(posX, posY, Screen.width, Screen.height);
			GUI.Label(location, "" + _resource, style);
		}
	}
}
