using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnControl : MonoBehaviour {

	public EnemyControl enemy;
	public GameObject enemyColliderHitpoint;
	public List<GameObject> enemyWayPoints = new List<GameObject>();
	string enemyWayPointsName = "enemyWayPoint";

	void Start () {

		foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject))) {
			if (go.name.Substring(0, go.name.Length - 3) == enemyWayPointsName)
				enemyWayPoints.Add (go);
		}

		Instantiate(enemyColliderHitpoint);
		Instantiate (enemy, new Vector3(0,0,0), Quaternion.identity);
		enemy.SetWayPoints (enemyWayPoints);
	}

}