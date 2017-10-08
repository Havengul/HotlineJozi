using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateEffect : MonoBehaviour
{
	private PlayerMovement _playerMovement;

	private float _mod;
	private float _zVal;

	void Start()
	{
		_playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
	}

	void Update()
	{
		if (!_playerMovement.IsMoving) return;
		
		var rotation = new Vector3(0, 0, _zVal);
		transform.eulerAngles = rotation;
		_zVal += _mod;
		if (transform.eulerAngles.z < 5.0f && transform.eulerAngles.z < 10.0f)
			_mod = -1;
		else
			_mod = +1;
	}
}