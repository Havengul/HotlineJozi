using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {
	public Enemy enemy = null;
	public Sprite head = null;
	public Sprite body = null;
	public Sprite feet = null;
	public Sprite weapon = null;

	private Enemy CreateEnemy () {
		Enemy newEnemy = GameObject.Instantiate (enemy) as Enemy;
		if (head != null)
			newEnemy.sprite.SetHeadSprite (head);
		if (body != null)
			newEnemy.sprite.SetBodySprite (body);
		if (feet != null)
			newEnemy.sprite.SetFeetSprite (feet);
		if (weapon != null)
			newEnemy.sprite.SetWeaponSprite (weapon);
		return newEnemy;
	}

	void Start () {
		for (int i = 1; i <= 1; i++)
			CreateEnemy ();
	}
	
	void Update () {
		
	}
}
