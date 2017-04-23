using UnityEngine;

public class MushmanRocket : MushmanBase {
	[SerializeField]
	private float _lifeTime = 3.0f;
	private float _lifeTimer = 0.0f;

	private void Awake() {
		_lifeTimer = 0.0f;
	}

	private void Start() {
		this.transform.Rotate(Vector3.forward * 90.0f);
	}

	private void Update() {
		_lifeTimer += Time.deltaTime;
		if(_lifeTimer > _lifeTime) {
			MushmanDetonate detonate = this.GetComponent<MushmanDetonate>();
			detonate.Detonate();
		}
	}
}
