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

	public byte SpotHitDirection (Vector3 hitPointRelative)
	{
		if (hitPointRelative.x >= 0)
		{
			if (hitPointRelative.z <= 0)
			{
				return 0;
			}
			else
			{
				return 1;
			}
		}
		else
		{
			if (hitPointRelative.z >= 0)
			{
				return 2;
			}
			else
			{
				return 3;
			}
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
		var enemyColliderHitPointRelative = transform.InverseTransformPoint(enemyColliderHitPoint.transform.position);
		//Debug.Log("enemyColliderHitPointRelative :" + enemyColliderHitPointRelative);
		Debug.Log("hitDirection: " + SpotHitDirection(enemyColliderHitPointRelative));
		//Debug.Log("enemyColliderHitPoint: " + enemyColliderHitPoint.transform.position);
	}

	// void OnCollisionEnter(Collision collision)
	// {
	// 	ContactPoint contact = collision.GetContact(0);
	// 	var bulletContactPoint = contact.point;
	// 	var enemyColliderCenter = enemyCollider.bounds.center;
	// 	Vector3 enemyRelative = transform.InverseTransformPoint(bulletContactPoint);
	// }

}