using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour {

	private const KeyCode KEY_SPAWN_BUDDIES = KeyCode.Space;

	private Player _player = null;
	private HomeBase _homeBase = null;

	// Use this for initialization
	void Start () {
		_player = GameObject.FindWithTag("Player").GetComponent<Player>();
		_homeBase = GameObject.FindWithTag("HomeBase").GetComponent<HomeBase>();
	}

	// Update is called once per frame
	void Update () {
		UpdatePlayerAbilities();
	}

	private void UpdatePlayerAbilities() {
		if(Input.GetKeyDown(KEY_SPAWN_BUDDIES)) {
			if(CanSpawnBuddies()) {
				SpawnBuddies();
			}
		}
	}

	private bool CanSpawnBuddies() {
		//@TODO: Check against Resource cost of real stuffs...
		return _homeBase.HasEnoughResource(0);
	}

	private void SpawnBuddies() {
		//@TODO: Spawn / Instantiate prefabs of your buddies here...
		Debug.Log("SPAWNING BUDDIES..!");
	}
}
