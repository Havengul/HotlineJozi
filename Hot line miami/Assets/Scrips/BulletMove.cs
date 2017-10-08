using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
	public float MovementSpeed = 15f;

	void Update () {
		transform.Translate(Vector3.right* MovementSpeed * Time.deltaTime, Space.Self);
	}
}
