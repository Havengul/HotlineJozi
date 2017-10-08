using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float MoveSpeed = 10f;

	public bool IsMoving = false;

	public GameObject LegAnimation;

	public bool isLooking;

	void Update()
	{
		isLooking = !(Camera.main.GetComponent<CameraFollowPlayer>().CameraIsFollowingPlayer);
		IsMoving = false;
		if (isLooking)
		{
			LegAnimation.SetActive(false);
			return;
		}
		if (Input.GetKey(KeyCode.W))
		{
			IsMoving = true;
			transform.Translate(Vector3.up * MoveSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey(KeyCode.S))
		{
			IsMoving = true;
			transform.Translate(Vector3.down * MoveSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey(KeyCode.A))
		{
			IsMoving = true;
			transform.Translate(Vector3.left * MoveSpeed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey(KeyCode.D))
		{
			IsMoving = true;
			transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime, Space.World);
		}
		if (!IsMoving)
			LegAnimation.SetActive(false);
		else
		{
			LegAnimation.SetActive(true);
		}
	}
}
