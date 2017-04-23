using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Olive : MonoBehaviour {

	[SerializeField]
	private float _rotateSpeed = 1.0f;

	// Update is called once per frame
	private void Update () {
		this.transform.RotateAround(this.transform.position, Vector3.forward, _rotateSpeed * Time.deltaTime);
	}
}
