using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kablooey : MonoBehaviour {

	private const float DELAY = 0.0f;

	private Animator _anim = null;

	private void Awake() {
		_anim = this.GetComponent<Animator>();
	}

	private void Start() {
		GameObject.Destroy(this.gameObject, _anim.GetCurrentAnimatorStateInfo(0).length + DELAY);
	}
}
