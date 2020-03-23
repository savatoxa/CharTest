using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRifleControl : MonoBehaviour {

	public Transform Dummy_fire;
	public Transform dummyCrosshair;
	public GameObject Bullet;
	public GameObject enemyColliderHitPoint;
	public GameObject enemy;
	public float bulletSpeed = 10.0f;
	public float fireRate = 1.0f;
	public float shootDist = 100.0f;
	public Vector3 worldPosCrosshair;
	public Vector3 worldPosEnemyHit;
	public float angDisp = 10.0f;
	private float fireDelay;
	private float lastShot = 0.0f;
	private LayerMask hitMaskGround;
	private LayerMask hitMaskEnemies;

	void Start () {
		hitMaskGround = LayerMask.GetMask ("ground");
		hitMaskEnemies = LayerMask.GetMask ("Enemies");
		fireDelay = 1.0f / fireRate;
	}
	
	private void Fire() {
		if (Time.time > lastShot + fireDelay) {
			var DummyFireOrientInit = Dummy_fire.transform.localEulerAngles;
			Dummy_fire.transform.localEulerAngles = new Vector3 (Random.Range(-angDisp, angDisp), Random.Range(-angDisp, angDisp), Random.Range(-angDisp, angDisp));

			var bullet = Instantiate (Bullet);
			bullet.transform.position = Dummy_fire.transform.position;
			bullet.transform.forward = Dummy_fire.transform.forward;
			bullet.GetComponent<Rigidbody> ().velocity = GetComponent<Rigidbody> ().velocity + bulletSpeed * Dummy_fire.transform.forward;

			Dummy_fire.transform.localEulerAngles = DummyFireOrientInit;
			lastShot = Time.time;
		}
	}

	void Update () {
		
		var origin = Dummy_fire.transform.position;
		var direction = Dummy_fire.forward;
		RaycastHit hitInfo;

		if (Physics.Raycast (origin, direction, out hitInfo, shootDist, hitMaskGround)) {
			worldPosCrosshair = hitInfo.point;
		} else {
			worldPosCrosshair = origin + shootDist * direction;
		}

		if (Physics.Raycast (origin, direction, out hitInfo, shootDist, hitMaskEnemies)){
			worldPosEnemyHit = hitInfo.point;
			enemyColliderHitPoint.transform.position = worldPosEnemyHit;
		}

		dummyCrosshair.transform.position = worldPosCrosshair;

		Debug.DrawRay (origin, direction * shootDist, Color.red);

		if (Input.GetMouseButton(0)) {
			Fire();
		}

	}
}