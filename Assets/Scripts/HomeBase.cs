using UnityEngine;
using UnityEngine.SceneManagement;

using Assets.Scripts;

public class HomeBase : MonoBehaviour {

	private static HomeBase _singleton = null;
	static public HomeBase Get() { return _singleton; }

	[SerializeField]
	private float STARTING_RESOURCE = 300.0f;
	private float _resource;

	[SerializeField]
	private float STARTING_TIME = 180.0f;
	private float _timer;

	[SerializeField]
	private TextMesh _mushroomForceText = null;
	[SerializeField]
	private TextMesh _timerText = null;

	[SerializeField]
	private RuntimeAnimatorController _animWin = null;
	[SerializeField]
	private RuntimeAnimatorController _animLose = null;

	private Animator _anim = null;

	private enum HomeBaseState {
		NORMAL = 0,
		WIN = 1,
		LOSE = 2,
	};
	private HomeBaseState _state = HomeBaseState.NORMAL;
	private float _stateTimer = 0.0f;
	private bool IsNormalPlay() { return (_state == HomeBaseState.NORMAL); }

	public bool HasEnoughResource(float amount) {
		return (amount <= _resource);
	}

	public void AddResource(float amount) {
		if(!IsNormalPlay()) return;

		_resource += amount;
	}

	public void UseResource(float amount) {
		if(!IsNormalPlay()) return;

		_resource -= amount;
	}

	public void Damage(float amount) {
		if(!IsNormalPlay()) return;

		_resource -= amount;

		// Death Scenario:
		if(_resource <= 0.0f) {
			SetLoseState();
		}
	}

	private void Awake() {
		_singleton = this;
		_resource = STARTING_RESOURCE;
		_timer = STARTING_TIME;
		_state = HomeBaseState.NORMAL;
		_anim = this.GetComponent<Animator>();
	}

	private void Update()
	{
		UpdateState();
	}

	private void UpdateState() {
		switch(_state) {
			case HomeBaseState.NORMAL:
			UpdateNormalState();
			break;
			case HomeBaseState.WIN:
			UpdateWinState();
			break;
			case HomeBaseState.LOSE:
			UpdateLoseState();
			break;
		}
	}

	private void UpdateNormalState() {
		Timer();
	}

	private void SetWinState() {
		_state = HomeBaseState.WIN;
		_anim.runtimeAnimatorController = _animWin;
		_stateTimer = _anim.GetCurrentAnimatorStateInfo(0).length;
	}

	private void UpdateWinState() {
		_stateTimer -= Time.deltaTime;
		if(_stateTimer <= 0.0f)
		{
		    _stateTimer = 0.0f;
		    Constants.Globals.Score = _resource;
			SceneManager.LoadScene(Constants.Scenes.Winner1);
		}
	}

	private void SetLoseState() {
		_state = HomeBaseState.LOSE;
		_resource = 0.0f;
		_anim.runtimeAnimatorController = _animLose;
		_stateTimer = _anim.GetCurrentAnimatorStateInfo(0).length;
	}

	private void UpdateLoseState() {
		_stateTimer -= Time.deltaTime;
		if(_stateTimer <= 0.0f)
		{
		    _stateTimer = 0.0f;
			SceneManager.LoadScene(Constants.Scenes.GameOver);
		}
	}

	private void OnGUI()
	{
		_mushroomForceText.text = ("" + _resource);

		int minutes = Mathf.FloorToInt(_timer / 60F);
		int seconds = Mathf.FloorToInt(_timer - minutes * 60);
		string niceTime = string.Format("Preheat: {0:0}:{1:00}", minutes, seconds);
		_timerText.text = niceTime;
	}

	private void Timer()
	{
		_timer -= Time.deltaTime;
		if (_timer <= 0f)
		{
			SetWinState();
		}
	}
}
