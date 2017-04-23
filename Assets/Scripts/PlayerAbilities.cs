using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour {

	private enum MushmenType {
		BLOCKER = 0,
		WALKER = 1,
		BOMB = 2,
		ROCKET = 4,
	};
	private MushmenType _selectedMushmenType = MushmenType.BLOCKER;

	private const KeyCode KEY_SPAWN_BUDDIES = KeyCode.Space;
	private const KeyCode KEY_SELECT_BLOCKER = KeyCode.Alpha1;
	private const KeyCode KEY_SELECT_WALKER = KeyCode.Alpha2;
	private const KeyCode KEY_SELECT_BOMB = KeyCode.Alpha3;
	private const KeyCode KEY_SELECT_ROCKET = KeyCode.Alpha4;

	// Mushmen Costs
	[SerializeField]
	private float BLOCKER_COST = 10.0f;
	[SerializeField]
	private float WALKER_COST = 20.0f;
	[SerializeField]
	private float BOMB_COST = 30.0f;
	[SerializeField]
	private float ROCKET_COST = 40.0f;

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

		if(Input.GetKeyDown(KEY_SELECT_BLOCKER)) {
			_selectedMushmenType = MushmenType.BLOCKER;
		}
		if(Input.GetKeyDown(KEY_SELECT_WALKER)) {
			_selectedMushmenType = MushmenType.WALKER;
		}
		if(Input.GetKeyDown(KEY_SELECT_BOMB)) {
			_selectedMushmenType = MushmenType.BOMB;
		}
		if(Input.GetKeyDown(KEY_SELECT_ROCKET)) {
			_selectedMushmenType = MushmenType.ROCKET;
		}
	}

	private float GetMushmenCost(MushmenType type) {
		switch(type) {
			case MushmenType.BLOCKER:
			return BLOCKER_COST;
			case MushmenType.WALKER:
			return BLOCKER_COST;
			case MushmenType.BOMB:
			return BLOCKER_COST;
			case MushmenType.ROCKET:
			return BLOCKER_COST;
			default:
			Debug.LogError("Unrecognized Mushmen Type!");
			return 0;
		}
	}

	private bool CanSpawnBuddies() {
		float cost = GetMushmenCost(_selectedMushmenType);
		return true;
		//@TODO: Get this going once HomeBase is generating sheeeit.
		//return _homeBase.HasEnoughResource(cost);
	}

	private void SpawnBuddies() {
		switch(_selectedMushmenType) {
			case MushmenType.BLOCKER:
			SpawnBlocker();
			return;
			case MushmenType.WALKER:
			SpawnWalker();
			return;
			case MushmenType.BOMB:
			SpawnBomb();
			return;
			case MushmenType.ROCKET:
			SpawnRocket();
			return;
		}
	}

	private void SpawnBlocker() {
		GameObject walker = (GameObject)Instantiate(Resources.Load("Mushmen/MushmanBlocker"));
		walker.transform.position = _player.transform.position;
	}

	private void SpawnWalker() {
		GameObject walker = (GameObject)Instantiate(Resources.Load("Mushmen/MushmanWalker"));
		walker.transform.position = _player.transform.position;
	}

	private void SpawnBomb() {
		GameObject walker = (GameObject)Instantiate(Resources.Load("Mushmen/MushmanBomb"));
		walker.transform.position = _player.transform.position;
	}

	private void SpawnRocket() {
		GameObject walker = (GameObject)Instantiate(Resources.Load("Mushmen/MushmanRocket"));
		walker.transform.position = _player.transform.position;
	}
}
