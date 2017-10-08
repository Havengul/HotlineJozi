using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySprite : MonoBehaviour {
	public SpriteRenderer head = null;
	public SpriteRenderer body = null;
	public SpriteRenderer feet = null;
	public SpriteRenderer weapon = null;

	public void SetHeadSprite (Sprite sprite) {
		if (head != null)
			head.sprite = sprite;
	}

	public void SetBodySprite (Sprite sprite) {
		if (body != null)
			body.sprite = sprite;
	}

	public void SetFeetSprite (Sprite sprite) {
		if (feet != null)
			feet.sprite = sprite;
	}

	public void SetWeaponSprite (Sprite sprite) {
		if (weapon != null)
			weapon.sprite = sprite;
	}
}