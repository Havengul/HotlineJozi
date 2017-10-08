using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToCursor : MonoBehaviour
{
	private Vector3 _mousePosition;

	private void Update()
	{
		_mousePosition = Input.mousePosition;
		_mousePosition.z = 5.23f;
 
		var objectPos = Camera.main.WorldToScreenPoint (transform.position);
		_mousePosition.x = _mousePosition.x - objectPos.x;
		_mousePosition.y = _mousePosition.y - objectPos.y;
 
		var angle = Mathf.Atan2(_mousePosition.y, _mousePosition.x) * Mathf.Rad2Deg + 90;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
	}

}