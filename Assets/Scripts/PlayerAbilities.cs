using Assets.Scripts;
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
	private GameObject BlockerPrefab = null;
	[SerializeField]
	private float WALKER_COST = 20.0f;
	[SerializeField]
	private GameObject WalkerPrefab = null;
	[SerializeField]
	private float BOMB_COST = 30.0f;
	[SerializeField]
	private GameObject BombPrefab = null;
	[SerializeField]
	private float ROCKET_COST = 40.0f;
	[SerializeField]
	private GameObject RocketPrefab = null;

	private Player _player = null;
	private HomeBase _homeBase = null;

	// Use this for initialization
	void Start () {
		_player = GameObject.FindWithTag(Constants.Tags.Player).GetComponent<Player>();
		_homeBase = GameObject.FindWithTag(Constants.Tags.HomeBase).GetComponent<HomeBase>();
	}

	// Update is called once per frame
	void Update () {
		UpdatePlayerAbilities();
	}

	private void UpdatePlayerAbilities() {
		bool selectionMade = false;

		if(Input.GetKeyDown(KEY_SELECT_BLOCKER)) {
			_selectedMushmenType = MushmenType.BLOCKER;
			selectionMade = true;
		}
		if(Input.GetKeyDown(KEY_SELECT_WALKER)) {
			_selectedMushmenType = MushmenType.WALKER;
			selectionMade = true;
		}
		if(Input.GetKeyDown(KEY_SELECT_BOMB)) {
			_selectedMushmenType = MushmenType.BOMB;
			selectionMade = true;
		}
		if(Input.GetKeyDown(KEY_SELECT_ROCKET)) {
			_selectedMushmenType = MushmenType.ROCKET;
			selectionMade = true;
		}

		if(selectionMade || Input.GetKeyDown(KEY_SPAWN_BUDDIES)) {
			TrySpawn(_selectedMushmenType);
		}
	}

	private float GetMushmenCost(MushmenType type) {
		switch(type) {
			case MushmenType.BLOCKER:
			return BLOCKER_COST;
			case MushmenType.WALKER:
			return WALKER_COST;
			case MushmenType.BOMB:
			return BOMB_COST;
			case MushmenType.ROCKET:
			return ROCKET_COST;
			default:
			Debug.LogError("Unrecognized Mushmen Type!");
			return 0;
		}
	}

	private void TrySpawn(MushmenType type) {
		if(CanSpawn(type)) {
			Spawn(type);
		}
	}

	private bool CanSpawn(MushmenType type) {
		float cost = GetMushmenCost(type);
		return _homeBase.HasEnoughResource(cost);
	}

	private void Spawn(MushmenType type) {
		switch(type) {
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
		GameObject walker = (GameObject)Instantiate(BlockerPrefab);
		walker.transform.position = _player.transform.position;

		_homeBase.UseResource(BLOCKER_COST);
	}

	private void SpawnWalker() {
		GameObject walker = (GameObject)Instantiate(WalkerPrefab);
		walker.transform.position = _player.transform.position;

		_homeBase.UseResource(WALKER_COST);
	}

	private void SpawnBomb() {
		GameObject walker = (GameObject)Instantiate(BombPrefab);
		walker.transform.position = _player.transform.position;

		_homeBase.UseResource(BOMB_COST);
	}

	private void SpawnRocket() {
		GameObject walker = (GameObject)Instantiate(RocketPrefab);
		walker.transform.position = _player.transform.position;

		_homeBase.UseResource(ROCKET_COST);
	}
}
