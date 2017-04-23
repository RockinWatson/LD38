using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushmanRocket : MushmanBase {
	private void Start() {
		this.transform.Rotate(Vector3.forward * 90.0f);
	}
}
