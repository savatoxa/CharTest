using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraControl : MonoBehaviour {

	float camRotYSpeed;
	public GameObject Player;
	public GameObject PlayerCameraHelper;

	void Start () {
		camRotYSpeed = 10.0f; 
	}
	
	void LateUpdate () {
		
		float camAngleY = Time.deltaTime * camRotYSpeed;
		PlayerCameraHelper.transform.position = Player.transform.position;


		float LerpYangle = Mathf.LerpAngle (PlayerCameraHelper.transform.eulerAngles.y, Player.transform.eulerAngles.y, camAngleY);
		PlayerCameraHelper.transform.eulerAngles = new Vector3 (PlayerCameraHelper.transform.eulerAngles.x, LerpYangle, PlayerCameraHelper.transform.eulerAngles.z);

	}
}
