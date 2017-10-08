using System;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    private const int UziAmmo = 15;
    private const int ShotgunAmmo = 2;

    public void OnTriggerStay2D(Collider2D obj)
    {
        PickUpGun(obj);
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        Debug.Log("befor" + obj);
        PickUpGun(obj);
    }

    public void PickUpGun(Collider2D obj)
    {
        Debug.Log("before" + obj);
//        if (obj.GetComponent<PlayerCombat>().EquippedWeapon != EquippedWeapon.Hands) return;
        if (!Input.GetKeyDown(KeyCode.E)) return;
        if (CompareTag("Uzi"))
        {
            obj.GetComponent<PlayerCombat>().SetWeapon(EquippedWeapon.Uzi, UziAmmo);
        }
        else if (CompareTag("Shotgun"))
        {
            obj.GetComponent<PlayerCombat>().SetWeapon(EquippedWeapon.Shotgun, ShotgunAmmo);
        }
        else if (CompareTag("Saber"))
        {
            obj.GetComponent<PlayerCombat>().SetWeapon(EquippedWeapon.Saber);
        }
        else if (CompareTag("Punch"))
        {
            obj.GetComponent<PlayerCombat>().SetWeapon(EquippedWeapon.SuperPunch);
        }
    }
}