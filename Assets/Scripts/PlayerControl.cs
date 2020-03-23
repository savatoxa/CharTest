using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	Animator anim;
	public GameObject Spine;
	private bool idleToIdleSit;
	float rotLookSpeed;
	float rotSpineSpeed;
	float minRotSpine;
	float maxRotSpine;
	float dampRunTrans;

	void Start () {
		anim = GetComponent<Animator> ();
		idleToIdleSit = false;
		anim.SetBool ("idleToShootStay", false);
		anim.SetBool ("idleToIdleSit", idleToIdleSit);
		anim.SetBool ("idleSitToShootSit", false);
		anim.SetFloat ("runForward", 0.0f);
		anim.SetFloat ("runSides", 0.0f);
		rotLookSpeed = 5.0f;
		rotSpineSpeed = 10.0f;
		minRotSpine = -60.0f;
		maxRotSpine = 60.0f;
		dampRunTrans = 0.1f;
	}
	
	void Update () {

		float mouseInputX = Input.GetAxis ("Mouse X") * rotLookSpeed;
		if (Input.GetMouseButton(1)) {
			Vector3 look = new Vector3 (0, mouseInputX, 0);
			transform.Rotate (look);
		}

		if (Input.GetKey ("w")) {
			anim.SetFloat ("runForward", 1.0f);
		}
		else if (Input.GetKey("s")) {
			anim.SetFloat ("runForward", -1.0f);
		} else {
			anim.SetFloat ("runForward", 0.0f);
		}

		if (Input.GetKey ("d")) {
			anim.SetFloat ("runSides", 1.1f, dampRunTrans, Time.deltaTime);
		}
		else if (Input.GetKey ("a")) {
			anim.SetFloat ("runSides", -1.1f, dampRunTrans, Time.deltaTime);
		} else {
			anim.SetFloat ("runSides", 0.01f, dampRunTrans, Time.deltaTime);
		}

		if (Input.GetKeyDown ("space")) {
			idleToIdleSit = !idleToIdleSit;
			anim.SetBool ("idleToIdleSit", idleToIdleSit);
		}

		if (Input.GetMouseButton(0)) {
			anim.SetBool ("idleToShootStay", true);
			anim.SetBool ("idleSitToShootSit", true);
		} else {
			anim.SetBool ("idleToShootStay", false);
			anim.SetBool ("idleSitToShootSit", false);
		}
			
	}

	private float angleSpine;

	void LateUpdate () {

		if (Input.GetMouseButton (1)) {
			float mouseInputY = Input.GetAxis ("Mouse Y") * rotSpineSpeed;
			angleSpine += mouseInputY;
			angleSpine = Mathf.Clamp (angleSpine, minRotSpine, maxRotSpine);
		}

			//Spine.transform.Rotate (Vector3.forward, angleSpine);

		Vector3 rotSpine = new Vector3 (Spine.transform.localEulerAngles.x, angleSpine, Spine.transform.localEulerAngles.z);
			Spine.transform.localEulerAngles = rotSpine;
			//Spine.transform.Rotate(rotSpine);
	}


}
