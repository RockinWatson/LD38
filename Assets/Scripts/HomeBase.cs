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
		_timer = STARTING_TIME;
	}

	private void Update()
	{
		Timer();
	}

	private void Die() {
		SceneManager.LoadScene(Constants.Scenes.GameOver);

		//@TODO: Die Mofucka.
		GameObject.Destroy(this.gameObject);
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
			SceneManager.LoadScene(Constants.Scenes.Winner1);
		}
	}
}
