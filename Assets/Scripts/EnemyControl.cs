using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {

	Animator enemyAnim;
	Collider enemyCollider;
	public List<GameObject> enemyWayPoints = new List<GameObject>();
	public playerRifleControl Rifle;
	public GameObject enemyColliderHitPoint;

	public void SetWayPoints (List<GameObject> waypoints) {
		foreach (var waypoint in waypoints) {
			enemyWayPoints.Add (waypoint);
		}
	}

	void Start () {
		enemyAnim = GetComponent<Animator>();
		enemyCollider = GetComponent<Collider>();
		playerRifleControl hit = GetComponent<playerRifleControl>();
	}
	void OnTriggerEnter (Collider other)
	{
		//enemyAnim.enabled = false;
		Debug.Log("enemyColliderHitPoint: " + enemyColliderHitPoint.transform.position);
	}

	// void OnCollisionEnter(Collision collision)
	// {
	// 	ContactPoint contact = collision.GetContact(0);
	// 	var bulletContactPoint = contact.point;
	// 	var enemyColliderCenter = enemyCollider.bounds.center;
	// 	Vector3 enemyRelative = transform.InverseTransformPoint(bulletContactPoint);
	// 	Debug.Log("contact point: " + bulletContactPoint.ToString());
	// 	Debug.Log("enemy collider bounds center: " + enemyColliderCenter.ToString());
	// 	Debug.Log("enemyRelative: " + enemyRelative.ToString());
	// 	Debug.DrawRay(bulletContactPoint, contact.normal, Color.white);
	// }

}