using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControl : MonoBehaviour {

	public float Delay = 2.0f;

	private float timeLeft;

	void Start () {
		timeLeft = Delay;
	}

	void Update () {
		timeLeft -= Time.deltaTime;
		if (timeLeft <= 0) {
			Destroy (gameObject);
		}
	}
}
