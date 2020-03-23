using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudControl : MonoBehaviour {

	public Camera Camera;
	public Transform dummyCrosshair;
	public RectTransform Crosshair;

	void LateUpdate () {
		Vector2 pos = Camera.WorldToScreenPoint(dummyCrosshair.position);
		Crosshair.anchoredPosition = pos;
	}
}
