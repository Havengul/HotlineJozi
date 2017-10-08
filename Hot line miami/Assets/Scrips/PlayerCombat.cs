﻿using System;
using UnityEngine;

public enum EquippedWeapon
{
	Hands,
	Uzi,
	Shotgun,
	Saber,
	SuperPunch
}

public class PlayerCombat : MonoBehaviour
{
	public EquippedWeapon EquippedWeapon;
	public BulletSpawn BulletSpawn;
	public int Ammo;
	public GameObject Saber;
	public GameObject Fist;
	public bool IsSlicing = false;
	private int SliceRot = 0;
	public Transform PlayerTrans;
	private bool IsPunching = false;
	private int PunchTimer = 0;
	private void Start()
	{
		EquippedWeapon = EquippedWeapon.Hands;
		Ammo = 0;
		PlayerTrans = GameObject.FindGameObjectWithTag("Player").transform;
		SliceRot = 0;
		IsSlicing = false;
		IsPunching = false;
		PunchTimer = 0;
	}

	public void SetWeapon(EquippedWeapon weapon, int ammo)
	{
		EquippedWeapon = weapon;
		Ammo = ammo;
	}

	public void SetWeapon(EquippedWeapon weapon)
	{
		EquippedWeapon = weapon;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Mouse1))
			EquippedWeapon = EquippedWeapon.Hands;
		if (EquippedWeapon == EquippedWeapon.Saber)
		{
			if (Input.GetKeyDown(KeyCode.Mouse0))
				IsSlicing = true;
			Saber.transform.rotation = PlayerTrans.rotation * Quaternion.Euler(0, 0, -SliceRot);
			Saber.transform.position = PlayerTrans.position;
			Saber.transform.Translate(Vector3.right * 30 * Time.deltaTime, Space.Self);
			if (IsSlicing)
			{
				SliceRot += 30;
				if (SliceRot >= 360)
				{
					SliceRot = 0;
					IsSlicing = false;
				}
			}
		}
		else if (EquippedWeapon == EquippedWeapon.SuperPunch)
		{
			if (Input.GetKeyDown(KeyCode.Mouse0) && PunchTimer == 0)
				IsPunching = true;
			if (IsPunching)
			{
				Fist.transform.Translate(Vector3.right * 50 * Time.deltaTime, Space.Self);
				transform.position = Fist.transform.position;
				PunchTimer++;
				if (PunchTimer >= 10)
				{
					PunchTimer = 0;
					IsPunching = false;
				}
			}
			else
			{
				if (PunchTimer > 0)
					PunchTimer--;
				Fist.transform.rotation = PlayerTrans.rotation * Quaternion.Euler(0, 0, 270);
				Fist.transform.position = PlayerTrans.position;
				Fist.transform.Translate(Vector3.right * 30 * Time.deltaTime, Space.Self);
			}
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.Mouse0))
				Attack();

			if (!Input.GetKeyDown(KeyCode.Mouse1)) return;
			if (EquippedWeapon == EquippedWeapon.Hands) return;

			EquippedWeapon = EquippedWeapon.Hands;
			ThrowWeapon();
		}
	}

	private static void ThrowWeapon()
	{
		Debug.Log("Time For An Upgrade!");
	}

	private void Attack()
	{
		Debug.Log("Finsh Him!");
		switch (EquippedWeapon)
		{
			case EquippedWeapon.Hands:
				break;
			case EquippedWeapon.Uzi:
				if (Ammo > 0)
				{
					BulletSpawn.FireSmallRound();
					Ammo -= 1;
				}
				break;
			case EquippedWeapon.Shotgun:
				if (Ammo > 0)
				{
					BulletSpawn.FireBuckShot();
					Ammo -= 1;
				}
				break;
			case EquippedWeapon.Saber:
				break;
			case EquippedWeapon.SuperPunch:
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}
}