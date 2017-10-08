using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLegDirection : MonoBehaviour
{

	private Vector3 legRot;

	// Use this for initialization
	void Start () {
		legRot = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey(KeyCode.W))
		{
			legRot = new Vector3(0, 0, 180);
		}
		if (Input.GetKey(KeyCode.S)) {
			legRot = new Vector3(0, 0, 0);
		}
		if (Input.GetKey(KeyCode.A)) {
			legRot = new Vector3(0, 0, 270);
		}
		if (Input.GetKey(KeyCode.D)) {
			legRot = new Vector3(0, 0, 90);
		}
		transform.eulerAngles = legRot;
	}
}
