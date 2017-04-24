using UnityEngine;
using UnityEngine.SceneManagement;

using Assets.Scripts;

public class HomeBase : MonoBehaviour {

	private static HomeBase _singleton = null;
	static public HomeBase Get() { return _singleton; }

	[SerializeField]
	private float STARTING_RESOURCE = 300.0f;

	private float _resource;

    public Font MyFont;
    public float timer;

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

    void Update()
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
		if(Application.isEditor) {
			//Rect location = new Rect(Screen.width / 2, Screen.height - 10, Screen.width, Screen.height);
			GUIStyle style = new GUIStyle();
		    GUI.skin.font = MyFont;
		    style.fontSize = 35;
			//style.alignment = TextAnchor.LowerCenter;
			//style.normal.textColor = Color.black;
			float posX = (Screen.width / 2) + 40;
			float posY = Screen.height - 139;
			Rect location = new Rect(posX, posY, Screen.width, Screen.height);
			GUI.Label(location, "" + _resource, style);

            //Timer
		    GUIStyle style2 = new GUIStyle();
		    GUI.skin.font = MyFont;
		    style.fontSize = 35;
		    float posX2 = (Screen.width / 2) + 150;
		    float posY2 = Screen.height - 139;
		    Rect location2 = new Rect(posX2, posY2, Screen.width, Screen.height);

		    int minutes = Mathf.FloorToInt(timer / 60F);
		    int seconds = Mathf.FloorToInt(timer - minutes * 60);
		    string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
            GUI.Label(location2, "" + niceTime, style);
        }
	}

    private void Timer()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SceneManager.LoadScene(Constants.Scenes.Winner1);   
        }
    }
}
